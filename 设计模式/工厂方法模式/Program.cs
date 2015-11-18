using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1工厂方法模式
{
    /// Factory Method
    /// 工厂模式存在类与switch语句的高耦合，增加新的类 需要去增加case分支，违背了开放-封闭原则
    /// 工厂方法模式可以解决这个问题。
    class Program
    {
        static void Main(string[] args)
        {
            SubFactory sf = new SubFactory();
            Operator op = sf.CreateOperator();
            op.NumberA = 10;
            op.NumberB = 5;
            op.GetResult();
            Console.WriteLine("结果为：--" + op.GetResult());
            Console.ReadKey();

        }
    }
    //定义抽象类
    public abstract class Operator
    {
        public double NumberA;
        public double NumberB;
        public virtual double GetResult()
        {
            return 0;
        }
    }

    public class Add1 : Operator
    {
        public override double GetResult()
        {
            return NumberA + NumberB;
        }
    }
    public class Sub1 : Operator
    {
        public override double GetResult()
        {
            return NumberA - NumberB;
        }
    }

    //定义一个接口
    interface IFactory
    {
        Operator CreateOperator();
    }
    class AddFactory : IFactory
    {
        public Operator CreateOperator()
        {
            return new Add1();
        }
    }
    class SubFactory : IFactory
    {
        public Operator CreateOperator()
        {
            return new Sub1();
        }
    }
}
