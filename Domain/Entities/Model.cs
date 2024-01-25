using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Model:Entity<Guid>
    {
        public Guid BrandId { get; set; }
        public Guid FuelId { get; set; }
        public Guid TransmissonId { get; set; }
        public string Name { get; set; }    
        public decimal DailyPrice { get; set; }
        public string ImageUrl { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual Fuel? Fuel { get;}
        public virtual Transmission? Transmisson { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

        public Model()
        {
            Cars = new HashSet<Car>();
        }

        public Model(Guid id, Guid brandId, Guid fuelId, Guid transmissonId, string name, decimal dailyPrice, string imageUrl):this() 
        {
            Id = id;
            BrandId = brandId;
            FuelId = fuelId;
            TransmissonId = transmissonId;
            Name = name;
            DailyPrice = dailyPrice;
            ImageUrl = imageUrl;


        }
    }
}
