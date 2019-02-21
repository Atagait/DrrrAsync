﻿using System;
using System.Threading.Tasks;

using DrrrAsync.Bot;

namespace DurararaAsync
{
    class NewTestModule : Module
    {
        public static NewTestModule Instance = new NewTestModule();

        [Command("time")]
        async public Task CommandTime(CommandHandlerArgs e)
        {
            await e.Client.SendMessage(DateTime.Now.ToShortTimeString());
        }
    }
}