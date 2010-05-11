using Microsoft.WindowsMobile.Status;

namespace PowerAwareBluetooth.Model
{
    internal class BatteryAdapter
    {
        // TODO: TAL - use BatteryLow && BatteryCharching properties instead - done
        public int BatteryPercentage
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// indicates if the Battery level in the device is low
        /// </summary>
        public bool BatteryLow
        {
            //TODO: ADAM : check this logic - should this be && or || ?
            get
            {
                return
                    SystemState.PowerBatteryState == BatteryState.Low &&
                    SystemState.PowerBatteryState == BatteryState.Critical;
            }
        }

        /// <summary>
        /// indicates if the device is charging
        /// </summary>
        public bool BatteryCharching
        {

            get
            {
                return ((SystemState.PowerBatteryState & BatteryState.Charging) == BatteryState.Charging);
            }
            
        }
    }
}
