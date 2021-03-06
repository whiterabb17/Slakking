using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MargieBot;
using System;
using System.Configuration;

namespace Slakking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CommandHolder.CommandList.Add(new Commands()
            {
                Command1 = "listFiles",
                Command2 = "listFolders",
                Command3 = "getUuid",
                Command4 = "getSysName"
            });
            var container = new WindsorContainer();
            container.Register(Component.For<IResponder>().ImplementedBy<HelloResponder>());

            var bot = new Bot();
            var responders = container.ResolveAll<IResponder>();
            foreach (var responder in responders)
            {
                bot.Responders.Add(responder);
            }
            var connect = bot.Connect(ConfigurationManager.AppSettings["SlackBotApiToken"]);

            while (Console.ReadLine() != "close") { }
        }
    }
}