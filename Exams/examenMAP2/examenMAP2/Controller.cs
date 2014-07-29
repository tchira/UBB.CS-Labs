using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace examenMAP2
{
    class Controller
    {
        public Repository<Vehicle> repo;

        public Controller(Repository<Vehicle> r)
        {   
            this.repo = r;
            
        }

        public void addVehicle(Vehicle v)
        {
            this.repo.addVehicle(v);
            this.serialize();
            this.deserialize();
        }

        public List<Vehicle> getAll()
        {
            return this.repo.getAll();
        }

        public void serialize()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("strepo.out", FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, repo);
            stream.Close();
        }

        public void deserialize()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("strepo.out", FileMode.Open, FileAccess.Read);
            repo = (VehicleRepository<Vehicle>)formatter.Deserialize(stream);
            stream.Close();
        }
    }
}
