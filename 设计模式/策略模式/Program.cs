using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 策略模式
{
    ///什么是策略模式？
    /// 策略模式就是在简单工厂模式的基础上，对factory内部同时封装具体的子类的方法实现，
    /// 但是策略模式和工厂模式 还是没从根本上消除switch语句
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Context_Cl("1");
            c.GetResult(1, 6);//这里调用相对于简单工厂模式就更加统一了
            Console.WriteLine("result1---" + c.GetResult(1, 6));

            var d = new Context_Cl("2");
            d.GetResult(6, 1);//这里调用相对于简单工厂模式就更加统一了
            Console.WriteLine("result2---" + d.GetResult(6,1));
            Console.ReadKey();
        }
    }

    //结构体
    abstract class Operat_Cl
    {
        public double NumberA { get; set; }
        public double NumberB { get; set; }

        public virtual double GetResult()
        {
            return 0;
        }
    }
    class Add_Cl : Operat_Cl
    {
        public Add_Cl(double numberA, double numberB)
        {
        }
        public Add_Cl()
        { }
        public override double GetResult()
        {
            return NumberA + NumberB;
        }
    }
    class Sub_Cl : Operat_Cl
    {
        public override double GetResult()
        {
            return NumberA - NumberB;
        }
    }
    class Context_Cl
    {
        //在内部对封装的具体子类方法进行实现
        public Operat_Cl oper { get; set; }
        public Context_Cl(string flag)
        {
            switch (flag)
            {
                case "1":
                    oper = new Add_Cl();
                    break;
                case "2":
                    oper = new Sub_Cl();
                    break;
                default: ;
                    break;
            }
        }
        public Double GetResult(double numberA, double numberB)
        {
            oper.NumberA = numberA;
            oper.NumberB = numberB;
            return oper.GetResult();
        }
    }
}
