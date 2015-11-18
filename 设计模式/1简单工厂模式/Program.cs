using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1简单工厂模式
{
    //简单工厂模式又称之为静态工厂方法，属于创建型模式。
    //在简单工厂模式中，可以根据传递的参数不同，返回不同类的实例。
    //简单工厂模式定义了一个类，这个类专门用于创建其他类的实例，这些被创建的类都有一个共同的父类。
    class Program
    {
        static void Main(string[] args)
        {
            //var op = Factory.GetOperat("add");
            //op.NumberA = 5;
            //op.NumberB = 10;
            //Double result= op.GetResult();
            //Console.WriteLine("result"+result);
            var op1= Factory.GetOperat("sub");
            op1.NumberA = 10;
            op1.NumberB = 10;
            Double result1 = op1.GetResult();
            Console.WriteLine("result1" + result1);
            Console.ReadKey();
        }
    }

    //定义一个抽象结构体
    abstract class Operat
    {
        public Double NumberA { get; set; }
        public Double NumberB { get; set; }
        //声明虚方法
        public virtual Double GetResult()
        {
            return 0;
        }
    
    }
    //实体类
    class Add : Operat
    {
        public override double GetResult()
        {
            return NumberA + NumberB;
        }
    }
    class Sub : Operat
    {
        public override double GetResult()
        {
            return this.NumberA - this.NumberB;
        }
    }

    /// <summary>
    /// 工厂类
    /// </summary>
    class Factory
    {
        public static Operat GetOperat( String flag)
        {
            switch (flag)
            { 
                case "add":return new Add();
                case"sub":return new Sub();
                default: return null;

            }
        }
    }
}
