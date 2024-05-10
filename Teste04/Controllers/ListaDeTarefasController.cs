using Microsoft.AspNetCore.Mvc;
using Teste04.Models;

namespace Teste04.Controllers
{
    public class ListaDeTarefasController : Controller
    {
        //  "_lista" é uma variável estática que simula um banco de dados temporário na memória para este exemplo.
        //  Ela é uma lista de tarefas que é inicializada com alguns dados de exemplo no código do controlador.
        private static List<Tarefa> _tarefas = new List<Tarefa>()
        {
            new Tarefa { TarefaID=1, Nome="Tarefa 1", Desc="Desc 1 Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum ", DtInicio=DateTime.Today, Status=false },
            new Tarefa { TarefaID=2, Nome="Tarefa 2", Desc="Desc 2 Lorem Ipsum Lorem Ipsum ", DtInicio=DateTime.Today, Status=false },
            new Tarefa { TarefaID=3, Nome="Tarefa 3", Desc="Desc 3 Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum Lorem Ipsum ", DtInicio=DateTime.Today, Status=false },
        };

        public IActionResult Index()
        {
            return View(_tarefas);
        }

        // CRUD Lista de Tarefas

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Tarefa tarefa)
        {  

            if (ModelState.IsValid)
            {
                // Se o valor de ListaDeTarefasID > 0 então some + 1 a ListaDeTarefasID  senão atribua 1 ao ListaDeTarefasID
                tarefa.TarefaID = _tarefas.Count > 0 ? _tarefas.Max(c => c.TarefaID) + 1 : 1;

                tarefa.DtInicio = DateTime.Today;

                _tarefas.Add(tarefa);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(c => c.TarefaID == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }

        [HttpPost]
        public IActionResult Edit(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                var existingTarefa = _tarefas.FirstOrDefault(c => c.TarefaID == tarefa.TarefaID);
                if (existingTarefa != null)
                {
                    existingTarefa.Nome = tarefa.Nome;
                    existingTarefa.Desc = tarefa.Desc;
                }
                return RedirectToAction("Index");
            }
            return View(tarefa);
        }

        public IActionResult Delete(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(c => c.TarefaID == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            _tarefas.Remove(tarefa);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(c => c.TarefaID == id);
            if (tarefa != null)
            {
                return View(tarefa);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult ToggleStatus(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(c => c.TarefaID == id);

            if (tarefa != null)
            {
                if (!tarefa.Status)
                {
                    tarefa.Status = true;
                    tarefa.DtFim = DateTime.Today;
                }
                else
                {
                    tarefa.Status = false;
                }
            }
            
            return RedirectToAction("Index");
        }

    }
}
