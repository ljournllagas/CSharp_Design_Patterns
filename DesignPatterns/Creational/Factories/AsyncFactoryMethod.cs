﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Factories
{
    public class Foo
    {
        private Foo()
        {
            //
        }

        private async Task<Foo> InitAsync()
        {
            await Task.Delay(1000);
            return this;
        }

        public static Task<Foo> CreateAsync()
        {
            var result = new Foo();
            return result.InitAsync();
        }
    }

    class AsyncFactoryMethod
    {
        //static async Task Main(string[] args)
        //{
        //    Foo x = await Foo.CreateAsync();
        //}
    }
}
