namespace FundamentosNetCore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Algo aquí...";
            this.SuspendLayout();
        }

        private void btnPulsar_Click(object sender, EventArgs e)
        {
            this.txtNombre.Location = new Point(20, 10);
            this.txtNombre.Text = "Soy un string";
            this.txtNombre.Width = 220;
            this.txtNombre.TextAlign = HorizontalAlignment.Right;
            this.btnPulsar.BackColor = Color.LightGreen;

            // No es conversión automática
            short pequeno = 88;
            int mayor = pequeno;

            // String a primitivo
            string textoNumero = "12345";
            int numero = int.Parse(textoNumero);
            double otro = double.Parse(textoNumero);

            // Cualquier objeto a string
            int num = 88;
            string texto = numero.ToString();
            texto = btnPulsar.ToString();
        }
    }
}
