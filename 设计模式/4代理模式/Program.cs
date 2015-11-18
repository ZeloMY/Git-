using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12代理模式
{
    //什么是代理模式：本来有一个类A可以直接执行自己的方法就可以实现一个功能，
    //现在先将这个类A作为一个属性传递给一个代理类，代理类在通过自己的方法调用A对象的方法，同时可以添加一些新的功能
    // 为其他对象提供一种代理，用来控制对这个对象的访问。
    class Program
    {
        static void Main(string[] args)
        {
             var cla1=new  Pursuit();
             var cla2 = new Proxy(cla1);
             cla2.GiveDolls();

             Console.ReadKey();


        }
    }
    //接口
    public interface IGiveGift
    {
        void GiveDolls();
        void GiveFlowers();
    }
    //定义一个类继承接口
    public class Pursuit : IGiveGift
    {
        public void GiveDolls()
        {
            Console.WriteLine("Give Dolls");
        }
        public void GiveFlowers()
        {
            Console.WriteLine("Give Flowers");
        }
    }
    //代理类
    public class Proxy : IGiveGift
    {
        private IGiveGift IGift;
        public Proxy(IGiveGift iGift)
        {
            this.IGift = iGift;
        }
        public void GiveDolls()
        {
            IGift.GiveFlowers();
            Console.WriteLine("proxy can do some badthing in this lol");
        }
        public void GiveFlowers()
        {
            IGift.GiveFlowers();
            Console.WriteLine("hello beauty,the flower is mine,not his");
        }
    }
}
