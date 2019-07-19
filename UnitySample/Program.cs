using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;

namespace UnitySample
{
    public class Customer
    {
        IDataAccess _customerDataAccess { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public Customer(){ }

        public Customer(IDataAccess customerDataAccess)
        {
            _customerDataAccess = customerDataAccess;
        }

        public void Save()
        {
            _customerDataAccess.Save(this);
        }
    }

    public interface IDataAccess
    {
        void Save(Customer c);
    }

    public class Sql : IDataAccess
    {
        public void Save(Customer c)
        {
            Console.WriteLine("{2}, Save data id: {0} name: {1}", c.Id, c.Name, this.GetType().ToString());
        }
    }

    public class Mysql : IDataAccess
    {
        public void Save(Customer c)
        {
            Console.WriteLine("{2}, Save data id: {0} name: {1}", c.Id, c.Name, this.GetType().ToString());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Customer temp = new Customer() { Id = "1", Name = "Roy" };

            Customer sql1 = new Customer(new Sql());
            Customer mysql1 = new Customer(new Mysql());

            sql1.Save();
            mysql1.Save();

            var container = new UnityContainer();
            UnitySetUp.Config(container);

            var sql = container.Resolve<Customer>();
            var mysql = container.Resolve<Customer>("mysqlCustomer");


            sql.Save();
            mysql.Save();

            var sql2 = UnityIocHelper.Instance.GetService<IDataAccess>();
            var mysql2 = UnityIocHelper.Instance.GetService<IDataAccess>("mysql");


            sql2.Save(temp);
            mysql2.Save(temp);


            Console.ReadKey();
        }
    }

    public class UnitySetUp
    {
        public static void Config(IUnityContainer container)
        {
            container.RegisterType<IDataAccess, Sql>();
            container.RegisterType<IDataAccess, Mysql>("mysql");

            container.RegisterType<Customer>(new InjectionConstructor(new ResolvedParameter<IDataAccess>()));
            container.RegisterType<Customer>("mysqlCustomer",
                new InjectionConstructor(new ResolvedParameter<IDataAccess>("mysql")));
        }
    }
}
