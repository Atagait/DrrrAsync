﻿using System;
using System.Threading.Tasks;

using DrrrAsync;
using DrrrAsync.Objects;
using DrrrAsync.Extensions;

namespace DurararaAsync
{

    class Program
    {
        //We define random statically because it helps make random numbers slightly more random
        public static Random rnd = new Random();

        static async Task Main(string[] args)
        {
            Bot DrrrBot = new Bot { Name = "Welne Oren", Icon = DrrrIcon.Kuromu2x, CommandPrefix = "#" };
            DrrrBot.RegisterCommands<TestModule>();

            await DrrrBot.Login();
            await DrrrBot.Connect("WIZARD TOWER");

            await Task.Delay(-1);

            Console.ReadKey();
        }
    }
}
