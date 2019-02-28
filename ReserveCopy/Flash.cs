using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveCopy
{
    public enum USBType { USB20, USB30 }
    public class Flash: Storage
    {
        public Flash(double capacity, string name, string model, double speed, 
            USBType USBType) : base(capacity)
        {
            this.speed = speed;
            this.USBType = USBType;
            this.name = name;
            this.model = model;            
        }
        public USBType USBType { get; set; }
        public double speed { get; set; }

        public override TimeSpan getCopyTime(double volume)
        {
            TimeSpan time;
            if (getFreeCapacity() < volume)
            {
                time = new TimeSpan(0, 0, 0);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Объем копируемых данных превышает доступную память устройства");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                double tmp = volume / this.speed;
                time = TimeSpan.FromMinutes(tmp);
            }
            return time;
        }

    }
}
