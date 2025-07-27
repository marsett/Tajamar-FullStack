using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebJobChollometro.Data;
using WebJobChollometro.Models;

namespace WebJobChollometro.Repositories
{
    public class RepositoryChollometro
    {
        private ChollometroContext context;
        public RepositoryChollometro(ChollometroContext context)
        {
            this.context = context;
        }

        // Los chollos los vamos a extraer de la web
        // Recuperaremos todos los que tenga dentro del rss
        // Iremos incrementando cada chollo mediante un max
        public async Task<int> GetMaxIdCholloAsync()
        {
            if(this.context.Chollos.Count() == 0)
            {
                return 1;
            }
            else
            {
                return await this.context.Chollos.MaxAsync(x => x.IdChollo) + 1;
            }
        }

        // Método para leer los chollos de la web
        public async Task<List<Chollo>> GetChollosWebAsync()
        {
            // @"Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)"
            string url = "https://www.chollometro.com/rss";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = @"text/html application/xhtml+xml, *.*";
            request.Host = "www.chollometro.com";
            request.Headers.Add("Accept-language", "es-ES");
            request.Referer = "https://www.chollometro.com";
            request.UserAgent = @"Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)";
            HttpWebResponse reponse = (HttpWebResponse) await request.GetResponseAsync();
            // Este tipo de petición se puede utilizar para todo,
            // podemos leer un vídeo, una imagen o un simple texto
            // la información nos la devuelve en stream
            // debemos convertir el stream en texto (xml)
            string xmlData = "";
            using(StreamReader reader = new StreamReader(reponse.GetResponseStream()))
            {
                xmlData = await reader.ReadToEndAsync();
            }
            // Tenemos un xml que podemos leer con LINQ
            XDocument document = XDocument.Parse(xmlData);
            var consulta = from datos in document.Descendants("item")
                           select datos;
            List<Chollo> chollosWeb = new List<Chollo>();
            int idChollo = await this.GetMaxIdCholloAsync();
            foreach(var tag in consulta)
            {
                Chollo chollo = new Chollo();
                chollo.IdChollo = idChollo;
                chollo.Titulo = tag.Element("title").Value;
                chollo.Descripcion = tag.Element("description").Value;
                chollo.Link = tag.Element("link").Value;
                chollo.Fecha = DateTime.Now;
                idChollo++;
                chollosWeb.Add(chollo);
            }
            return chollosWeb;
        }
        // Creamos un método para agregar los chollos de la nube
        // dentro de la base de datos
        public async Task PopulateChollosAzureAsync()
        {
            List<Chollo> chollos = await this.GetChollosWebAsync();
            foreach(Chollo c in chollos)
            {
                // Los agregamos al context
                this.context.Chollos.Add(c);
            }
            await this.context.SaveChangesAsync();
        }
    }
}
