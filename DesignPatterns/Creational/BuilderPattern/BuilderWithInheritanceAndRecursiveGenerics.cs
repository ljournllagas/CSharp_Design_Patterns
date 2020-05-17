using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.BuilderPattern
{
    public class PersonGenerics
    {
        public string Name;

        public string Position;

        public DateTime DateOfBirth;

        public class Builder : PersonGenericsBirthDateBuilder<Builder>
        {
            internal Builder() { }
        }

        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }

    public abstract class PersonGenericsBuilder
    {
        protected PersonGenerics PersonGenerics = new PersonGenerics();

        public PersonGenerics Build()
        {
            return PersonGenerics;
        }
    }

    public class PersonGenericsInfoBuilder<SELF> : PersonGenericsBuilder
      where SELF : PersonGenericsInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            PersonGenerics.Name = name;
            return (SELF)this;
        }
    }

    public class PersonGenericsJobBuilder<SELF>
      : PersonGenericsInfoBuilder<PersonGenericsJobBuilder<SELF>>
      where SELF : PersonGenericsJobBuilder<SELF>
    {
        public SELF WorksAsA(string position)
        {
            PersonGenerics.Position = position;
            return (SELF)this;
        }
    }

    // here's another inheritance level
    // note there's no PersonGenericsInfoBuilder<PersonGenericsJobBuilder<PersonGenericsBirthDateBuilder<SELF>>>!

    public class PersonGenericsBirthDateBuilder<SELF>
      : PersonGenericsJobBuilder<PersonGenericsBirthDateBuilder<SELF>>
      where SELF : PersonGenericsBirthDateBuilder<SELF>
    {
        public SELF Born(DateTime dateOfBirth)
        {
            PersonGenerics.DateOfBirth = dateOfBirth;
            return (SELF)this;
        }
    }

    internal class Program
    {
        class SomeBuilder : PersonGenericsBirthDateBuilder<SomeBuilder>
        {

        }

        //public static void Main(string[] args)
        //{
        //    var me = PersonGenerics.New
        //      .Called("Dmitri")
        //      .WorksAsA("Quant")
        //      .Born(DateTime.UtcNow)
        //      .Build();
        //    Console.WriteLine(me);
        //}
    }
}
