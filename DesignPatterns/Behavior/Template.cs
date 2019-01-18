using System;

namespace DesignPatterns.Behavior
{
    public abstract class Money
    {
        public void Get()
        {
            Atm();
            Card();
            Password();
            Over();
        }

        public void Atm()
        {
            Console.WriteLine("找到ATM");
        }

        public abstract void Card();

        public void Password()
        {
            Console.WriteLine("输入密码");
        }

        public void Over()
        {
            Console.WriteLine("拿钱取卡");
        }
    }

    public class ChinaBank : Money
    {
        public override void Card()
        {
            Console.WriteLine("中国银行银行卡");
        }
    }

    public class ShanghaiBank : Money
    {
        public override void Card()
        {
            Console.WriteLine("上海银行银行卡");
        }
    }
}