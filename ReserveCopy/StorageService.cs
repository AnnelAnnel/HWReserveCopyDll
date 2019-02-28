using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReserveCopy
{
    public class StorageService
    {
        public List<Storage> storages = new List<Storage>();
      
        public double getTotalCapacity()
        {
            double sum = 0;
            for (int i = 0; i < storages.Count; i++)
            {
                sum += storages[i].getCapacity();
            }
            return sum;
        }        
        
    }
}
