using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Behavior;
using DesignPatterns.Creation;
using DesignPatterns.Structure;
using ICollection = DesignPatterns.Behavior.ICollection;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 简单工厂

            var add = Factory.GetOperat("1");
            var sub = Factory.GetOperat("2");

            #endregion

            Console.WriteLine("------------------------------");

            #region 单例模式

            Singleton.GetInstance();
            var s1 = Singleton1.Instance;
            var s2 = Singleton2.Instance;

            #endregion

            Console.WriteLine("------------------------------");

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

            #region 原型模式

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
            baiduMap1.Gen();

            #endregion

            Console.WriteLine("------------------------------");

            #region 桥接模式

            DbControlAbstract dbControlAbstract = new DbControl();
            // Sql Server
            dbControlAbstract.Db = new SqlServerDb();
            dbControlAbstract.Open();
            dbControlAbstract.Add();
            dbControlAbstract.Close();

            // MySql
            dbControlAbstract.Db = new MySqlDb();
            dbControlAbstract.Open();
            dbControlAbstract.Add();
            dbControlAbstract.Close();

            #endregion

            Console.WriteLine("------------------------------");

            #region 装饰者模式

            // SqlServerDbHelper
            DbHelper dbHelper = new SqlServerDbHelper();
            // check
            Decorator decorator = new CheckDecorator(dbHelper);
            decorator.Add();

            #endregion

            Console.WriteLine("------------------------------");

            #region 组合模式

            //透明式
            Car car = new Motorcycle();
            car.Travel();
            car.Two(new SuvCar());
            car.Ten(new SuvCar());

            car = new SuvCar();
            car.Travel();
            car.Two(new SuvCar());
            car.Ten(new SuvCar());

            //安全式
            Car1 car1 = new Motorcycle1();
            car1.Travel();

            Car1 bus = new Bus();
            bus.Travel();
            ((FourCar)bus).Two(new Bus());
            ((FourCar)bus).Ten(new Bus());

            #endregion

            Console.WriteLine("------------------------------");

            #region 外观模式

            var facade = new Facade();
            facade.Buy();

            #endregion

            Console.WriteLine("------------------------------");

            #region 享元模式

            foreach (var item in new[] { "a", "b", "c", "a", "b" })
            {
                var flyweight = FlyweightFactory.GetFlyweight(item);
                flyweight.Operation(1);
            }
            Console.WriteLine(FlyweightFactory.DicFlyweight.Count);

            #endregion

            Console.WriteLine("------------------------------");

            #region 代理模式

            var proxy = new Proxy();
            proxy.Do("上网");

            #endregion

            Console.WriteLine("------------------------------");

            #region 模板方法模式

            var chain = new ChinaBank();
            chain.Get();
            var shBank = new ShanghaiBank();
            shBank.Get();

            #endregion

            Console.WriteLine("------------------------------");

            #region 命令模式

            var r = new Receiver1();
            var c = new CommandImp(r);
            var i = new Invoke(c);
            i.ExecuteCommand();

            #endregion

            Console.WriteLine("------------------------------");

            #region 迭代器模式

            ICollection list = new Collection();
            var iterator = list.GetIterator();

            while (iterator.MoveNext())
            {
                var j = (int)iterator.GetCurrent();
                Console.WriteLine(j.ToString());
                iterator.Next();
            }

            #endregion

            Console.WriteLine("------------------------------");

            #region 观察者模式

            HousingDeveloper hd = new WuhanHousingDeveloper();
            hd.Add(new NoHouseObserver("A"));
            hd.Add(new NoHouseObserver("B"));
            hd.Add(new NoHouseObserver("C"));

            hd.Add(new HasHouseObserver("D"));
            hd.Add(new HasHouseObserver("E"));
            hd.Add(new HasHouseObserver("F"));

            hd.Notify();

            #endregion

            Console.WriteLine("------------------------------");

            #region 中介者模式

            var buyer = new Buyer();
            var seller = new Seller();
            var mediator = new MediatorImp(buyer, seller);
            buyer.MoneyChange(5, mediator);
            seller.MoneyChange(10, mediator);

            #endregion

            Console.WriteLine("------------------------------");

            #region 状态模式

            var user = new User("admin");
            for (var j = 0; j < 10; j++)
            {
                user.Recharge(20 * j);
            }

            #endregion

            Console.WriteLine("------------------------------");

            #region 策略模式

            var context = new NotifyContext(new EmailStragety());
            context.Send("新的消息");
            context.Stragety = new SmsStragety();
            context.Send("第二条消息");

            #endregion

            Console.WriteLine("------------------------------");

            #region 责任链模式

            var leaveRequest1 = new LeaveRequest("张三", 1);
            var leaveRequest2 = new LeaveRequest("李四", 4);
            var leaveRequest3 = new LeaveRequest("王五", 7);
            var leaveRequest4 = new LeaveRequest("赵六", 11);

            Approver projectManager = new ProjectManager("项目管理者");
            Approver departManager = new DepartManager("部门管理者");
            Approver ceo = new Ceo("CEO");

            // 设置责任链
            projectManager.NextApprover = departManager;
            departManager.NextApprover = ceo;

            // 处理请求
            projectManager.ProcessRequest(leaveRequest1);
            projectManager.ProcessRequest(leaveRequest2);
            projectManager.ProcessRequest(leaveRequest3);
            projectManager.ProcessRequest(leaveRequest4);

            #endregion

            Console.WriteLine("------------------------------");

            #region 访问者模式

            Visitor visitor = new VisitorImp();
            var app = new AppStructure(visitor);

            FinancialManagement financialManagement = new Bank();
            financialManagement.SaveMoney();
            app.Process(financialManagement);


            financialManagement = new Yeb();
            financialManagement.SaveMoney();
            app.Process(financialManagement);


            financialManagement = new Jj();
            financialManagement.SaveMoney();
            app.Process(financialManagement);

            #endregion

            Console.WriteLine("------------------------------");

            #region 备忘录模式

            var persons= new List<ContactPerson>()
            {
                new ContactPerson { Name="A", MobileNumber = "13533332222"},
                new ContactPerson { Name="B", MobileNumber = "13966554433"},
                new ContactPerson { Name="C", MobileNumber = "13198765544"}
            };

            //手机名单发起人
            var mobileOriginator = new MobileBackOriginator(persons);
            mobileOriginator.Show();

            // 创建备忘录并保存备忘录对象
            var manager = new MementoManager {ContactPersonMemento = mobileOriginator.CreateMemento()};

            // 更改发起人联系人列表
            Console.WriteLine("----移除最后一个联系人--------");
            mobileOriginator.ContactPersonList.RemoveAt(2);
            mobileOriginator.Show();

            // 恢复到原始状态
            Console.WriteLine("-------恢复联系人列表------");
            mobileOriginator.RestoreMemento(manager.ContactPersonMemento);
            mobileOriginator.Show();

            #endregion

            #region 解释器模式

            Console.WriteLine("------------------------------");

            const string roman = "六千四百五十二";
            var interpreterContext = new InterpreterContext(roman);
            var tree = new ArrayList
            {
                new GeExpression(),
                new ShiExpression(),
                new BaiExpression(),
                new QianExpression()
            };
            foreach (Expression exp in tree)
            {
                exp.Interpreter(interpreterContext);
            }
            Console.Write(interpreterContext.Data);

            #endregion

            Console.ReadKey();
        }
    }
}
