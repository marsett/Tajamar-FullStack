namespace BibliotecaLibrosAPI.Models
{
    public class Libro
    {
        // Se definen las propiedades del modelo
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoPublicacion { get; set; }
        public string Genero { get; set; }
    }
}
