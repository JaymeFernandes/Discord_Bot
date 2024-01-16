using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using discord.Modules.Images;
using System.ComponentModel;

namespace discord.Commands
{
    //Class que exibe uma imagem abraçando um usuario do servidor que já tenha postado alguma menssagem anteriormente
    public class Abraço : ModuleBase<SocketCommandContext>
    {
        [Command("abraçar")]
        [Description("faz um abraço caloroso")]
        public async Task CommandAbraco(SocketGuildUser? user)
        {
            Read image = new Read();
            string tipo = "";
            string url = image.GetImage(out tipo, "abraço");

            if(user == null)
            {
                var embed = new EmbedBuilder()
                    .WithColor(Color.Purple)
                    .WithTitle("Infelizmente não encontrei a pessoa mencionada 😥")
                    .WithDescription($"confira se o usuario está correto")
                    .WithImageUrl(url)
                    .Build();

                await Context.Channel.SendMessageAsync(null, false, embed);
            }
            else if (user.IsBot)
            {
                var embed = new EmbedBuilder()
                    .WithColor(Color.Purple)
                    .WithTitle("Infelizmente não é possivel abraçar um bot 😥")
                    .WithDescription($"mas fico feliz com a consideração 😊❤️ {Context.User.Mention}\n**Tipo da imagem:** {tipo}")
                    .WithImageUrl(url)
                    .Build();

                await Context.Channel.SendMessageAsync(null, false, embed);
            }
            else if (user.Username != Context.User.Username)
            {
                    var embed = new EmbedBuilder()
                        .WithColor(Color.Purple)
                        .WithTitle("Abreço caloroso")
                        .WithDescription($"Um abraço carinhoso de {Context.User.Mention} foi mandado para {user.Mention} 😊❤️\n**Tipo da imagem:** {tipo}")
                        .WithImageUrl(url)
                        .Build();

                await Context.Channel.SendMessageAsync(null, false, embed);
            }
            else
            {
                var embed = new EmbedBuilder()
                    .WithColor(Color.Purple)
                    .WithTitle("Abreço caloroso")
                    .WithDescription($"{Context.User.Mention} abraçou a si mesmo com muito amor 😊❤️\n**Tipo da imagem:** {tipo}")
                    .WithImageUrl(url)
                    .Build();

                await Context.Channel.SendMessageAsync(null, false, embed);
            }
        }
    }


}

