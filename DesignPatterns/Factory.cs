namespace DesignPatterns
{
    abstract class Operat
    {
        public double NumberA { get; set; }
        public double NumberB { get; set; }
        public virtual double GetResult()
        {
            return 0;
        }
    }
    class Add : Operat
    {
        public override double GetResult()
        {
            return NumberA + NumberB;
        }
    }
    class Sub : Operat
    {
        public override double GetResult()
        {
            return NumberA - NumberB;
        }
    }

    /// <summary>
    /// 工厂类
    /// </summary>
    class Factory
    {

        public static Operat GetOperat(string flag)
        {
            switch (flag)
            {
                case "1":
                    return new Add();
                case "2":
                    return new Sub();
                default:
                    return null;
            }
        }
    }
}