using System;
using System.Collections.Generic;

namespace DesignPatterns.Structure
{
    /// <summary>
    ///  抽象享元类，提供具体享元类具有的方法
    /// </summary>
    public abstract class Flyweight
    {
        /// <summary>
        /// 具体方法
        /// </summary>
        /// <param name="outstate">外部状态</param>
        public abstract void Operation(int outstate);
    }

    public class FlyweightImp : Flyweight
    {
        // 内部状态
        private readonly string _innerState;

        // 构造函数
        public FlyweightImp(string innerState)
        {
            _innerState = innerState;
        }

        /// <summary>
        /// 享元类的实例方法
        /// </summary>
        /// <param name="outstate">外部状态</param>
        public override void Operation(int outstate)
        {
            Console.WriteLine("具体实现类: innerState {0}, outstate {1}", _innerState, outstate);
        }
    }

    /// <summary>
    /// 享元工厂，负责创建和管理享元对象
    /// </summary>
    public class FlyweightFactory
    {
        public static Dictionary<string, Flyweight> DicFlyweight = new Dictionary<string, Flyweight>();


        public static Flyweight GetFlyweight(string key)
        {
            if (DicFlyweight.ContainsKey(key))
            {
                return DicFlyweight[key];
            }

            var flyweight = new FlyweightImp(key);
            DicFlyweight.Add(key, flyweight);
            return flyweight;
        }
    }
}