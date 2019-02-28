using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveCopy
{
    public class HDD : Storage
    {
        public HDD(double capacity, string name, string model, int sectionsCount, 
            double sectionsVolume, USBType USBType) : base(capacity)
        {           
            this.name = name;
            this.model = model;
            this.sectionsCount = sectionsCount;
            this.sectionsVolume = sectionsVolume;
            this.USBType = USBType;
        }

        public int sectionsCount { get; set; }
        public USBType USBType { get; set; }

        public double sectionsVolume { get; set; }

        public override TimeSpan getCopyTime(double volume)
        {
            TimeSpan time;
            if (getFreeCapacity() < volume)
            {
                time = new TimeSpan(0, 0, 0);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Объем копируемых данных превышает емкость устройства");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                double tmp = volume / 7200;  //оборотов в минуту 
                time = TimeSpan.FromMinutes(tmp);
            }
            return time;
        }
    }
}
