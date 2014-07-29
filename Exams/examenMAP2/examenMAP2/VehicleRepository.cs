using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace examenMAP2
{   [Serializable]
    class VehicleRepository<T>:Repository<T>
    {
        List<T> repo = new List<T>();

        public void addVehicle(T element){
            this.repo.Add(element);
            
        }

        public List<T> getAll()
        {
            return this.repo;
        }

        
    }
}
