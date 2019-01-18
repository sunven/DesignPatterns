using System;

namespace DesignPatterns.Behavior
{
    // 请假请求
    public class LeaveRequest
    {
        // 天数
        public double Days { get; set; }
        // 姓名
        public string Name { get; set; }
        public LeaveRequest(string name, int days)
        {
            Name = name;
            Days = days;
        }
    }

    // 审批人
    public abstract class Approver
    {
        public Approver NextApprover { get; set; }
        public string Name { get; set; }

        protected Approver(string name)
        {
            Name = name;
        }
        public abstract void ProcessRequest(LeaveRequest request);
    }

    /// <summary>
    /// 项目管理者
    /// </summary>
    public class ProjectManager : Approver
    {
        public ProjectManager(string name)
            : base(name)
        { }

        public override void ProcessRequest(LeaveRequest request)
        {
            if (request.Days <= 3)
            {
                Console.WriteLine(Name + "同意" + request.Name + "请假" + request.Days + "天");
            }
            else
            {
                NextApprover?.ProcessRequest(request);
            }
        }
    }

    /// <summary>
    /// 部门管理者
    /// </summary>
    public class DepartManager : Approver
    {
        public DepartManager(string name)
            : base(name)
        {
        }
        public override void ProcessRequest(LeaveRequest request)
        {
            if (request.Days <= 5)
            {
                Console.WriteLine(Name + "同意" + request.Name + "请假" + request.Days + "天");
            }
            else
            {
                NextApprover?.ProcessRequest(request);
            }
        }
    }

    /// <summary>
    /// CEO
    /// </summary>
    public class Ceo : Approver
    {
        public Ceo(string name)
            : base(name)
        { }
        public override void ProcessRequest(LeaveRequest request)
        {
            if (request.Days <= 10)
            {
                Console.WriteLine(Name + "同意" + request.Name + "请假" + request.Days + "天");
            }
            else
            {
                Console.WriteLine("需要讨论");
            }
        }
    }
}