using Desafio.Dominio.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.API.Validations
{
    public class ColaboradorValidator : AbstractValidator<Colaborador>
    {
        public ColaboradorValidator()
        {
            RuleFor(c => c.Endereco)
                .NotNull().WithMessage("Endereço é um campo obrigatório, não pode ser vazio!")
                .NotEmpty()
                .WithMessage("Endereço é um campo obrigatório, e não pode ser vazio!");
            RuleFor(c => c.DataNascimento)
                .NotNull().WithMessage("Data é um campo obrigatório e não pode ser vazio!")
                .NotEmpty().WithMessage("Data é um campo obrigatório e não pode ser vazio!");

            //Eu tentei trabalhar com o DateTime, porém não consegui.
            //RuleFor(c => c.DataNascimento)
            //    .NotNull()
            //    .WithMessage("A data é um campo obrigatório e não pode ser nulo!")
            //    .GreaterThan(DateTime.Today).WithMessage("Data inválida!");

            /*
             * No caso abaixo, poucos usuarios saberâo a diferença entre nulo e vazio,
             * embora que caso o usuário esteja fazendo um dos dois, não muda que ele
             * esteja cometendo um erro, mas eu preferi deixar a mesma mensagem para os 2
             */
            RuleFor(c => c.Genero)
                .NotNull().WithMessage("Gênero é um campo obrigatório, não pode ser vazio!")
                .NotEmpty().WithMessage("Gênero é um campo obrigatório, não pode ser vazio!");
            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("Telefone é um campo obritário, não pode ser vazio")
                .NotNull().WithMessage("Telefone é um campo obrigatório, não pode ser vazio");
        }
    }
}
