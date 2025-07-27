using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoClases
{
    public enum TipoGenero { Masculino, Femenino}
    public enum Paises { España, Euskalherria, Catalunya, Galicia, Andorra}
    public class Persona
    {
        public Persona()
        {
            Debug.WriteLine("Constructor PERSONA vacío");
            this.Domicilio = new Direccion();
        }

        public Persona(string nombre, string apellidos)
        {
            Debug.WriteLine("Constructor PERSONA 2 parámetros");
            this.Nombre = nombre;
            this.Apellidos = apellidos;
        }

        #region PROPIEDADES

        public string _DescripcionThis;

        public string this[int indice]
        {
            get { return this._DescripcionThis; }
            set { 
                Random random = new Random();
                int aleat = random.Next(1, 20);
                this._DescripcionThis = "Descricpión " + aleat;
            }
        }

        public Direccion Domicilio { get; set; }
        public Direccion DomicilioVacaciones { get; set; }

        private TipoGenero _Genero;
        public TipoGenero Genero
        {
            get { return _Genero; }
            set
            {
                if (value != TipoGenero.Masculino && value != TipoGenero.Femenino)
                {
                    throw new Exception("Valor de género incorrecto");
                }
                else
                {
                    this._Genero = value;
                }
            }
        }
        public Paises Nacionalidad { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        // Campo de propiedad
        private int _Edad;
        public int Edad
        {
            get { return _Edad; }
            set
            {
                // Debemos comprobar el valor de la edad
                // que viene en value
                if (value < 0)
                {
                    // Si nos dan un valor incorrecto
                    // Error silencioso
                    // this._Edad = 0;
                    // Lanzamos una excepción
                    throw new Exception("La edad no puede ser negativa");
                }
                else
                {
                    // Todo correcto
                    this._Edad = value;
                }
            }
        }
        #endregion

        #region METODOS
        // Método para devolver un nombre completo
        public string GetNombreCompleto()
        {
            return this.Nombre + " " + this.Apellidos;
        }
        public string GetNombreCompleto(bool mayusculas)
        {
            return this.Nombre + " " + this.Apellidos;
        }
        // Método para devolver apellidos y nombre
        public string GetNombreCompletoDelReves()
        {
            return this.Apellidos + " " + this.Nombre;
        }
        // Método para nombre y apellidos en mayúscula
        public string GetNombreCompletoMayuscula()
        {
            return (this.Nombre + " " + this.Apellidos).ToUpper();
        }
        public string GetNombreCompletoMinuscula()
        {
            return (this.Nombre + " " + this.Apellidos).ToLower();
        }
        #endregion

    }
}
