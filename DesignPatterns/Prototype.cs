using System;

namespace DesignPatterns
{
    public abstract class Prototype
    {
        public abstract Prototype Clone();

        public abstract void Attack();

        public abstract void Protect();
    }

    /// <summary>
    /// 鸣人
    /// </summary>
    public class MingrenPrototype : Prototype
    {
        /// <summary>
        /// 浅拷贝
        /// </summary>
        /// <returns></returns>
        public override Prototype Clone()
        {
            // 调用MemberwiseClone方法实现的是浅拷贝，另外还有深拷贝
            return (Prototype)this.MemberwiseClone();
        }

        public override void Attack()
        {
            Console.WriteLine("攻击");
        }

        public override void Protect()
        {
            Console.WriteLine("保护");
        }
    }
}