using Exercicio01.Models.Repositorio;
using Exercicio01.Respositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercicio01.Controllers
{
    public class EscolaController : Controller
    {
        // GET: Nota
        public ActionResult Index()
        {
            List<Notas> notas = new NotasRepositorio().ObterTodos();
            ViewBag.Notas = notas;
            ViewBag.Titulo = "Alunos";
            return View();
        }

        public ActionResult Cadastro()
        {
            ViewBag.Titulo = "Alunos-Cadastro";
            ViewBag.Notas = new Notas();
            return View();

        }

        public ActionResult Editar(int id)
        {
            ViewBag.Titulo = "Alunos-Editar";
            Notas notas = new NotasRepositorio().ObterPeloId(id);
            ViewBag.Notas = notas;
            return Redirect("Alunos");
        }

        public ActionResult Excluir(int id)
        {
            bool apagado = new NotasRepositorio().Excluir(id);
            return Redirect("Index");
        }

        public ActionResult Updade(Notas notas)
        {
            bool alterado = new NotasRepositorio().Alterar(notas);
            return null;
        }

        public ActionResult Store(Notas notas)
        {

            int id = new NotasRepositorio().Cadastrar(notas);
            return RedirectToAction("Index", new { id = id });

        }
    }
}