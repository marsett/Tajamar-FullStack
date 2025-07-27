using NugetCarsMJM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NugetCarsMJM.Repositories
{
    public class RepositoryCoches
    {
        private XDocument document;
        public RepositoryCoches()
        {
            // Para recuperar un recurso incrustado
            // necesitamos el namespace y, si lo tuviera,
            // la carpeta donde estuviera el recurso incrustado.
            string resourceName = "NugetCarsMJM.coches.xml";
            // Los ficheros se recuperan mediante bytes, es decir,
            // mediante la clase Stream
            Stream stream = this.GetType().Assembly.GetManifestResourceStream(resourceName);
            // Como es un xml físico, se utiliza el método load
            this.document = XDocument.Load(stream);
        }

        public List<Coche> GetCoches()
        {
            var consulta = from datos in this.document.Descendants("coche")
                           select datos;
            List<Coche> cars = new List<Coche>();
            foreach (var tag in consulta)
            {
                Coche car = new Coche();
                car.IdCoche = int.Parse(tag.Element("idcoche").Value);
                car.Marca = tag.Element("marca").Value;
                car.Modelo = tag.Element("modelo").Value;
                car.Imagen = tag.Element("imagen").Value;
                cars.Add(car);
            }
            return cars;
        }
    }
}
