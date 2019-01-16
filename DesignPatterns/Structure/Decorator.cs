using System;

namespace DesignPatterns.Structure
{
    /// <summary>
    /// DbHelper
    /// </summary>
    public abstract class DbHelper
    {
        public abstract void Add();
    }

    /// <summary>
    /// SqlServerDbHelper
    /// </summary>
    public class SqlServerDbHelper : DbHelper
    {
        /// <summary>
        /// 重写基类方法
        /// </summary>
        public override void Add()
        {
            Console.WriteLine("Sql Server add");
        }
    }

    /// <summary>
    /// 装饰抽象类,要让装饰完全取代抽象组件，所以必须继承自DbHelper
    /// </summary>
    public abstract class Decorator : DbHelper
    {
        private readonly DbHelper _dbHelper;

        protected Decorator(DbHelper p)
        {
            _dbHelper = p;
        }

        public override void Add()
        {
            _dbHelper?.Add();
        }
    }

    /// <summary>
    /// 新增时的检测，即具体装饰者
    /// </summary>
    public class CheckDecorator : Decorator
    {
        public CheckDecorator(DbHelper dbHelper)
            : base(dbHelper)
        { 
        }

        public override void Add()
        {
            // 添加新的行为
            Check();      
            base.Add();
        }

        /// <summary>
        /// 新的行为方法
        /// </summary>
        public void Check()
        {
            Console.WriteLine("检测是否新增过");
        }
    }
}