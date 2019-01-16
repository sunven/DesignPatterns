using System;

namespace DesignPatterns.Structure
{
    /// <summary>
    /// 该抽象类就是车抽象接口的定义，该类型就相当于是抽象构件Component类型
    /// </summary>
    public abstract class Car
    {
        //行驶
        public abstract void Travel();

        //载两个人
        public abstract void Two(Car car);

        //载十个人
        public abstract void Ten(Car car);
    }

    /// <summary>
    /// 摩托车
    /// </summary>
    public sealed class Motorcycle : Car
    {
        public override void Travel()
        {
            Console.WriteLine("摩托车行驶");
        }

        public override void Ten(Car car)
        {
            Console.WriteLine("不能载十个人");
        }

        public override void Two(Car car)
        {
            Console.WriteLine("不能载两个人");
        }
    }

    /// <summary>
    /// SUV
    /// </summary>
    public class SuvCar : Car
    {
        public override void Travel()
        {
            Console.WriteLine("SUV行驶");
        }

        public override void Ten(Car car)
        {
            Console.WriteLine("不能载十个人");
        }

        public override void Two(Car car)
        {
            Console.WriteLine("载两个人");
        }
    }

    /// <summary>
    /// 该抽象类就是车抽象接口的定义，该类型就相当于是抽象构件Component类型
    /// </summary>
    public abstract class Car1
    {
        //行驶
        public abstract void Travel();
    }

    /// <summary>
    /// 摩托车
    /// </summary>
    public sealed class Motorcycle1 : Car1
    {
        public override void Travel()
        {
            Console.WriteLine("摩托车行驶");
        }
    }

    /// <summary>
    /// 四轮车
    /// </summary>
    public abstract class FourCar : Car1
    {
        public override void Travel()
        {
            Console.WriteLine("四轮车行驶");
        }

        //载两个人
        public abstract void Two(Car1 car);

        //载十个人
        public abstract void Ten(Car1 car);
    }

    /// <summary>
    /// Bus
    /// </summary>
    public class Bus : FourCar
    {
        public override void Travel()
        {
            Console.WriteLine("BUS行驶");
        }

        public override void Ten(Car1 car)
        {
            Console.WriteLine("载十个人");
        }

        public override void Two(Car1 car)
        {
            Console.WriteLine("载两个人");
        }
    }
}