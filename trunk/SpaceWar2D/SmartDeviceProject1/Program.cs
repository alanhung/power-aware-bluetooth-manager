using System;
using System.Windows.Forms;
using PowerAwareBluetooth.Controller.Manager;
using PowerAwareBluetooth.View;

namespace PowerAwareBluetooth
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
//        [MTAThread]
//        static void Main()
//        {
//            Application.Run(new MainForm());
//        }

        static void Main()
        {
            BluetoothPowerManager bluetoothPowerManager = new BluetoothPowerManager();
            bluetoothPowerManager.Start();
        }
    }
}