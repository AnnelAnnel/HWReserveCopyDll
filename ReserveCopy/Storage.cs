using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ReserveCopy
{
    public abstract class Storage

    {
        public Storage(double capacity)
        {
            this.capacity = capacity;         

        }
        public double memory { get; set; }
        protected string name { get; set; }
        protected string model { get; set; }
        private double capacity { get; set; }

        public virtual double getCapacity()
        {
            return capacity;
        }
        public virtual void copyInfo(double volume)
        {

            if (getFreeCapacity() < volume)
                throw new Exception("Недостаточно свободного места");
            else
            {
                for (int i = 0; i < getCopyTime(volume).Minutes; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(1000);
                }
                memory += volume;
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Копирование завершено");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public abstract TimeSpan getCopyTime(double volume);
       

        public virtual double getFreeCapacity()
        {
            return capacity - memory;
        }
        public virtual void printInfo()
        {
            Console.WriteLine("{0} ({1}) - {2} Gb", name, model, capacity);
        }

        public virtual string getInfo()
        {
            return string.Format("{0} ({1}) - {2} Gb", name, model, capacity);
        }



    }
}

