﻿using DrrrBot;
using DrrrBot.Core;
using DrrrBot.Objects;
using System;
using System.Threading.Tasks;
using Console = Colorful.Console;

public class Test
{
    DrrrClient Client;

    bool Initialize()
    {
        try
        {
            Client = new DrrrClient();

            Client.Name = "test";
            Client.Icon = DrrrIcon.Kuromu2x;
        }
        catch(Exception e)
        {
            return false;
        }
        return true;
    }

    async Task<bool> LoginTest()
    {
        try
        {
            await Client.Login();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
        
    }

    async Task<bool> LoungeTest()
    {
        try
        {
            await Client.GetLounge();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    async Task<bool> CreateRoom()
    {
        try
        {
            await Client.MakeRoom(new DrrrRoomConfig()
            {
                Name = "DrrrAsync Test",
                Description = "Welcome!",
                Limit = 20
            });
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
        
    }

    async Task<bool> GetRoom()
    {
        try
        {
            await Client.GetRoom();
            await Client.GetRoomUpdate();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    async Task<bool> SendMessage()
    {
        try
        {
            await Client.SendMessage("Test.");
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    async Task<bool> Leave()
    {
        try
        {
            await Client.LeaveRoom();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    bool RunTest(string test, Func<bool> Test)
    {
        bool result = Test();
        Console.WriteLine($"{test}: {(result ? "PASSED" : "FAILED")}");
        return result;
    }

    async Task<bool> RunTest(string test, Task<bool> Test)
    {
        bool result = await Test;
        Console.WriteLine($"{test}: {(result ? "PASSED" : "FAILED")}");
        return result;
    }

    public async Task RunTests()
    {
        if (!RunTest("Init", Initialize))
        {
            Console.WriteLine("Could not initialize cleint. Stopping tests.");
            return;
        }
        if(!await RunTest("Login", LoginTest())){
            Console.WriteLine("Could not login to drrr.com. Stopping tests.");
            return;
        }
        await RunTest("Lounge", LoungeTest());

        if(!await RunTest("Room", CreateRoom()))
        {
            Console.WriteLine("Could not create room. Stopping tests.");
            return;
        }
        await RunTest("Update", GetRoom());
        await RunTest("Send", SendMessage());

        Console.WriteLine("Waiting 40s to leave...");
        await Task.Delay(40000);
        await RunTest("Leave", Leave());
        Console.ReadKey();
    }
}