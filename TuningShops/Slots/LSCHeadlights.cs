using GTA;
using GTA.Native;
using TuningShops.Core;
using TuningShops.Items;

namespace TuningShops.Slots
{
    /// <summary>
    /// Menu used for specifically changing Xenon Lights.
    /// </summary>
    public class LSCHeadlights : LosSantosCustoms
    {
        #region Properties

        /// <summary>
        /// If the menu should be repopulated.
        /// </summary>
        public override bool ShouldRepopulate => false;

        #endregion

        #region Constructors

        public LSCHeadlights() : base(22, "Headlights")
        {
            Add(new HeadlightsItem("CMOD_LGT_0", false, -1));
            Add(new HeadlightsItem("CMOD_LGT_1", true, -1));
            Add(new HeadlightsItem("CMOD_LGT_2", true, 0));
            Add(new HeadlightsItem("CMOD_LGT_3", true, 1));
            Add(new HeadlightsItem("CMOD_LGT_4", true, 2));
            Add(new HeadlightsItem("CMOD_LGT_5", true, 3));
            Add(new HeadlightsItem("CMOD_LGT_6", true, 4));
            Add(new HeadlightsItem("CMOD_LGT_7", true, 5));
            Add(new HeadlightsItem("CMOD_LGT_8", true, 6));
            Add(new HeadlightsItem("CMOD_LGT_9", true, 7));
            Add(new HeadlightsItem("CMOD_LGT_10", true, 8));
            Add(new HeadlightsItem("CMOD_LGT_11", true, 9));
            Add(new HeadlightsItem("CMOD_LGT_12", true, 10));
            Add(new HeadlightsItem("CMOD_LGT_13", true, 11));
            Add(new HeadlightsItem("CMOD_LGT_14", true, 12));
        }

        #endregion

        #region Functions

        /// <summary>
        /// Checks if the vehicle can use the Headlights option.
        /// </summary>
        /// <param name="vehicle">The vehicle to check.</param>
        /// <returns>true if the vehicle can use headlights, false otherwise.</returns>
        public override bool CanUse(Vehicle vehicle)
        {
            Model model = vehicle.Model;
            return model.IsVehicle || model.IsBike;
        }
        /// <inheritdoc/>
        public override void SelectCurrent(Vehicle vehicle)
        {
        }

        #endregion
    }
}
