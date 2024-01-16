using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using discord.Modules.Images;

namespace discord.Commands
{
    //Class que exibe uma imagem soco um usuario do servidor que já tenha postado alguma menssagem anteriormente
    public class Soco : ModuleBase<SocketCommandContext>
    {
        [Command("soco")]
        public async Task CommandSoco(SocketGuildUser user)
        {
            string Tipo = "";
            Read read = new Read();

            string url = read.GetImage(out Tipo, "soco");
            if(user == null)
            {
                var embed = new EmbedBuilder()
                    .WithColor(Color.Purple)
                    .WithTitle("Infelizmente não encontrei a pessoa mencionada 😥")
                    .WithDescription($"confira se o usuario está correto")
                    .Build();
                await Context.Channel.SendMessageAsync(null, false, embed);
            }
            else if (user.IsBot)
            {
                var embud = new EmbedBuilder()
                    .WithColor(Color.Purple)
                    .WithTitle("Jura que voce tentou bater em um bot 😭")
                    .WithDescription($"Eu fique muito chateado com sua atitude 😥 {Context.User.Mention}")
                    .WithImageUrl("https://media.tenor.com/XDZGEIpCwYkAAAAC/oshi-no-ko-lagrimas.gif")
                    .Build();
                await Context.Channel.SendMessageAsync(null, false, embud);


            }
            else if(user.Username == Context.User.Username)
            {
                var embud = new EmbedBuilder()
                    .WithColor(Color.Purple)
                    .WithTitle("Jura que voce tentou bater em si mesmo? 😨")
                    .WithDescription($"Estou muito chocado 😰 \nprocure ajuda {Context.User.Mention} 🙏 \n**Tipo da imagem:** {Tipo}")
                    .WithImageUrl(url)
                    .Build();
                await ReplyAsync(null, false, embud);
            }
            else
            {

                var embud = new EmbedBuilder()
                    .WithColor(Color.Purple)
                    .WithTitle("Um soco foi iniciado")
                    .WithDescription($"{Context.User.Mention} Deu um soco em {user.Mention} 😈😡 \n**Tipo da imagem:** {Tipo}")
                    .WithImageUrl(url)
                    .Build();
                await ReplyAsync(null, false, embud);
            }
                
        }
    }
}
