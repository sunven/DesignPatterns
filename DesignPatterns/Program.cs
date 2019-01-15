using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Structure;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 抽象工程模式

            // ef 打开和关闭
            AbstractFactory efFactory = new EfFactory();
            efFactory.CreateOpen().Print();
            efFactory.CreateClose().Print();

            // dapper 打开和关闭
            AbstractFactory dapperFactory = new DapperFactory();
            dapperFactory.CreateOpen().Print();
            dapperFactory.CreateClose().Print();

            #endregion

            Console.WriteLine("------------------------------");

            #region 建造者模式

            var director = new Director();
            var saiyanBuilder = new SaiyanBuilder();
            var naimBuilder = new NaimBuilder();

            director.Construct(saiyanBuilder);

            // 组装赛亚人
            var saiyanPerson = saiyanBuilder.GetPerson();
            saiyanPerson.Show();

            // 组装那美克人
            director.Construct(naimBuilder);
            var naimPerson = naimBuilder.GetPerson();
            naimPerson.Show();

            #endregion

            Console.WriteLine("------------------------------");

            #region MyRegion

            var mingren1 = new MingrenPrototype();
            var mingren2 = mingren1.Clone() as MingrenPrototype;
            //mingren1 负责攻击
            mingren1.Attack();
            //mingren2 负责保护
            mingren2?.Protect();

            #endregion

            Console.WriteLine("------------------------------");

            #region 适配器模式

            //类的适配器模式
            var baiduMap = new BaiduAdapter();
            baiduMap.Gen();

            //对象的适配器模式
            var baiduMap1 = new BaiduAdapter1();
            baiduMap.Gen();

            #endregion

            Console.ReadKey();
        }
    }
}
