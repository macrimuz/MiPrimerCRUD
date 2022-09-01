using Microsoft.AspNetCore.Mvc;
using MiPrimerCRUD.Models;
using MiPrimerCRUD.Services;
using System.Linq;

namespace MiPrimerCRUD.Controllers
{
    public class LinqController : Controller
    {
        private MiContexto ctx;
        private IGeneralService general;

        public LinqController(MiContexto ctx, IGeneralService general)
        {
            this.ctx = ctx;
            this.general = general;
        }

        public IActionResult Index(string? filtro)
        {
            var listado = ctx.Asignaturas.Where(asig => asig.Nombre.Contains(filtro))
                                         .OrderByDescending(Asignatura => Asignatura.Id)
                                         .Take(3);
            ViewBag.Filtro = filtro;
            return View(listado);

        }
        public IActionResult ListaCursos(string? filtro, DateTime? fechaDesde, DateTime? fechaHasta)

        {
            var listado = ctx.Cursos
                .Where(listaCursos => listaCursos.Activo == true);


            if(filtro != null)
            {
                listado = listado.Where(listaCursos => listaCursos.Nombre.Contains(filtro));

            }

            if (fechaDesde != null)
            {
                listado = listado.Where(listaCursos => DateTime.Compare(listaCursos.FechaInicio.Value, fechaDesde.Value) >= 0);
            }
            if (fechaHasta != null)
            {
                listado = listado.Where(listaCursos => DateTime.Compare(listaCursos.FechaInicio.Value, fechaHasta.Value) <= 0);
            } 
                listado = listado.OrderByDescending(listaCursos => listaCursos.Id)
                                    .Take(3);
            
                ViewBag.Filtro = filtro;
                ViewBag.fechaDesde = fechaDesde?.ToString("yyyy-MM-dd");
                ViewBag.fechaHasta = fechaHasta?.ToString("yyyy-MM-dd");
                ViewBag.autor = general.GetAutor();
            
            return View(listado);
        }
    }
}
