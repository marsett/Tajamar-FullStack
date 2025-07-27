﻿using Azure.Data.Tables;
using Microsoft.AspNetCore.Mvc;
using MvcCoreSasAzureStorage.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace MvcCoreSasAzureStorage.Services
{
    public class ServiceAzureAlumnos
    {
        private TableClient tableAlumnos;
        // Necesitamos la url de acceso al token
        private string UrlApi;
        public ServiceAzureAlumnos(IConfiguration configuration)
        {
            this.UrlApi = configuration.GetValue<string>("ApiUrls:ApiAzureToken");
        }
        private async Task<string> GetTokenAsync(string curso)
        {
            using(HttpClient client = new HttpClient())
            {
                string request = "token/" + curso;
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    JObject keys = JObject.Parse(data);
                    string token = keys.GetValue("token").ToString();
                    return token;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<List<Alumno>> GetAlumnosAsync(string curso)
        {
            string token = await this.GetTokenAsync(curso);
            // Lo que nos devuelve el token es una url
            Uri uriToken = new Uri(token);
            // Para acceder al recurso, simplemente creamos
            // el recurso mediante un Uri
            this.tableAlumnos = new TableClient(uriToken);
            List<Alumno> alumnos = new List<Alumno>();
            var query = this.tableAlumnos.QueryAsync<Alumno>(filter: "");
            await foreach(var item in query)
            {
                alumnos.Add(item);
            }
            return alumnos;
        }
        [HttpPost]
        public async Task CreateAlumno(int idAlumno, string nombre, string apellidos, int nota)
        {
            string curso = "EN PROCESO";
            string token = await this.GetTokenAsync(curso);
            Alumno alumno = new Alumno();
            alumno.IdAlumno = idAlumno;
            alumno.Curso = "AZURE";
            alumno.Nombre = nombre;
            alumno.Apellidos = apellidos;
            alumno.Nota = nota;
            Uri uriToken = new Uri(token);
            this.tableAlumnos = new TableClient(uriToken);
            await this.tableAlumnos.AddEntityAsync<Alumno>(alumno);
        }
    }
}
