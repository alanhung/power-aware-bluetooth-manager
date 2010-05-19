using System;
using System.Windows.Forms;
using PipeServer;
using PowerAwareBluetooth.Controller.Manager;
using PowerAwareBluetooth.Model;
using PowerAwareBluetooth.Model.NamedEvents;
using PowerAwareBluetooth.View;

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
//            Controller.IO.IOManager.Save(bluetoothPowerManager.RulesList);
//            RuleList ruleList = Controller.IO.IOManager.Load() as RuleList;
            bluetoothPowerManager.Start();
        }
    }
}