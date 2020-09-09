using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.API.Validations;
using Desafio.Dominio.Models;
using Desafio.Repositorio.Repository.Contracts;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipeController : ControllerBase
    {
        private readonly IEquipeRepository _equipeRepository;
        private readonly EquipeValidator _equipeValidator;
        private ValidationResult _validationResult;

        public EquipeController(IEquipeRepository equipeRepository, EquipeValidator equipeValidator, ValidationResult validationResult)
        {
            _equipeRepository = equipeRepository;
            _equipeValidator = equipeValidator;
            _validationResult = validationResult;
        }

        [HttpPost]
        [Route("Cadastrar")]
        public IActionResult Cadastrar(Equipe equipe)
        {
            try
            {

                _validationResult = _equipeValidator.Validate(equipe);

                if (!_validationResult.IsValid)
                {
                    foreach (var failure in _validationResult.Errors)
                    {
                        Console.WriteLine("property " + failure.PropertyName + " failed validation. error was: " + failure.ErrorMessage);
                    }
                }

                _equipeRepository.Cadastrar(equipe);
                return Ok("Equipe cadastrada com sucesso!");

            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("Atualizar")]
        public IActionResult Atualizar(Equipe equipe)
        {
            try
            {
                _equipeRepository.Atualizar(equipe);
                return Ok("Equipe atualizada com sucesso!");

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
                _equipeRepository.Excluir(id);
                return Ok("Registro excluído com sucesso!");
            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("ObterEquipe")]
        public IActionResult ObterEquipe(int id)
        {
            try
            {
                _equipeRepository.ObterEquipe(id);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("ObterTodas")]
        public List<Equipe> ObterTodas()
        {
            return _equipeRepository.ObterTodas().ToList();
        }
    }
}
