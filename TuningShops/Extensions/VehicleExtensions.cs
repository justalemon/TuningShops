using GTA;
using GTA.Native;

namespace TuningShops.Extensions
{
    /// <summary>
    /// Extensions used for vehicles, trailers and others related.
    /// </summary>
    public static class VehicleExtensions
    {
        /// <summary>
        /// Gets the trailer of a big rig.
        /// </summary>
        /// <param name="vehicle">The vehicle trailer hooked to the vehicle.</param>
        /// <returns>The trailer being hooked, null if there is none.</returns>
        public static Vehicle GetTrailer(this Vehicle vehicle)
        {
            if (vehicle == null)
            {
                return null;
            }

            OutputArgument trailer = new OutputArgument();
            if (Function.Call<bool>(Hash.GET_VEHICLE_TRAILER_VEHICLE, vehicle, trailer))
            {
                return trailer.GetResult<Vehicle>();
            }

            return null;
        }
    }
}
