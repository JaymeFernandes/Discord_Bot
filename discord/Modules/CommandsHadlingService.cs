using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;
using discord.Commands;

namespace discord.Modules
{
    class CommandsHadlingService
    {
        private readonly CommandService _commands;
        private readonly DiscordSocketClient _discord;
        private readonly IServiceProvider _services;

        public CommandsHadlingService(IServiceProvider services)
        {
            _commands = services.GetRequiredService<CommandService>();
            _discord = services.GetRequiredService<DiscordSocketClient>();
            _services = services;

            _commands.CommandExecuted += CommandsExecutedAsync;
            _discord.MessageReceived += MessageReceivedAsync;

        }

        public async Task InicializateAsync()
        {
            await _commands.AddModulesAsync(assembly : Assembly.GetEntryAssembly(), _services);

        }

        private async Task MessageReceivedAsync(SocketMessage rawMessage)
        {
            if (!(rawMessage is SocketUserMessage message))
                return;

            int argPos = 0;
            if (message is null || message.Author.IsBot || (!message.HasCharPrefix('!', ref argPos))) return;

            var context = new SocketCommandContext(_discord, message);
            await _commands.ExecuteAsync(context, argPos, _services);
        }

        private async Task CommandsExecutedAsync(Optional<CommandInfo> command, ICommandContext context, IResult result)
        {
            if (!command.IsSpecified)
                return;


            if (result.IsSuccess)
                return;
            var embed = new EmbedBuilder()
                .WithColor(Color.Red)
                .WithTitle($"Erro: {result}")
                .WithDescription("Não entendi o que aconteceu, mas aconteceu 😅")
                .WithImageUrl("https://media.tenor.com/GZHf6gWuy5UAAAAC/nezuko-tanjiro.gif")
                .Build();

            await context.Channel.SendMessageAsync(null, false, embed);
        }
    }
}
