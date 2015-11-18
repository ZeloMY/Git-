using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2抽象工厂方法
{
    /// <summary>
    /// Abstract Factory（抽象工厂）
    /// 抽象工厂方法
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IFactoryDatabase factory = new SqlServerFac();
            IDepartMent sqlServer = factory.GetInstance();
            sqlServer.Insert("helloworld!");


            IFactoryDatabase acfactory = new AccessFac();
            IDepartMent acServer = acfactory.GetInstance();
            acServer.Insert("helloworld!");
            Console.ReadKey();


        }
    }
    interface IDepartMent
    {
        void Insert(string sql);//在数据库中插入一条记录
    }
    class SqlServer : IDepartMent
    {
        public void Insert(string sql)
        {
            Console.WriteLine("sqlServer执行sql插入语句！");
        }
    }

    class Access : IDepartMent
    {
        public void Insert(string sql)
        {
            Console.WriteLine("Access执行sql插入语句！");
        }
    }

    interface IFactoryDatabase
    {
        IDepartMent GetInstance();
    }

    class SqlServerFac : IFactoryDatabase
    {
        public IDepartMent GetInstance()
        {
            return new SqlServer();
        }
    }

    class AccessFac : IFactoryDatabase
    {
        public IDepartMent GetInstance()
        {
            return new Access();
        }
    }

}
