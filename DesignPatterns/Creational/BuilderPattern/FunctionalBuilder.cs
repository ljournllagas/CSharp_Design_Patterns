using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.BuilderPattern
{
    public class PersonFunc
    {
        public string Name, Position;
    }

    public class PersonFuncBuilder
    {
        public readonly List<Action<PersonFunc>> Actions = new List<Action<PersonFunc>>();

        public PersonFuncBuilder Called(string name)
        {
            Actions.Add(p => { p.Name = name; });
            return this;
        }

        public PersonFunc Build()
        {
            var p = new PersonFunc();
            Actions.ForEach(a => a(p));
            return p;
        }
    }

    public static class PersonFuncBuilderExtensions
    {
        public static PersonFuncBuilder WorksAsA
          (this PersonFuncBuilder builder, string position)
        {
            builder.Actions.Add(p => { p.Position = position; });
            return builder;
        }
    }

    public class FunctionalBuilder
    {
        //public static void Main(string[] args)
        //{
        //    var pb = new PersonFuncBuilder();
        //    var PersonFunc = pb.Called("Dmitri").WorksAsA("Programmer").Build();
        //}
    }
}
