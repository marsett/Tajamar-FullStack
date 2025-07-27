using NugetCustomersMJM;
using NugetCarsMJM;
using NugetAeropuertosMJM;
using NugetCustomersMJM.Models;
using NugetCustomersMJM.Services;
using NugetCarsMJM.Repositories;
using NugetCarsMJM.Models;
using NugetAeropuertosMJM.Models;

namespace TestingNugetCustomers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            ServiceCustomers service = new ServiceCustomers();
            CustomersList data = await service.GetCustomersListAsync();
            List<Customer> clients = data.Customers;
            foreach (Customer c in clients)
            {
                this.lstCustomers.Items.Add(c.Contacto + ", " + c.Empresa);
            }
        }

        private async void btnReadCars_Click(object sender, EventArgs e)
        {
            RepositoryCoches repo = new RepositoryCoches();
            List<Coche> coches = repo.GetCoches();
            this.lstCustomers.Items.Clear();
            foreach (Coche car in coches)
            {
                this.lstCustomers.Items.Add(car.Marca + ", " + car.Modelo);
            }
        }

        private async void btnLeerAeropuertos_Click(object sender, EventArgs e)
        {
            ServiceAeropuertos service = new ServiceAeropuertos();
            AeropuertosList data = await service.GetAeropuertosListAsync();
            List<Aeropuerto> aeropuertos = data.Aeropuertos;
            foreach (Aeropuerto a in aeropuertos)
            {
                this.lstCustomers.Items.Add(a.IdAeropuerto + ", " + a.Nombre);
            }
        }
    }
}
