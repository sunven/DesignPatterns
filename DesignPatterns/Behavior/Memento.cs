using System;
using System.Collections.Generic;

namespace DesignPatterns.Behavior
{
    // 联系人--需要备份的数据，是状态数据，没有操作
    public sealed class ContactPerson
    {
        //姓名
        public string Name { get; set; }

        //电话号码
        public string MobileNumber { get; set; }
    }

    // 备份通讯录发起人
    public sealed class MobileBackOriginator
    {
        public List<ContactPerson> ContactPersonList { get; set; }


        //初始化需要备份的电话名单
        public MobileBackOriginator(List<ContactPerson> personList)
        {
            ContactPersonList = personList;
        }

        // 创建备忘录对象实例，将当期要保存的联系人列表保存到备忘录对象中
        public Memento CreateMemento()
        {
            return new Memento(new List<ContactPerson>(ContactPersonList));
        }

        // 将备忘录中的数据备份还原到联系人列表中
        public void RestoreMemento(Memento memento)
        {
            ContactPersonList = memento.ContactPersonListBack;
        }

        public void Show()
        {
            Console.WriteLine("联系人列表中共有{0}个人，他们是:", ContactPersonList.Count);
            foreach (ContactPerson p in ContactPersonList)
            {
                Console.WriteLine("姓名: {0} 号码: {1}", p.Name, p.MobileNumber);
            }
        }
    }

    // 备忘录对象，用于保存状态数据
    public sealed class Memento
    {
        // 保存发起人创建的电话名单数据
        public List<ContactPerson> ContactPersonListBack { get; }

        public Memento(List<ContactPerson> personList)
        {
            ContactPersonListBack = personList;
        }
    }

    // 管理角色，它可以管理【备忘录】对象
    public sealed class MementoManager
    {
        //如果想保存多个【备忘录】对象，可以通过字典或者堆栈来保存，堆栈对象可以反映保存对象的先后顺序
        public Memento ContactPersonMemento { get; set; }
    }
}