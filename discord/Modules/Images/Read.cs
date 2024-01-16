using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace discord.Modules.Images
{
    public class Read
    {
        private List<image> list = new List<image>();

        // Verigica o tipo de comando e coloca  o diretorio corrreto
        public string GetImage(out string Tipo, string mode)
        {
            Random rnd = new Random();
            Tipo = "nada";

            if(mode == "abraço")
            {
                
                //gera um numero aleatorio exibindo uma imagem do tipo comum ou lendario
                int value = rnd.Next(0, 100);
                string filePath = (value > 10 ? "Modules/AbraçosComum.json" : "Modules/AbraçosLegendary.json");
                Tipo = (value > 10 ? "comum" : "lendary");

                ReadUrl(filePath);
                if (list.Count <= 0) return "não possui imagens registradas";
                int num = rnd.Next(0, list.Count);
                return list[num].Url;
                
            }
            else if(mode == "soco")
            {

                int value = rnd.Next(0, 100);
                string filePath = (value > 10 ? "Modules/SocoComum.json" : "Modules/SocoLegendary.json");
                Tipo = (value > 10 ? "comum" : "lendary");

                ReadUrl(filePath);
                if (list.Count <= 0) return "não possui imagens registradas";
                int num = rnd.Next(0, list.Count);
                return list[num].Url;
            }
            else
            {
                throw new Exception("Não encontrei a imagem");
            }
        }

        //Efetua a leitura de um arquivo JSON na pasta (/Modules)
        public void ReadUrl(string filePath)
        {
            if (File.Exists(filePath))
            {
                list.Clear();
                using (var stream = new StreamReader(filePath))
                {
                    string file = stream.ReadToEnd();

                    list = JsonConvert.DeserializeObject<List<image>>(file);
                }
            }
            else
            {
                return;
            }
        }

        //escreve no JSON uma nova URL de imagem da internet e salva na pasta (\Modules)
        public void AddUrl(string Url, string filePath)
        {

            ReadUrl(filePath);
            list.Add(new image { Url = Url });
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                string file = JsonConvert.SerializeObject(list, Formatting.Indented);
                writer.WriteLine(file);
            }
        }
    }

    // Representa um objeto da imagem que pode ser acessado
    public class image
    {
        public string Url { get; set; }
    }
}
