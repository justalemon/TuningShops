using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using GTA;
using GTA.UI;
using LemonUI.Menus;
using Newtonsoft.Json;

namespace TuningShops
{
    /// <summary>
    /// A basic configuration system for GTA V Mods.
    /// </summary>
    public abstract class ConfigurationCore
    {
        #region Fields

        private bool xmlLoaded = false;
        private XmlDocument xmlDocument = null;

        #endregion

        #region Tools

        private static string GetPathWithExtension(string extension)
        {
            Uri url = new Uri(Assembly.GetExecutingAssembly().CodeBase);
            string directory = Path.GetDirectoryName(url.LocalPath);
            return Path.Combine(directory, Path.GetFileNameWithoutExtension(url.LocalPath) + extension);
        }

        #endregion

        #region Tools

        private static string FormatName(string text)
        {
            StringBuilder builder = new StringBuilder();

            foreach (char character in text)
            {
                if (char.IsUpper(character) || char.IsNumber(character))
                {
                    builder.Append(' ');
                }

                builder.Append(character);
            }

            return builder.ToString().Trim();
        }
        private string GetSummary(PropertyInfo property)
        {
            if (!xmlLoaded)
            {
                string path = GetPathWithExtension(".xml");

                if (!File.Exists(path))
                {
                    xmlLoaded = true;
                    return string.Empty;
                }

                xmlDocument = new XmlDocument();
                xmlDocument.Load(path);
                xmlLoaded = true;
            }

            if (xmlDocument == null)
            {
                return string.Empty;
            }

            string nodePath = $"P:{property.DeclaringType.FullName}.{property.Name}";
            XmlNode node = xmlDocument.SelectSingleNode($"//member[starts-with(@name, \"{nodePath}\")]/summary[1]");

            return node == null ? nodePath : node.InnerText.Trim();
        }

        #endregion

        #region Functions

        /// <summary>
        /// Loads the configuration, or creates a new one.
        /// </summary>
        /// <typeparam name="T">The configuration type.</typeparam>
        /// <returns>The configuration found, or a new configuration.</returns>
        public static T Load<T>() where T: ConfigurationCore, new()
        {
            string path = GetPathWithExtension(".json");

            if (File.Exists(path))
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    Error = (_, args) =>
                    {
                        Notification.Show($"~o~Warning~s~: Configuration issue found: {args.ErrorContext.Error.Message}");
                        args.ErrorContext.Handled = true;
                    }
                };

                string contents = File.ReadAllText(path);

                return JsonConvert.DeserializeObject<T>(contents, settings);
            }

