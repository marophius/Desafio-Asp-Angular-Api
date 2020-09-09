using Desafio.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Repositorio.Repository.Contracts
{
    public interface IColaboradorRepository
    {
        // CRUDs
        void Cadastrar(Colaborador colaborador);
        void Atualizar(Colaborador colaborador);
        void Excluir(int id);

        Colaborador ObterColaborador(int id);
        List<Colaborador> ObterTodos();
    }
}
