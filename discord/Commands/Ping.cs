using Discord;
using Discord.Commands;
using System;

namespace discord.Commands
{
    public class PingCommands : ModuleBase<SocketCommandContext>
    {
        //comando que responde pong mostrando a latencia do bot
        [Command("ping")]
        public async Task PingAsync()
        {
            var embed = new EmbedBuilder()
                .WithColor(Color.Red)
                .WithTitle("**🏓Pong!**")
                .WithDescription($"Data:  `[{DateTime.Now}]`\nConectividade com o discord:  `{Context.Client.Latency} ms` 💻\n User:  `{Context.User.Username}`")
                .Build();

            await ReplyAsync(null, false, embed);
        }
    }
}
