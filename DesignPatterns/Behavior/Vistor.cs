using System;

namespace DesignPatterns.Behavior
{
    /// <summary>
    /// 理财
    /// </summary>
    public abstract class FinancialManagement
    {
        /// <summary>
        /// 存钱
        /// </summary>
        public abstract void SaveMoney();

        //外界注入具体访问者
        public abstract void Accept(Visitor visitor);
    }

    //抽象访问者 Visitor
    public abstract class Visitor
    {
        public abstract void Visit(FinancialManagement shape);

        public abstract void Visit(Yeb shape);

        public abstract void Visit(Jj shape);
    }

    //具体访问者
    public sealed class VisitorImp : Visitor
    {
        public override void Visit(FinancialManagement shape)
        {
            Console.WriteLine("针对银行的操作！");
        }
        public override void Visit(Yeb shape)
        {
            Console.WriteLine("针对余额宝的操作！");
        }
        public override void Visit(Jj shape)
        {
            Console.WriteLine("针对基金的操作！");
        }
    }

    public sealed class Bank : FinancialManagement
    {
        public override void SaveMoney()
        {
            Console.WriteLine("在银行存钱！");
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public sealed class Yeb : FinancialManagement
    {
        public override void SaveMoney()
        {
            Console.WriteLine("在余额宝存钱！");
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public sealed class Jj : FinancialManagement
    {
        public override void SaveMoney()
        {
            Console.WriteLine("在基金存钱！");
        }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }

    //结构对象角色
    internal class AppStructure
    {
        private readonly Visitor _visitor;

        public AppStructure(Visitor visitor)
        {
            _visitor = visitor;
        }

        public void Process(FinancialManagement shape)
        {
            shape.Accept(_visitor);
        }
    }
}