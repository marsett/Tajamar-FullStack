using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdoNetCore.Models;
using AdoNetCore.Repositories;
using Microsoft.Data.SqlClient;

#region PROCEDIMIENTOS ALMACENADOS
/*
create procedure SP_ALL_DEPARTAMENTOS
as
	select * from DEPT
go
create procedure SP_EMPLEADOS_DEPT_OUT
(@nombre nvarchar(50), @suma int OUT, @media int OUT, @personas int OUT)
as
	declare @id int
	select @id = DEPT_NO from DEPT
	where DNOMBRE = @nombre
	select * from EMP where DEPT_NO = @id
	select @suma = SUM(SALARIO), @media = AVG(SALARIO),
    @personas = COUNT(EMP_NO) from EMP
	where DEPT_NO = @id
go
*/
#endregion

namespace AdoNetCore
{
    public partial class Form13ParametrosSalida : Form
    {
        RepositoryParametrosOut repo;
        public Form13ParametrosSalida()
        {
            InitializeComponent();
            this.repo = new RepositoryParametrosOut();
            this.LoadDepartamentos();
        }

        private async Task LoadDepartamentos()
        {
            List<string> departamentos = await this.repo.GetDepartamentosAsync();
            this.cmbDepartamentos.Items.Clear();
            foreach (string nombre in departamentos)
            {
                this.cmbDepartamentos.Items.Add(nombre);
            }
        }
        private async void btnMostrarDatos_Click(object sender, EventArgs e)
        {
            
            string nombre = this.cmbDepartamentos.SelectedItem.ToString();
            this.lstEmpleados.Items.Clear();
            this.txtSumaSalarial.Clear();
            this.txtMediaSalarial.Clear();
            this.txtPersonas.Clear();
            ParametrosSalida datos = await this.repo.GetDatosAsync(nombre);
            foreach(string apellido in datos.Apellidos)
            {
                this.lstEmpleados.Items.Add(apellido);
            }
            
            this.txtSumaSalarial.Text = datos.SumaSalarial.ToString();
            this.txtMediaSalarial.Text = datos.MediaSalarial.ToString();
            this.txtPersonas.Text = datos.Personas.ToString();
        }
    }
}
