namespace NetCoreLinqToSqlInjection.Models
{
    public interface ICoche
    {
        // Las interfaces no tienen ámbito ni código
        // en sus propiedades/métodos, solo declaraciones
        string Marca { get; set; }
        string Modelo { get; set; }
        string Imagen { get; set; }
        int Velocidad { get; set; }
        int VelocidadMaxima { get; set; }
        void Acelerar();
        void Frenar();
    }
}
