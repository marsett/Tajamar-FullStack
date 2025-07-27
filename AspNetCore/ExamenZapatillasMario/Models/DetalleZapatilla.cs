namespace ExamenZapatillasMario.Models
{
    public class DetalleZapatilla
    {
        public ZapasPractica Zapatilla { get; set; }
        public List<ImagenesZapasPractica> Imagenes {  get; set; }
        public int NumeroTotalImagenes { get; set; }
        public int RegistrosPorPagina { get; set; }
    }
}
