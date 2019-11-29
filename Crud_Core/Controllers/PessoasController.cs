using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Crud_Core.Models;
using Microsoft.AspNetCore.Cors;
using System.Net;
using System.Data.SqlClient;
using System.Text;
using Crud_Core.Business;

namespace Crud_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors()]
    public class PessoasController : ControllerBase
    {
        private readonly PessoaContexto _context;

        public PessoasController(PessoaContexto context)
        {
            _context = context;
        }

        // GET: api/Pessoas
        [HttpGet]
        public ActionResult<PessoaDominio> GetPessoas()
        {
            IList <PessoaDominio> pessoas = null;
            pessoas = _context.Pessoas.Select(s => new PessoaDominio()
            {
                ID = s.ID,
                CPF = s.CPF,
                Nome = s.Nome,
                Sobre_Nome = s.Sobre_Nome,
                Email = s.Email,
                Sexo = s.Sexo,
                DT_Nascimento = s.DT_Nascimento
            }).ToList<PessoaDominio>();
            if (pessoas.Count == 0)
            {
                return NotFound("Dados não Encontrados.");
            }
            return Ok(pessoas);
        }

        // GET: api/Pessoas/5
        [HttpGet("{id}")]
        public ActionResult<PessoaDominio> GetPessoaDominio(int id)
        {
            PessoaDominio pessoa = null;
            pessoa = _context.Pessoas
                .Where(s => s.ID == id)
                .Select(s => new PessoaDominio()
                {
                    ID = s.ID,
                    CPF = s.CPF,
                    Nome = s.Nome,
                    Sobre_Nome = s.Sobre_Nome,
                    Email = s.Email,
                    Sexo = s.Sexo,
                    DT_Nascimento = s.DT_Nascimento
                }).FirstOrDefault<PessoaDominio>();

            if (pessoa == null)
            {
                return NotFound("ID não Encontrado.");
            }

            return Ok(pessoa);
        }

        // PUT: api/Pessoas/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        
        [HttpPut("{id}")]
        public ActionResult PutPessoaDominio(PessoaDominio pessoaDominio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados Inválidos");
            }

            var PessoaExists = _context.Pessoas
                .Where(s => s.ID == pessoaDominio.ID).FirstOrDefault<PessoaDominio>();
            
            if(PessoaExists != null)
            {
                PessoaExists.ID = pessoaDominio.ID;
                PessoaExists.CPF = pessoaDominio.CPF;
                PessoaExists.Nome = pessoaDominio.Nome;
                PessoaExists.Sobre_Nome = pessoaDominio.Sobre_Nome;
                PessoaExists.Email = pessoaDominio.Email;
                PessoaExists.Sexo = pessoaDominio.Sexo;
                PessoaExists.DT_Nascimento = pessoaDominio.DT_Nascimento;

                _context.SaveChanges();
            }
            else
            {
                return NotFound("ID não Encontrado.");
            }
            return Ok();
        }

        // POST: api/Pessoas
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<PessoaDominio> PostPessoaDominio(PessoaDominio pessoaDominio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados Inválidos.");
            }
            _context.Pessoas.Add(new PessoaDominio()
            {
                ID = pessoaDominio.ID,
                CPF = pessoaDominio.CPF,
                Nome = pessoaDominio.Nome,
                Sobre_Nome = pessoaDominio.Sobre_Nome,
                Email = pessoaDominio.Email,
                Sexo = pessoaDominio.Sexo,
                DT_Nascimento = pessoaDominio.DT_Nascimento
            }); 

            _context.SaveChanges();

            return CreatedAtAction("GetPessoaDominio", new { id = pessoaDominio.ID }, pessoaDominio);
        }

        // DELETE: api/Pessoas/5
        [HttpDelete("{id}")]
        public ActionResult<PessoaDominio> DeletePessoaDominio(int id)
        {
            var pessoaDominio = _context.Pessoas.Find(id);
            if (pessoaDominio == null)
            {
                return NotFound("ID não Encontrado.");
            }

            _context.Pessoas.Remove(pessoaDominio);
            _context.SaveChanges();

            return Ok();
        }

    }
}
