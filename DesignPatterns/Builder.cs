using System;

namespace DesignPatterns
{
    public abstract class Person
    {
        public abstract void BuildHead();
        public abstract void BuildBody();
        public abstract void BuildLag();
    }
    public class TinPerson : Person
    {
        public override void BuildHead()
        {
            Console.WriteLine("TinHead");
        }
        public override void BuildBody()
        {
            Console.WriteLine("TinBody");
        }
        public override void BuildLag()
        {
            Console.WriteLine("TinLag");
        }
    }
    public class FatPerson : Person
    {
        public override void BuildHead()
        {
            throw new NotImplementedException();
        }
        public override void BuildBody()
        {
            throw new NotImplementedException();
        }
        public override void BuildLag()
        {
            throw new NotImplementedException();
        }
    }
    public class Builder
    {
        public Person Person { get; }

        public Builder(Person person)
        {
            this.Person = person;
        }
        public void Build(Person person)
        {
            person.BuildHead();
            Person.BuildBody();
            person.BuildLag();
        }

    }
}