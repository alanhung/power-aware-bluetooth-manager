using PowerAwareBluetooth.Controller.Manager;

namespace PowerAwareBluetooth
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[MTAThread]
        //static void Main()
        //{
        //    Application.Run(new MainForm());
        //}

        static void Main()
        {
            BluetoothPowerManager bluetoothPowerManager = new BluetoothPowerManager();
            bluetoothPowerManager.Start();
        }
    }
}