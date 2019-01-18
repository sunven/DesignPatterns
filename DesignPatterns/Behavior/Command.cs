using System;

namespace DesignPatterns.Behavior
{
    /// <summary>
    /// 接收者抽象类
    /// </summary>
    public abstract class Receiver
    {
        public abstract void Do();
    }

    // 命令抽象类
    public abstract class Command
    {
        // 命令接收者
        protected Receiver Receiver;

        protected Command(Receiver receiver)
        {
            Receiver = receiver;
        }

        // 命令执行方法
        public abstract void Action();
    }

    // 负责执行
    public class Invoke
    {
        public Command Command;

        public Invoke(Command command)
        {
            Command = command;
        }

        public void ExecuteCommand()
        {
            Command.Action();
        }
    }

    public class CommandImp : Command
    {
        public CommandImp(Receiver receiver)
            : base(receiver)
        {
        }

        public override void Action()
        {
            Receiver.Do();
        }
    }

    public class Receiver1 : Receiver
    {
        public override void Do()
        {
            Console.WriteLine("做事儿");
        }
    }
}