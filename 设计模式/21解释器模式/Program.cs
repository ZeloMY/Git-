using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _13解释器模式
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    struct InterPretData
    { 
    
    }
    /// <summary>
    /// 抽象解释器接口
    /// </summary>
    internal abstract class Expression
    {
        public abstract void Interpret(InterPretData data);
    }

    internal class NonExpression : Expression
    {
        public override void Interpret(InterPretData data)
        {
            Console.WriteLine("Non解释处理data数据");
        }
    }

    internal class TerExpression : Expression
    {
        public override void Interpret(InterPretData data)
        {
            Console.WriteLine("Ter解释处理data数据");
        }
    }

}
