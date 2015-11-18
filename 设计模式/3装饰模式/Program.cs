﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _9装饰模式
{
    ///什么是装饰模式：动态的给一个对象添加一些额外的职责。
    /// 用法：有一个类A实现了一个接口Ia，可以将一个类B实现了接口Ib，
    /// 同时定义一个AddAAbout方法和Ia属性，用该方法接收一个实现了接口Ia的类，然后在类B内 调用A的方法或者属性。
    class Program
    {
        static void Main(string[] args)
        {
            var chinastyle = new ChinaStyleHouse();
            var oustyle = new OuStyle();
            oustyle.AddStyle(chinastyle);
            oustyle.Show();
            Console.ReadKey();
        }
    }
    /// <summary>
    /// 抽象对象接口
    /// </summary>
    abstract class House
    {
        //抽象方法  在子类中必须重写
        public abstract void Show();
    }
    /// <summary>
    /// 
    /// </summary>
    class PingFangHouse : House
    {
        public override void Show()
        {
            Console.WriteLine("这是平房");
        }
    }
    /// <summary>
    /// 
    /// </summary>
    abstract class LouFangHouse : House
    {
        public override void Show()
        {
            Console.WriteLine("这是楼房");
        }
    }
    class OuStyle : House
    {
        private House House;//1、将可能需要的一些别的类的定义在自己的类中，
        public override void Show()
        {
            Console.WriteLine("这是欧式风格");
            if (House != null)//调用通过AddStyle方法传进来的类的方法，就对类OuStyle实现了动态添加方法职能
                House.Show();
        }
        public void AddStyle(House house)//2、通过动态添加特定的实现了接口House的类，给OuStyle添加特定的实现了House接口的类，
        {
            this.House = house;
        }
    }
    /// <summary>
    /// 由于这四个类都实现了House接口，所以可以进一步的将OuStyle对象通过AddSytle方法传递给ChinaStyleHouse对象
    /// </summary>
    class ChinaStyleHouse : House
    {
        private House House;
        public override void Show()
        {
            Console.Write("这是中式风格");
            if (House != null)
                House.Show();
        }
        public void AddStyle(House house)
        {
            this.House = house;
        }
    }

}
