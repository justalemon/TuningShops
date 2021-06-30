using GTA;
using LemonUI;
using System;
using System.Collections.Generic;
using TuningShops.Core;
using TuningShops.Slots;

namespace TuningShops
{
    /// <summary>
    /// The main class that handles the Tuning Shop features.
    /// </summary>
    public class TuningShops : Script
    {
        #region Fields

        private static readonly Dictionary<string, BaseType> menus = new Dictionary<string, BaseType>();
        private static readonly ObjectPool pool = new ObjectPool();
        private static readonly MainMenu main = new MainMenu();

        #endregion

        #region Constructor

        public TuningShops()
        {
            List<BaseType> created = new List<BaseType>()
            {
                new BOMWAerials(),
                new BOMWAirFilter(),
                new BOMWArchCovers(),
                new BOMWDashboard(),
                new BOMWDials(),
                new BOMWDoors(),
                new BOMWEngineBlock(),
                new BOMWLivery(),
                new BOMWOrnaments(),
                new BOMWPlaque(),
                new BOMWPlateHolder(),
                new BOMWShifterLeaver(),
                new BOMWSpeakers(),
                new BOMWSeats(),
                new BOMWSteeringWheel(),
                new BOMWStruts(),
                new BOMWTank(),
                new BOMWTrim(),
                new BOMWTrim2(),
                new BOMWTrunk(),
                new BOMWVanityPlate(),
                new BOMWWindows(),

                new Liveries(),

                new LSCArmor(),
                new LSCBrakes(),
                new LSCBumperFront(),
                new LSCBumperRear(),
                new LSCEngine(),
                new LSCExhaust(),
                new LSCFender(),
                new LSCFenderRight(),
                new LSCRollCage(),
                new LSCGrille(),
                new LSCHeadlights(),
                new LSCHood(),
                new LSCHorns(),
                new LSCRoof(),
                new LSCSideSkirt(),
                new LSCSpoilers(),
                new LSCSuspension(),
                new LSCTransmission(),
                new LSCTireSmoke(),
                new LSCWheels(),
                new LSCWheelsRear(),

                new TerrorbyteTint(),
                new TerrorbyteDecal(),
                new TerrorbyteTurretStation(),
                new TerrorbyteDroneStation(),
                new TerrorbyteWeaponWorkshop(),
                new TerrorbyteSpecializedWorkshop(),
            };

            foreach (BaseType @base in created)
            {
                Type type = @base.GetType();
                menus.Add(type.FullName, @base);

                pool.Add(@base);

                main.AddMenu(@base);  // TODO: Make this dynamic
            }

            Tick += TuningShops_Tick;

            pool.Add(main);
        }

        #endregion

        #region Events

        private void TuningShops_Tick(object sender, EventArgs e)
        {
            if (Game.IsControlJustPressed(Control.MultiplayerInfo))
            {
                if (pool.AreAnyVisible)
                {
                    pool.HideAll();
                }
                else
                {
                    main.Visible = true;
                }
            }

            pool.Process();
        }

        #endregion
    }
}
