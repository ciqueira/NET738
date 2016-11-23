using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magno.Ciqueira.Atividade.NET738
{
    public enum ModelEnunWeekType
    {
        Weekend,
        NormalDay
    }

    public class ModelCar
    {
        public string NameCar { get; set; }
    }

    public class ModelStore
    {
        public ModelStore()
        {
            Rates = new List<ModelTax>();
            Cars = new List<ModelCar>();
        }

        public string LocationName { get; set; }
        public List<ModelTax> Rates { get; set; }
        public List<ModelCar> Cars { get; set; }

    }

    public class ModelTax
    {
        public ModelEnunWeekType WeekType { get; set; }
        public decimal valueTax { get; set; }
        public string clientType { get; set; }
    }


    public abstract class Store
    {
        public abstract void SearchCar(string clientType, int limitPassenger, List<string> dates);
    }

    public class SouthCar : Store
    {
        private ModelStore modelStore;
        public SouthCar()
        {
            var taxNormalDay = new ModelTax { clientType = "Normal", valueTax = 210, WeekType = ModelEnunWeekType.NormalDay };
            var taxPremiumDay = new ModelTax { clientType = "Premium", valueTax = 150, WeekType = ModelEnunWeekType.NormalDay };
            var taxNormalWeekend = new ModelTax { clientType = "Normal", valueTax = 200, WeekType = ModelEnunWeekType.Weekend };
            var taxPremiumWeekend = new ModelTax { clientType = "Premium", valueTax = 90, WeekType = ModelEnunWeekType.Weekend };

            var car1 = new ModelCar { NameCar = "Compacto Car1" };
            var car2 = new ModelCar { NameCar = "Compacto Car2" };
            var car3 = new ModelCar { NameCar = "Compacto Car3" };
            var car4 = new ModelCar { NameCar = "Compacto Car4" };

            modelStore = new ModelStore()
            {
                LocationName = "SouthCar",
                Cars = { car1, car2, car3, car4 },
                Rates = { taxNormalDay, taxPremiumDay, taxNormalWeekend, taxPremiumWeekend }
            };
        }

        public override void SearchCar(string clientType, int limitPassenger, List<string> dates)
        {
            if (limitPassenger > 2 && limitPassenger <= 4)
            {
                var query = from c in modelStore.Rates
                            where c.WeekType.Equals(ModelEnunWeekType.NormalDay) && c.clientType.Equals(clientType)
                            select c;
            }
        }
    }

    public class WestCar : Store
    {
        private ModelStore modelStore;
        public WestCar()
        {
            var taxNormalDay = new ModelTax { clientType = "Normal", valueTax = 530, WeekType = ModelEnunWeekType.NormalDay };
            var taxPremiumDay = new ModelTax { clientType = "Premium", valueTax = 150, WeekType = ModelEnunWeekType.NormalDay };
            var taxNormalWeekend = new ModelTax { clientType = "Normal", valueTax = 200, WeekType = ModelEnunWeekType.Weekend };
            var taxPremiumWeekend = new ModelTax { clientType = "Premium", valueTax = 90, WeekType = ModelEnunWeekType.Weekend };

            var car1 = new ModelCar { NameCar = "Esportivo Car1" };
            var car2 = new ModelCar { NameCar = "Esportivo Car2" };
            var car3 = new ModelCar { NameCar = "Esportivo Car3" };
            var car4 = new ModelCar { NameCar = "Esportivo Car4" };

            modelStore = new ModelStore
            {
                LocationName = "SouthCar",
                Cars = { car1, car2, car3, car4 },
                Rates = { taxNormalDay, taxPremiumDay, taxNormalWeekend, taxPremiumWeekend }
            };
        }

        public override void SearchCar(string clientType, int limitPassenger, List<string> dates)
        {
            if (limitPassenger > 0 && limitPassenger <= 2)
            {
                var query = from c in modelStore.Rates
                            where c.WeekType.Equals(ModelEnunWeekType.NormalDay) && c.clientType.Equals(clientType)
                            select c;
            }
        }
    }

    public class NorthCar : Store
    {
        private ModelStore modelStore;
        public NorthCar()
        {
            var taxNormalDay = new ModelTax { clientType = "Normal", valueTax = 630, WeekType = ModelEnunWeekType.NormalDay };
            var taxPremiumDay = new ModelTax { clientType = "Premium", valueTax = 580, WeekType = ModelEnunWeekType.NormalDay };
            var taxNormalWeekend = new ModelTax { clientType = "Normal", valueTax = 600, WeekType = ModelEnunWeekType.Weekend };
            var taxPremiumWeekend = new ModelTax { clientType = "Premium", valueTax = 590, WeekType = ModelEnunWeekType.Weekend };

            var car1 = new ModelCar { NameCar = "SUV Car1" };
            var car2 = new ModelCar { NameCar = "SUV Car2" };
            var car3 = new ModelCar { NameCar = "SUV Car3" };
            var car4 = new ModelCar { NameCar = "SUV Car4" };

            modelStore = new ModelStore
            {
                LocationName = "SouthCar",
                Cars = { car1, car2, car3, car4 },
                Rates = { taxNormalDay, taxPremiumDay, taxNormalWeekend, taxPremiumWeekend }
            };
        }

        public override void SearchCar(string clientType, int limitPassenger, List<string> dates)
        {
            if (limitPassenger > 4 && limitPassenger <= 7)
            {
                var query = from c in modelStore.Rates
                            where c.WeekType.Equals(ModelEnunWeekType.NormalDay) && c.clientType.Equals(clientType)
                            select c;
            }
        }
    }

    public interface IStoreService
    {
        string SearchCar(string clientType, int limitPassenger, List<string> dates);
    }

    public class StoreService : IStoreService
    {
        public string SearchCar(string clientType, int limitPassenger, List<string> dates)
        {
            var listCars = new List<string>();
            List<Store> Customers = new List<Store>();
            Customers.Add(new SouthCar());
            Customers.Add(new WestCar());
            Customers.Add(new NorthCar());

            //var teste = Customers.Select(c => new { c.SearchCar(clientType, limitPassenger, dates) });

            //foreach (var item in Customers)
            //{
            //    item.SearchCar(clientType, limitPassenger, dates);
            //}

            return "";
        }
    }



    class Program
    {


        static void Main(string[] args)
        {
            IStoreService _repo = new StoreService();
            Console.WriteLine(_repo.SearchCar("Normal", 1, new List<string> { "16Mar2009", "17Mar2009", "18Mar2009" }));
            Console.WriteLine(_repo.SearchCar("Premium", 6, new List<string> { "01Set2009", "02Set2009" }));
            Console.ReadKey();
        }
    }
}
