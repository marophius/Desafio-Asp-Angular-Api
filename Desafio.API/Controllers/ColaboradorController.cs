using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Dominio.Models;
using Desafio.Repositorio.Repository.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorController(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar(Colaborador colaborador)
        {
            try
            {
                _colaboradorRepository.Cadastrar(colaborador);
                return Ok("Colaborador cadastrado com sucesso!");

            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("Atualizar")]
        public IActionResult Atualizar(Colaborador colaborador)
        {
            try
            {
                _colaboradorRepository.Atualizar(colaborador);
                return Ok("Registro atualizado com sucesso!");

            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("Excluir")]
        public IActionResult Excluir(int id)
        {
            try
            {
                _colaboradorRepository.Excluir(id);
                return Ok("Registro excluído com sucesso!");
            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("ObterColaborador")]
        public IActionResult ObterColaborador(int id)
        {
            try
            {
               _colaboradorRepository.ObterColaborador(id);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("ObterTodos")]
        public List<Colaborador> ObterTodos()
        {
            return _colaboradorRepository.ObterTodos();
        }
    }
}
