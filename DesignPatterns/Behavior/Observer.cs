using System;
using System.Collections.Generic;

namespace DesignPatterns.Behavior
{
    //房屋开发商，是被观察者--该类型相当于抽象主体角色Subject
    public abstract class HousingDeveloper
    {
        protected IList<Observer> Observers;

        //构造函数初始化观察者列表实例
        protected HousingDeveloper()
        {
            Observers = new List<Observer>();
        }

        //增加客户
        public abstract void Add(Observer observer);

        //删除客户
        public abstract void Delete(Observer observer);

        //通知客户
        public void Notify()
        {
            foreach (var observer in Observers)
            {
                observer.Update(observer.Name + ":有房了。");
            }
        }
    }

    //武汉房屋开发商
    public sealed class WuhanHousingDeveloper : HousingDeveloper
    {
        //增加客户
        public override void Add(Observer observer)
        {
            Observers.Add(observer);
        }

        //删除客户
        public override void Delete(Observer observer)
        {
            Observers.Remove(observer);
        }
    }

    //客户的抽象接口--相当于抽象观察者角色（Observer）
    public abstract class Observer
    {
        public string Name { get; set; }

        //初始化状态数据
        protected Observer(string name)
        {
            Name = name;
        }

        //更新客户状态
        public virtual void Update(string msg)
        {
            Console.WriteLine(msg);
        }
    }

    public sealed class NoHouseObserver : Observer
    {
        public NoHouseObserver(string name) : base(name) { }
        public override void Update(string msg)
        {
            base.Update(msg);
            Console.WriteLine("我立即去买房");
        }
    }

    public sealed class HasHouseObserver : Observer
    {
        public HasHouseObserver(string name) : base(name) { }
        public override void Update(string msg)
        {
            base.Update(msg);
            Console.WriteLine("我先考虑下");
        }
    }
}