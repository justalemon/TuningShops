using GTA;
using GTA.UI;

namespace TuningShops
{
    /// <summary>
    /// Tools used to charge the player for the modifications.
    /// </summary>
    internal static class Money
    {
        /// <summary>
        /// Charges the player a specific amount of money if possible.
        /// </summary>
        /// <param name="amount">The amount of money to charge.</param>
        /// <returns><see langword="true"/> if the player was charged, <see langword="false"/> otherwise.</returns>
        public static bool ChargeIfPossible(int amount)
        {
            if (Game.Player.Money < amount)
            {
                Screen.ShowSubtitle($"~r~You can't afford this modification!");
                return false;
            }

            Game.Player.Money -= amount;
            return true;
        }
    }
}
