/**
 * Author : Manikandan M
 * Description : Sample program for bridge pattern
 */
using System;
using System.Threading;

namespace BridgePattern
{
    class Program
    {
        /// <summary>
        /// 'Abstraction' class
        /// </summary>
        abstract class Switch
        {
            public ICommercialHomeAppliance commercialHomeAppliance;
            public abstract void TurnOn();
            public abstract void TurnOff();
        }

        /// <summary>
        /// 'RefinedAbstraction' class
        /// </summary>
        class AutomaticRemoteController: Switch
        {
            public override void TurnOn()
            {
                commercialHomeAppliance.Start("240 V"); //default voltage
            }

            public override void TurnOff()
            {
                commercialHomeAppliance.Stop("240 V");
            }
        }

        /// <summary>
        /// 'RefinedAbstraction' class
        /// </summary>
        class ManualRemoteController : Switch
        {
            public string VoltageController { get; set; }

            public override void TurnOn()
            {
                commercialHomeAppliance.Start(VoltageController); //manual voltage
            }

            public override void TurnOff()
            {
                commercialHomeAppliance.Stop(VoltageController);
            }
        }

        /// <summary>
        /// 'Bridge' Interface
        /// </summary>
        interface ICommercialHomeAppliance
        {
            void Start(string voltage);
            void Stop(string voltage);
        }

        /// <summary>
        /// 'ConcreteImplementation' class
        /// </summary>
        class AC : ICommercialHomeAppliance
        {
            private string name;
            public AC(string name)
            {
                this.name = name;
            }

            public void Start(string voltage)
            {
                Console.WriteLine(string.Format("{0} is started. Time: {1}, Voltage: {2}", this.name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"), voltage));
            }

            public void Stop(string voltage)
            {
                Console.WriteLine(string.Format("{0} is stoped. Time: {1}, Voltage: {2}", this.name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"), voltage));
            }
        }

        /// <summary>
        /// 'ConcreteImplementation' class
        /// </summary>
        class Refrigerator : ICommercialHomeAppliance
        {
            private string name;
            public Refrigerator(string name)
            {
                this.name = name;
            }

            public void Start(string voltage)
            {
                Console.WriteLine(string.Format("{0} is started. Time: {1}, Voltage: {2}", this.name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"), voltage));
            }

            public void Stop(string voltage)
            {
                Console.WriteLine(string.Format("{0} is stoped. Time: {1}, Voltage: {2}", this.name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"), voltage));
            }
        }

        /// <summary>
        /// 'ConcreteImplementation' class
        /// </summary>
        class Fan : ICommercialHomeAppliance
        {
            private string name;
            public Fan(string name)
            {
                this.name = name;
            }

            public void Start(string voltage)
            {
                Console.WriteLine(string.Format("{0} is started. Time: {1}, Voltage: {2}", this.name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"), voltage));
            }

            public void Stop(string voltage)
            {
                Console.WriteLine(string.Format("{0} is stoped. Time: {1}, Voltage: {2}", this.name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"), voltage));
            }
        }

        /// <summary>
        /// 'ConcreteImplementation' class
        /// </summary>
        class GateOpener : ICommercialHomeAppliance
        {
            private string name;
            public GateOpener(string name)
            {
                this.name = name;
            }

            public void Start(string voltage)
            {
                Console.WriteLine(string.Format("{0} is started. Time: {1}, Voltage: {2}", this.name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"), voltage));
            }

            public void Stop(string voltage)
            {
                Console.WriteLine(string.Format("{0} is stoped. Time: {1}, Voltage: {2}", this.name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"), voltage));
            }
        }

        /// <summary>
        /// 'ConcreteImplementation' class
        /// </summary>
        class Tv : ICommercialHomeAppliance
        {
            private string name;
            public Tv(string name)
            {
                this.name = name;
            }

            public void Start(string voltage)
            {
                Console.WriteLine(string.Format("{0} is started. Time: {1}, Voltage: {2}", this.name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"), voltage));
            }

            public void Stop(string voltage)
            {
                Console.WriteLine(string.Format("{0} is stoped. Time: {1}, Voltage: {2}", this.name, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff"), voltage));
            }
        }

        static void Main(string[] args)
        {
            int delayMilliseconds = 2000;
            ICommercialHomeAppliance ac = new AC("MicroMax Star Split AC");
            ICommercialHomeAppliance refrigerator = new Refrigerator("LG Single Door Refrigerator");
            ICommercialHomeAppliance fan = new Fan("Usha Fan");
            ICommercialHomeAppliance tv = new Tv("Panasonic TV");
            ICommercialHomeAppliance gateopener = new GateOpener("GPS 3G Gate Door Opener");

            //automatic remote controller
            Switch automaticRemoteSwitch = new AutomaticRemoteController();
            Console.WriteLine("---------------------------Automated Remote Controller---------------------------");
            //control gate opener
            automaticRemoteSwitch.commercialHomeAppliance = gateopener;
            automaticRemoteSwitch.TurnOn();
            Thread.Sleep(delayMilliseconds);
            automaticRemoteSwitch.TurnOff();
            Console.WriteLine("---------------------------------------------------------------------------------");

            //manual remote controller
            ManualRemoteController manualRemoteSwitch = new ManualRemoteController();
            Console.WriteLine("---------------------------Manual Remote Controller------------------------------");
            manualRemoteSwitch.VoltageController = "220 V";
            //control ac
            manualRemoteSwitch.commercialHomeAppliance = ac;
            manualRemoteSwitch.TurnOn();
            Thread.Sleep(delayMilliseconds);
            manualRemoteSwitch.TurnOff();

            //control refrigerator
            manualRemoteSwitch.commercialHomeAppliance = refrigerator;
            manualRemoteSwitch.TurnOn();
            Thread.Sleep(delayMilliseconds);
            manualRemoteSwitch.TurnOff();

            //control fan
            manualRemoteSwitch.commercialHomeAppliance = fan;
            manualRemoteSwitch.TurnOn();
            Thread.Sleep(delayMilliseconds);
            manualRemoteSwitch.TurnOff();

            //control tv
            manualRemoteSwitch.commercialHomeAppliance = tv;
            manualRemoteSwitch.TurnOn();
            Thread.Sleep(delayMilliseconds);
            manualRemoteSwitch.TurnOff();
            Console.WriteLine("---------------------------------------------------------------------------------");

            Console.Write("Press any key to exist...");
            Console.ReadKey();
        }
    }
}
