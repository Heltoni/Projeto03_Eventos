using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto03_Eventos.Dados;
using Projeto03_Eventos.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Projeto03_Eventos.Controllers
{
    public class EventosController : Controller
    {

        private EventosContext Context { get; set; }

        public EventosController(EventosContext context)
        {
            this.Context = context;
        }

        public IActionResult Index()
        {

            return View();

        }

        public IActionResult Incluir()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Incluir(Evento evento)
        {

            if (ModelState.IsValid)
            {

                Context.Add<Evento>(evento);
                Context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Listar()
        {
            List<Evento> lista = Context.Eventos.ToList<Evento>();            
            return View(lista);
        }

        public IActionResult IncluirParticipante()
        {
            List<Evento> lista = Context.Eventos.ToList<Evento>();
            ViewBag.Eventos = new SelectList(lista, "Id", "Descricao");
            return View();
        }

        [HttpPost]
        public IActionResult IncluirParticipante(Participante participante)
        {
            if (ModelState.IsValid)
            {
                Context.Add<Participante>(participante);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            
                return IncluirParticipante();
            
        }

        public IActionResult ListarParticipantes(int? idEvento)
        {
            List<Participante> lista;
            ViewBag.Eventos = new SelectList(Context.Eventos.ToList<Evento>(), "Id", "Descricao");
            if (idEvento == null)
            {
                lista = Context.Participantes.ToList<Participante>();
            }
            else
            {
                lista = Context.Participantes.Where(p => p.IdEvento == idEvento).ToList<Participante>();
            }
            return View(lista);
        }
    }
}