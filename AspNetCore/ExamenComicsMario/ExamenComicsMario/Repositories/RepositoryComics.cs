using ExamenComicsMario.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Numerics;

namespace ExamenComicsMario.Repositories
{
    public class RepositoryComics
    {
        private DataTable tablaComics;
        private SqlConnection cn;
        private SqlCommand com;

        public RepositoryComics()
        {
            string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=COMICS;Persist Security Info=True;User ID=sa;Encrypt=True;Trust Server Certificate=True";
            string sql = "select * from COMICS";
            SqlDataAdapter adDoc = new SqlDataAdapter(sql, connectionString);
            this.tablaComics = new DataTable();
            adDoc.Fill(this.tablaComics);
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public List<Comic> GetComics()
        {
            var consulta = from datos in this.tablaComics.AsEnumerable() select datos;
            List<Comic> comics = new List<Comic>();
            foreach (var row in consulta)
            {
                Comic comic = new Comic()
                {
                    IdComic = row.Field<int>("IDCOMIC"),
                    Nombre = row.Field<string>("NOMBRE"),
                    Imagen = row.Field<string>("IMAGEN"),
                    Descripcion = row.Field<string>("DESCRIPCION")
                };
                comics.Add(comic);
            }
            return comics;
        }

        public void InsertComic(Comic comic)
        {
            var consulta = from datos in this.tablaComics.AsEnumerable()
                           select datos;

            int idMaximo = consulta.Max(x => x.Field<int>("IDCOMIC"));

            string sql = "INSERT INTO COMICS (IDCOMIC, NOMBRE, " +
                " IMAGEN, DESCRIPCION) " +
             "VALUES (@idcomic, @nombre, @imagen, @descripcion)";
            
            this.com.Parameters.AddWithValue("@idcomic", idMaximo + 1);
            this.com.Parameters.AddWithValue("@nombre", comic.Nombre);
            this.com.Parameters.AddWithValue("@imagen", comic.Imagen);
            this.com.Parameters.AddWithValue("@descripcion", comic.Descripcion);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
        }

        public List<string> GetNombresComics()
        {
            var consulta = (from datos in this.tablaComics.AsEnumerable()
                            select datos.Field<string>("NOMBRE")).Distinct();
            return consulta.ToList();
        }

        public Comic GetDetalleComic(string comic)
        {
            var consulta = from datos in this.tablaComics.AsEnumerable()
                           where datos.Field<string>("NOMBRE") == comic
                           select datos;
            Comic comic1 = null;
            foreach(var row in consulta)
            {
                comic1 = new Comic
                {
                    IdComic = row.Field<int>("IDCOMIC"),
                    Nombre = row.Field<string>("NOMBRE"),
                    Imagen = row.Field<string>("IMAGEN"),
                    Descripcion = row.Field<string>("DESCRIPCION")
                };
            }
            return comic1;
        }

    }
}
