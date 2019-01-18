using System;

namespace DesignPatterns.Creation
{
    /// <summary>
    /// 抽象工厂类，提供open 和 close 的接口
    /// </summary>
    public abstract class AbstractFactory
    {
        public abstract Open CreateOpen();
        public abstract Close CreateClose();
    }

    /// <summary>
    /// Ef
    /// </summary>
    public class EfFactory : AbstractFactory
    {
        // 打开ef连接
        public override Open CreateOpen()
        {
            return new EfOpen();
        }
        
        // 关闭dapper连接
        public override Close CreateClose()
        {
            return new EfClose();
        }
    }

    /// <summary>
    /// Dapper
    /// </summary>
    public class DapperFactory : AbstractFactory
    {
        // 打开dapper连接
        public override Open CreateOpen()
        {
            return new DapperOpen();
        }
        // 关闭dapper连接
        public override Close CreateClose()
        {
            return new DapperClose();
        }
    }

    /// <summary>
    /// 打开连接
    /// </summary>
    public abstract class Open
    {
        /// <summary>
        /// 打印方法，用于输出信息
        /// </summary>
        public abstract void Print();
    }

    /// <summary>
    /// 关闭连接
    /// </summary>
    public abstract class Close
    {
        /// <summary>
        /// 打印方法，用于输出信息
        /// </summary>
        public abstract void Print();
    }

    /// <summary>
    /// ef open
    /// </summary>
    public class EfOpen : Open
    {
        public override void Print()
        {
            Console.WriteLine("ef open");
        }
    }

    /// <summary>
    /// dapper open
    /// </summary>
    public class DapperOpen : Open
    {
        public override void Print()
        {
            Console.WriteLine("dapper open");
        }
    }

    /// <summary>
    /// ef close
    /// </summary>
    public class EfClose : Close
    {
        public override void Print()
        {
            Console.WriteLine("ef close");
        }
    }

    /// <summary>
    /// dapper close
    /// </summary>
    public class DapperClose : Close
    {
        public override void Print()
        {
            Console.WriteLine("depper close");
        }
    }
}