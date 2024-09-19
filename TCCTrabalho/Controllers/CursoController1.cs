using Microsoft.AspNetCore.Mvc;
using TCCTrabalho.Data;
using TCCTrabalho.Models;

namespace TCCTrabalho.Controllers
{
    public class CursoController1 : Controller
    {
        readonly private ApplicationDbContext _db;

        public CursoController1(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<CursoModel> cursos = _db.Cursos;


            return View(cursos);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            CursoModel curso = _db.Cursos.FirstOrDefault(x => x.Id == id);

            if (curso == null)
            {
                return NotFound();
            }


            return View(curso);
        }
        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null || null == 0)
            {
                return NotFound();
            }
            CursoModel curso = _db.Cursos.FirstOrDefault(x => x.Id == id);

            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        [HttpPost]
        public IActionResult Cadastrar(CursoModel cursos)
        {
            if (ModelState.IsValid)
            {
                _db.Cursos.Add(cursos);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Cadastro realizado com sucesso!";

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Editar(CursoModel curso)
        {
            if (!ModelState.IsValid)
            {
                _db.Cursos.Update(curso);
                _db.SaveChanges();

                TempData["MensagemSucesso"] = "Edição realizado com sucesso!";


                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Algum erro ocorreu ao realizar edição!";

            return View(curso); 
                
        }
        [HttpPost]
        public IActionResult Excluir(CursoModel curso)
        {
            if (curso == null)
            {
                return NotFound();
            }

            TempData["MensagemSucesso"] = "Exclusão realizado com sucesso!";


            _db.Cursos.Remove(curso);
            _db.SaveChanges();

            return RedirectToAction("Index");   
        }
    }   
}


