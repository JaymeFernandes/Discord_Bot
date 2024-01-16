using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace discord.Commands
{
    //comando que limpa o chat
    public class Clear : ModuleBase<SocketCommandContext>
    {
        [Command("clear")]
        [Description("commando para limpar")]
        public async Task CommandClear(int value = 500)
        {
            string message = "";
            if (value <= 0 || value > 500)
            {
                message = "❌ **Valor passado invalido**\n`Valor maximo possivel é 500`";
                await ReplyAsync(message);
            }
            else
            {
                var messages = await Context.Channel.GetMessagesAsync(value).FlattenAsync();
                await ((ITextChannel)Context.Channel).DeleteMessagesAsync(messages);
                message = $"🗑 **Menssagens excuidas com sucesso total de menssagens** : `{messages.Count()} ` ✉️";
            }

            var embed = new EmbedBuilder()
                .WithColor(Color.Red)
                .WithTitle(message)
                .WithDescription($"Autor: {Context.User.Mention}")
                .Build();

            await ReplyAsync(null, false, embed);

        }
    }
}

