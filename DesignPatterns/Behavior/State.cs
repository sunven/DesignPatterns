using System;

namespace DesignPatterns.Behavior
{
    public class User
    {
        public State State { get; set; }
        public string Name { get; set; }
        public User(string name)
        {
            Name = name;
            State = new Vip1(this, 0);
        }

        // 充钱
        public void Recharge(double count)
        {
            State.Recharge(count);
            Console.WriteLine("充值金额为:{0}", count);
            Console.WriteLine("用户余额为:{0}", State.Money);
            Console.WriteLine("用状态为:{0}", State.GetType().Name);
        }
    }

    // 抽象状态类
    public abstract class State
    {
        public User User { get; set; }

        public double UpperLimit { get; set; }

        public double Money { get; set; }

        /// <summary>
        /// 充钱
        /// </summary>
        /// <param name="count"></param>
        public virtual void Recharge(double count)
        {
            Money += count;
        }
    }

    public class Vip1 : State
    {
        public Vip1(User user, double money)
        {
            User = user;
            Money = money;
            UpperLimit = 100;
        }

        public override void Recharge(double count)
        {
            base.Recharge(count);
            if (Money > UpperLimit)
            {
                User.State = new Vip2(this);
            }
        }
    }

    public class Vip2 : State
    {
        public Vip2(State state)
        {
            User = state.User;
            Money = state.Money;
            UpperLimit = 300;
        }

        public override void Recharge(double count)
        {
            base.Recharge(count);
            if (Money > UpperLimit)
            {
                User.State = new Vip3(this);
            }
        }
    }

    public class Vip3 : State
    {
        public Vip3(State state)
        {
            User = state.User;
            Money = state.Money;
            UpperLimit = 700;
        }

        public override void Recharge(double count)
        {
            base.Recharge(count);
            if (Money > UpperLimit)
            {
                Console.WriteLine("没有更高级别了");
            }
        }
    }
}