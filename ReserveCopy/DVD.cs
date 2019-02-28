using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveCopy
{
    public enum DVDType { oneSided, twoSided}
    public class DVD : Storage
    {
        public DVD(double capacity):base(capacity)
        {

        }
        public DVD(double capacity, string name, string model, double speedRead,
            double speedWrite, DVDType DVDType) : base(capacity)
        {                  
            this.name = name;
            this.model = model;            
            this.speedWrite = speedWrite;
            this.speedRead = speedRead;
            this.DVDType = DVDType;
        }

        public double speedRead { get; set; }
        public double speedWrite { get; set; }
        public DVDType DVDType { get; set; }
        
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
                double tmp = volume / this.speedWrite;
                time = TimeSpan.FromMinutes(tmp);
               
            }
            return time;
        }
    }
}
