using MvcEjercicioPruebas.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MvcEjercicioPruebas.Services
{
    public class ServicePeliculas
    {
        private Uri UriApi;
        private MediaTypeWithQualityHeaderValue Header;

        public ServicePeliculas(string url)
        {
            this.UriApi = new Uri(url);
            this.Header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = this.UriApi;
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                HttpResponseMessage response =
                    await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
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

        public async Task<Pelicula> FindPelicula(int idPelicula)
        {
            string request = "/api/peliculas/" + idPelicula;
            Pelicula pelicula =
                await this.CallApiAsync<Pelicula>(request);
            return pelicula;
        }

        public async Task<List<Pelicula>> GetPeliculas()
        {
            string request = "/api/peliculas";
            List<Pelicula> peliculas =
                await this.CallApiAsync<List<Pelicula>>(request);
            return peliculas;
        }
        public async Task UpdatePelicula(Pelicula pelicula)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "/api/peliculas";
                client.BaseAddress = this.UriApi;
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                Pelicula peli = await FindPelicula(pelicula.idPelicula);
                peli.idPelicula = pelicula.idPelicula;
                peli.idDistribuidor = pelicula.idDistribuidor;
                peli.idGenero = pelicula.idGenero;
                peli.titulo = pelicula.titulo;
                peli.idNacionalidad = pelicula.idNacionalidad;
                peli.argumento = pelicula.argumento;
                peli.foto = pelicula.foto;
                peli.fechaEstreno = pelicula.fechaEstreno;
                peli.actores = pelicula.actores;
                peli.duracion = pelicula.duracion;
                string json = JsonConvert.SerializeObject(pelicula);
                StringContent content = new StringContent
                    (json, Encoding.UTF8, "application/json");
                HttpResponseMessage response =
                    await client.PutAsync(request, content);
            }
        }

        public async Task InsertPelicula(int idPelicula, int idDistribuidor, int idGenero,
                                    string Titulo, int idNacionalidad, string Argumento
                                    , string Foto, DateTime FechaEstreno, string Actores, string Duracion)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "/api/peliculas";
                client.BaseAddress = this.UriApi;
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                Pelicula pelicula = new Pelicula
                {
                    idPelicula = idPelicula,
                    idDistribuidor = idDistribuidor,
                    idGenero = idGenero,
                    titulo = Titulo,
                    idNacionalidad = idNacionalidad,
                    argumento = Argumento,
                    foto = Foto,
                    fechaEstreno = FechaEstreno,
                    actores = Actores,
                    duracion = Duracion
                };
                string json = JsonConvert.SerializeObject(pelicula);
                StringContent content = new StringContent
                    (json, Encoding.UTF8, "application/json");
                HttpResponseMessage response =
                    await client.PostAsync(request, content);
            }
        }

        public async Task DeletePelicula(int idPelicula)
        {
            using (HttpClient client = new HttpClient())
            {
                string request = "/api/Peliculas/" + idPelicula;
                client.BaseAddress = this.UriApi;
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.Header);
                await client.DeleteAsync(request);
            }
        }
    }
}
