using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_Event
{
    // Heater
    public class Heater
    {
        private int temperature;
        public delegate void BoilHandler(int temp);
        // declare a Event via delegate
        public event BoilHandler BoilEvent;

        public void Boil()
        {
            for (int i = 96; i < 101; ++i)
            {
                temperature = i;
                if (BoilEvent != null)
                    BoilEvent(temperature);
            }
        }
    }
    // Alarm
    public class Alarm
    {
        public void AlarmSometing(int temp)
        {
            Console.WriteLine("Alarm:water's tempetature:{0}", temp);
        }
    }
    // Dispaly
    public class Dispaly
    {
        public static void DisplaySomething(int temp)
        {
            Console.WriteLine("Display water tempetature:{0}", temp);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Heater heater = new Heater();
            //heater.BoilEvent += (new Alarm()).AlarmSometing();
            Alarm a = new Alarm();
            heater.BoilEvent += a.AlarmSometing;
            heater.BoilEvent += Dispaly.DisplaySomething;
            heater.Boil();
        }
    }
}
