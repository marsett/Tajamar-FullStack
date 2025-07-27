﻿using Microsoft.AspNetCore.Mvc;
using MvcCoreApiCrudDepartamentos.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MvcCoreApiCrudDepartamentos.Services
{
    public class ServiceDepartamentos
    {
        private string UrlApi;
        private MediaTypeWithQualityHeaderValue header;
        public ServiceDepartamentos(IConfiguration configuration)
        {
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
            this.UrlApi = configuration.GetValue<string>("ApiUrls:ApiDepartamentos");
        }
        private async Task<T> CallApiAsync<T>(string request)
        {
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.GetAsync(request);
                if(response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            string request = "api/departamentos";
            List<Departamento> data = await this.CallApiAsync<List<Departamento>>(request);
            return data;
        }

        public async Task<Departamento> FindDepartamentoAsync(int idDepartamento)
        {
            string request = "api/departamentos/" + idDepartamento;
            Departamento data = await this.CallApiAsync<Departamento>(request);
            return data;
        }

        // Los métodos de acción que reciben objetos pueden ser
        // genéricos y recibir T
        // Si los métodos reciben la configuración por url
        // si que no suelen ser genéricos
        public async Task InsertDepartamentoAsync(int id, string nombre, string localidad)
        {
            using(HttpClient client = new HttpClient())
            {
                string request = "api/departamentos";
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                // Debemos crear nuestro model a enviar
                Departamento dept = new Departamento();
                dept.IdDepartamento = id;
                dept.Nombre = nombre;
                dept.Localidad = localidad;
                // Convertimso nuestro model a json
                string json = JsonConvert.SerializeObject(dept);
                // Para enviar datos se utiliza StringContent
                // donde debemos enviar el json, el formato y el tipo
                StringContent content = new StringContent
                    (json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync (request, content);
            }
        }

        public async Task UpdateDepartamentoAsync(int id, string nombre, string localidad)
        {
            using(HttpClient client = new HttpClient())
            {
                string request = "api/departamentos";
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                Departamento dept = new Departamento();
                dept.IdDepartamento = id;
                dept.Nombre = nombre;
                dept.Localidad = localidad;
                string json = JsonConvert.SerializeObject(dept);
                StringContent content = new StringContent
                    (json, Encoding.UTF8, "application/json");
                await client.PutAsync(request, content);
            }
        }

        public async Task DeleteDepartamentoAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "api/departamentos/" + id;
                client.BaseAddress = new Uri(this.UrlApi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response = await client.DeleteAsync(request);
            }
        }
    }
}
