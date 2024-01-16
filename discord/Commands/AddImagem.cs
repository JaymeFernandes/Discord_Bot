using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using discord.Modules.Images;
using Discord;

namespace discord.Commands
{

    // commando para adicionar uma imagem no arquivo JSON
    public class AddImagem : ModuleBase<SocketCommandContext>
    {
        [Command("pop abraço")]
        public async Task CommandPopAbraco(string tipy = "", string Url = "")
        {
            string message = "";

            Read render = new Read();
            if (tipy.ToLower() == "comum" && Url != "")
            {
                render.AddUrl(Url, "Modules/AbraçosComum.json");
                message = $"**status:** Imagem adicionada ao banco de imagens\n**Tipe:** {tipy.ToLower()} ";
            }
            else if(tipy.ToLower() == "lendary" && Url != "")
            {
                render.AddUrl(Url, "Modules/AbraçosLegendary.json");
                message = $"**status:** Imagem adicionada ao banco de imagens\n**Tipe:** {tipy.ToLower()} ";
            }
            else
            {
                message = $"Erro: Paramtros invalidos";
            }

            var embed = new EmbedBuilder()
                .WithColor(Color.Red)
                .WithTitle("Imagem status")
                .WithDescription(message)
                .Build();

            ReplyAsync(null, false, embed);


        }

        // commando para adicionar uma imagem no arquivo JSON
        [Command("pop soco")]
        public async Task CommandPopSoco(string tipy = "", string Url = "")
        {
            string message = "";

            Read render = new Read();
            if (tipy.ToLower() == "comum" && Url != "")
            {
                render.AddUrl(Url, "Modules/SocoComum.json");
                message = $"**status:** Imagem adicionada ao banco de imagens\n**Tipe:** {tipy.ToLower()} ";
            }
            else if (tipy.ToLower() == "lendary" && Url != "")
            {
                render.AddUrl(Url, "Modules/SocoLegendary.json");
                message = $"**status:** Imagem adicionada ao banco de imagens\n**Tipe:** {tipy.ToLower()} ";
            }
            else
            {
                message = $"Erro: Paramtros invalidos";
            }

            var embed = new EmbedBuilder()
                .WithColor(Color.Red)
                .WithTitle("Imagem status")
                .WithDescription(message)
                .Build();

            ReplyAsync(null, false, embed);


        }
    }
}