            T configuration = new T();
            configuration.Save();
            return configuration;
        }
        /// <summary>
        /// Saves the configuration.
        /// </summary>
        public void Save()
        {
            string path = GetPathWithExtension(".json");
            string contents = JsonConvert.SerializeObject(this);
            File.WriteAllText(path, contents);
        }
        /// <summary>
        /// Creates the menus for a configuration menu.
        /// </summary>
        /// <returns>A list of menus used to create the configuration menu.</returns>
        /// <exception cref="InvalidOperationException">A property is not valid for a menu.</exception>
        public List<NativeMenu> CreateMenus()
        {
            Type type = GetType();
            string assemblyName = type.Assembly.GetName().Name;
            PropertyInfo[] properties = type.GetProperties();
            List<NativeMenu> menus = new List<NativeMenu>();

            NativeMenu mainMenu = new NativeMenu("", $"{assemblyName} Configuration", "", null);
            NativeItem save = new NativeItem("Save", "Saves the current configuration.");
            save.Activated += (_, _) =>
            {
                Save();
                Notification.Show("The Configuration was saved!");
            };
            menus.Add(mainMenu);

            foreach (PropertyInfo property in properties)
            {
                if (property.GetCustomAttribute<JsonPropertyAttribute>() == null)
                {
                    continue;
                }

                string name = FormatName(property.Name);
                string description = GetSummary(property);

                if (property.PropertyType == typeof(int))
                {
                    NativeItem intItem = new NativeItem(name, description);
                    intItem.AltTitle = ((int)property.GetValue(this)).ToString(CultureInfo.InvariantCulture);

                    intItem.Activated += (_, _) =>
                    {
                        int current = (int)property.GetValue(this);
                        string input = Game.GetUserInput(current.ToString(CultureInfo.InvariantCulture));

                        if (int.TryParse(input, NumberStyles.None, CultureInfo.InvariantCulture, out int number))
                        {
                            property.SetValue(this, number);
                            intItem.AltTitle = number.ToString(CultureInfo.InvariantCulture);
                        }
                        else if (!string.IsNullOrWhiteSpace(input))
                        {
                            Screen.ShowSubtitle($"~r~{input} is not a valid floating integer!");
                        }
                    };

                    mainMenu.Add(intItem);
                }
                else if (property.PropertyType == typeof(float))
                {
                    NativeItem floatItem = new NativeItem(name, description);
                    floatItem.AltTitle = ((float)property.GetValue(this)).ToString(CultureInfo.InvariantCulture);

                    floatItem.Activated += (_, _) =>
                    {
                        float current = (float)property.GetValue(this);
                        string input = Game.GetUserInput(current.ToString(CultureInfo.InvariantCulture));

                        if (float.TryParse(input, NumberStyles.None | NumberStyles.Float, CultureInfo.InvariantCulture, out float number))
                        {
                            property.SetValue(this, number);
                            floatItem.AltTitle = number.ToString(CultureInfo.InvariantCulture);
                        }
                        else if (!string.IsNullOrWhiteSpace(input))
                        {
                            Screen.ShowSubtitle($"~r~{input} is not a valid floating point number!\nRemember to use dots instead of comas.");
                        }
                    };

                    mainMenu.Add(floatItem);
                }
                else if (property.PropertyType == typeof(bool))
                {
                    NativeCheckboxItem checkboxItem = new NativeCheckboxItem(name, description, (bool)property.GetValue(this));

                    checkboxItem.CheckboxChanged += (_, _) =>
                    {
                        property.SetValue(this, checkboxItem.Checked);
                    };

                    mainMenu.Add(checkboxItem);
                }
                else if (property.PropertyType.IsEnum)
                {
                    NativeListItem<Enum> enumItem = new NativeListItem<Enum>(name, description);

                    foreach (Enum value in Enum.GetValues(property.PropertyType))
                    {
                        if (!enumItem.Items.Contains(value))
                        {
                            enumItem.Add(value);
                        }
                    }

                    enumItem.SelectedItem = (Enum) property.GetValue(this);

                    mainMenu.Add(enumItem);
                }
                else if (property.PropertyType.GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>)))
                {
                    Type listType = property.PropertyType.GetGenericArguments()[0];
                    IEnumerable existingItems = property.GetValue(this) as IEnumerable;

                    if (!listType.IsEnum || existingItems == null)
                    {
                        throw new InvalidOperationException($"Unexpected List generic type {property.PropertyType}");
                    }

                    NativeMenu submenu = new NativeMenu("", name, description, null);
                    List<Enum> current = existingItems.OfType<Enum>().ToList();

                    foreach (Enum value in Enum.GetValues(listType))
                    {
                        NativeCheckboxItem addedItem = new NativeCheckboxItem(value.ToString(), "", current.Contains(value));
                        addedItem.Tag = value;
                        addedItem.CheckboxChanged += (_, _) =>
                        {
                            IList values = (IList)Activator.CreateInstance(property.PropertyType);
                            foreach (NativeItem item in submenu.Items)
                            {
                                NativeCheckboxItem checkboxItem = (NativeCheckboxItem)item;
                                if (checkboxItem.Checked)
                                {
                                    values.Add((Enum)checkboxItem.Tag);
                                }
                            }
                            property.SetValue(this, values);
                        };
                        submenu.Add(addedItem);
                    }

                    menus.Add(submenu);
                    mainMenu.AddSubMenu(submenu);
                }
                else
                {
                    throw new InvalidOperationException($"Unexpected type {property.PropertyType}");
                }
            }

            mainMenu.Add(save);

            return menus;
        }

        #endregion
    }
}
