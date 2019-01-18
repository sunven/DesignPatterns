using System;

namespace DesignPatterns.Structure
{
    //代理抽象类
    public abstract class AgentAbstract
    {
        public virtual void Do(string thing)
        {
            Console.WriteLine(thing);
        }
    }

    /// <summary>
    /// 网络
    /// </summary>
    public sealed class Network : AgentAbstract
    {
        public override void Do(string thing)
        {
            Console.WriteLine(thing);
        }
    }

    //该类型是代理类型----相当于具体的Proxy角色
    public sealed class Proxy : AgentAbstract
    {
        private readonly Network _network;

        //实际Network
        public Proxy()
        {
            _network = new Network();
        }

        public override void Do(string thing)
        {
            Console.WriteLine("之前");
            _network.Do(thing);
            Console.WriteLine("之后");
        }
    }
}