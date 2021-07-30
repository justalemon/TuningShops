using GTA.Native;
using GTA;

namespace TuningShops.Core
{
    /// <summary>
    /// Menu options for special vehicles like the Terrorbyte.
    /// </summary>
    public abstract class SpecialVehicle : BaseType
    {
        #region Properties

        /// <summary>
        /// The name of the decorator used by this modification.
        /// </summary>
        public abstract string DecoratorName { get; }
        /// <inheritdoc/>
        public override int ModValue
        {
            get
            {
                Vehicle vehicle = Game.Player.Character.CurrentVehicle;

                if (!Function.Call<bool>(Hash.DECOR_EXIST_ON, vehicle, DecoratorName))
                {
                    return 0;
                }

                return Function.Call<int>(Hash.DECOR_GET_INT, vehicle, DecoratorName);
            }
            set => Function.Call(Hash.DECOR_SET_INT, Game.Player.Character.CurrentVehicle, DecoratorName, value);
        }

        #endregion

        #region Constructor

        public SpecialVehicle(string title) : base(title)
        {
        }

        #endregion
    }
}
