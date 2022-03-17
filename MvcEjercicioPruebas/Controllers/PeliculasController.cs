using MvcEjercicioPruebas.Models;
using Microsoft.AspNetCore.Mvc;
using MvcEjercicioPruebas.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEjercicioPruebas.Controllers
{
    public class PeliculasController : Controller
    {
        private ServicePeliculas service;

        public PeliculasController(ServicePeliculas service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Peliculas()
        {
            List<Pelicula> peliculas = await this.service.GetPeliculas();
            return View(peliculas);
        }

        public async Task<IActionResult> DetallesPelicula(int idPelicula)
        {
            Pelicula pelicula = await this.service.FindPelicula(idPelicula);
            return View(pelicula);
        }

        public async Task<IActionResult> UpdatePelicula(int idPelicula)
        {
            Pelicula pelicula = await this.service.FindPelicula(idPelicula);
            return View(pelicula);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePelicula(Pelicula pelicula)
        {
            await this.service.UpdatePelicula(pelicula);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeletePelicula(int idPelicula)
        {
            await this.service.DeletePelicula(idPelicula);
            return RedirectToAction("Peliculas");
        }

        public IActionResult InsertPelicula()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertPelicula(Pelicula pelicula)
        {
            await this.service.InsertPelicula(pelicula.idPelicula, pelicula.idDistribuidor, pelicula.idGenero,
                                    pelicula.titulo, pelicula.idNacionalidad, pelicula.argumento
                                    , pelicula.foto, pelicula.fechaEstreno, pelicula.actores, pelicula.duracion);
            return RedirectToAction("Peliculas");
        }
    }
}
