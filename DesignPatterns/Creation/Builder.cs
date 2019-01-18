using System;
using System.Collections.Generic;

namespace DesignPatterns.Creation
{
    /// <summary>
    /// 指挥者
    /// </summary>
    public class Director
    {
        // 组装人
        public void Construct(Builder builder)
        {
            builder.BuildHead();
            builder.BuildBody();
            builder.BuildFoot();
        }
    }

    /// <summary>
    /// 人
    /// </summary>
    public sealed class Person
    {
        // 人部件集合
        private readonly IList<string> _parts = new List<string>();

        // 把单个部件添加到人部件集合中
        public void Add(string part)
        {
            _parts.Add(part);
        }

        public void Show()
        {
            Console.WriteLine("人开始在组装.......");
            foreach (var part in _parts)
            {
                Console.WriteLine("组件" + part + "已装好");
            }

            Console.WriteLine("人组装好了");
        }
    }

    /// <summary>
    /// 抽象建造者
    /// </summary>
    public abstract class Builder
    {
        // 创建头
        public abstract void BuildHead();
        // 创建身体
        public abstract void BuildBody();
        // 创建脚
        public abstract void BuildFoot();
        // 获得组装好的人
        public abstract Person GetPerson();
    }

    /// <summary>
    /// 具体创建者，赛亚人
    /// </summary>
    public sealed class SaiyanBuilder : Builder
    {
        readonly Person _buickCar = new Person();
        public override void BuildHead()
        {
            _buickCar.Add("Saiyan BuildHead");
        }

        public override void BuildBody()
        {
            _buickCar.Add("Saiyan BuildBody");
        }

        public override void BuildFoot()
        {
            _buickCar.Add("Saiyan BuildFoot");
        }

        public override Person GetPerson()
        {
            return _buickCar;
        }
    }

    /// <summary>
    /// 具体创建者，那美克人
    /// </summary>
    public sealed class NaimBuilder : Builder
    {
        readonly Person _buickCar = new Person();
        public override void BuildHead()
        {
            _buickCar.Add("Naim BuildHead");
        }

        public override void BuildBody()
        {
            _buickCar.Add("Naim BuildBody");
        }

        public override void BuildFoot()
        {
            _buickCar.Add("Naim BuildFoot");
        }

        public override Person GetPerson()
        {
            return _buickCar;
        }
    }
}