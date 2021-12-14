using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartSchool.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly SmartContext _context;
        public AlunoController(SmartContext context) 
        {
            _context = context;
        }

        //public List<Aluno> Alunos = new List<Aluno> { 
        //    new Aluno()
        //    {
        //        Id = 1,
        //        Nome = "Willian",
        //        Sobrenome = "Trindade",
        //        Telefone = "(65)9 9258-2714"
        //    },
        //    new Aluno()
        //    {
        //        Id = 2,
        //        Nome = "Jocimara",
        //        Sobrenome = "Trindade",
        //        Telefone = "(65)9 9272-8058"
        //    },
        //    new Aluno()
        //    {
        //        Id = 3,
        //        Nome = "Alice",
        //        Sobrenome = "Trindade",
        //        Telefone = "(65)9 9212-2058"
        //    },
        //    new Aluno()
        //    {
        //        Id = 4,
        //        Nome = "Pedro",
        //        Sobrenome = "Trindade",
        //        Telefone = "(65)9 9212-3333"
        //    },

        //};
        
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        //[HttpGet ("{id:int}")]
        //[HttpGet("byId")]
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado!");
            return Ok(aluno);
        }

        //[HttpGet("{nome}")]
        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) &&
                                                     a.Sobrenome.Contains(sobrenome));
            if (aluno == null) return BadRequest("O Aluno não foi encontrado!");
            return Ok(aluno);
        }
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _context.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("Aluno Não encontrado!");

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("Aluno Não encontrado!");
            
            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno Inexistente!");

            _context.Remove(aluno);
            _context.SaveChanges();
            return Ok();
        }
    }
}
