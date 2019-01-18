using System;

namespace DesignPatterns.Behavior
{
    // 淘宝用户抽象类
    public abstract class TbUser
    {
        public int MoneyCount { get; set; }

        protected TbUser()
        {
            MoneyCount = 0;
        }

        public abstract void MoneyChange(int count, Mediator mediator);
    }

    // 买家
    public class Buyer : TbUser
    {
        // 依赖与抽象中介者对象
        public override void MoneyChange(int count, Mediator mediator)
        {
            mediator.BuyerMoneyChange(count);
        }
    }

    // 卖家
    public class Seller : TbUser
    {
        // 依赖与抽象中介者对象
        public override void MoneyChange(int count, Mediator mediator)
        {
            mediator.SellerMoneyChange(count);
        }
    }
    public abstract class Mediator
    {
        protected TbUser Buyer;
        protected TbUser Seller;

        protected Mediator(TbUser buyer, TbUser seller)
        {
            Buyer = buyer;
            Seller = seller;
        }

        public abstract void BuyerMoneyChange(int count);
        public abstract void SellerMoneyChange(int count);
    }

    public class MediatorImp : Mediator
    {
        public MediatorImp(TbUser buyer, TbUser seller) : base(buyer, seller)
        {
        }

        public override void BuyerMoneyChange(int count)
        {
            Console.WriteLine("买家买东西");
            Buyer.MoneyCount -= count;
            Seller.MoneyCount += count;
            Console.WriteLine(Buyer.MoneyCount);
        }

        public override void SellerMoneyChange(int count)
        {
            Console.WriteLine("卖家退货");
            Seller.MoneyCount -= count;
            Buyer.MoneyCount += count;
            Console.WriteLine(Seller.MoneyCount);
        }
    }
}