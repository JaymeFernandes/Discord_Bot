using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using discord.Modules;



namespace Program
{
    /// <summary>
    /// Class Para configuração do servidor
    /// </summary>
    class Program
    {
        // Token do bot
        string token = "Seu Token Aqui";

        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        //Inicia o server
        public async Task MainAsync()
        {
            using(var services = ConfigureServices())
            {
                var client = services.GetRequiredService<DiscordSocketClient>();
                
                client.Log += LogAsync;
                services.GetRequiredService<CommandService>().Log += LogAsync;

                await client.LoginAsync(TokenType.Bot, token);
                await client.StartAsync();

                await services.GetRequiredService<CommandsHadlingService>().InicializateAsync();

                await Task.Delay(-1);
            }
        }


        //ebibe na tela menssagens geradas pelo programa
        public Task LogAsync(LogMessage  message)
        {
            Console.WriteLine(message.ToString());

            return Task.CompletedTask;
        }

        //Propriedades e permições do bot
        private ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddSingleton(new DiscordSocketConfig
                {
                    GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.MessageContent
                })
                .AddSingleton<DiscordSocketClient>()
                .AddSingleton<CommandService>()
                .AddSingleton<CommandsHadlingService>()
                .BuildServiceProvider();
        }
    }
    
}