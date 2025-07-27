using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoClases.Helpers
{
    public class HelperMascotas
    {
        public List<Mascota> Mascotas { get; set; }
        private string Path;

        public HelperMascotas(string path) 
        {
            this.Mascotas = new List<Mascota>();
            this.Path = path;
        }

        // Necesitamos leer/escribir mascotas de esta colección
        // Convertir la colección a string
        private string ConvertirMascotasString()
        {
            string data = "";
            foreach (Mascota mascota in this.Mascotas)
            {
                // Garfield,Gato
                string temp = mascota.Nombre + "," + mascota.Raza;
                data += temp + "@";

            }
            data = data.TrimEnd('@');
            return data;
        }
        // Convertir el string del read a colección mascotas
        private void ConvertirMascotasList(string data)
        {
            // Garfield, Gato@Pluto, Perro
            // Limpiamos la colección actual
            this.Mascotas.Clear();
            // Separamos el string por cada mascota @
            string[] datosMascotas = data.Split("@");
            foreach (string stringMascota in datosMascotas)
            {
                // Garfield,Gato
                string[] propiedades = stringMascota.Split(",");
                Mascota mascota = new Mascota();
                mascota.Nombre = propiedades[0];
                mascota.Raza = propiedades[1];
                this.Mascotas.Add(mascota);
            }
        }
        // Necesitamos leer/escribir mascotas de esta colección
        public async Task WriteMascotasAsync()
        {
            // Convertimos la colección a string
            string data = this.ConvertirMascotasString();
            await HelperFiles.WriteFileAsync(this.Path, data);
        }

        public async Task ReadMascotasAsync()
        {
            // Leemos el fichero
            string data = await HelperFiles.ReadFileAsync(this.Path);
            this.ConvertirMascotasList(data);
        }
    }
}
