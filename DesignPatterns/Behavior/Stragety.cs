using System;

namespace DesignPatterns.Behavior
{
    public interface IStragety
    {
        void Send(string msg);
    }

    public class EmailStragety : IStragety
    {
        public void Send(string msg)
        {
            Console.WriteLine("邮件通知：" + msg);
        }
    }

    public class SmsStragety : IStragety
    {
        public void Send(string msg)
        {
            Console.WriteLine("短信通知：" + msg);
        }
    }

    public sealed class NotifyContext
    {

        public NotifyContext(IStragety strategy)
        {
            Stragety = strategy;
        }

        public IStragety Stragety { get; set; }

        public void Send(string msg)
        {
            Stragety.Send(msg);
        }
    }
}