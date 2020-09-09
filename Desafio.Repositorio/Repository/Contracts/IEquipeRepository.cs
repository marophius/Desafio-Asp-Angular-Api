using Desafio.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Repositorio.Repository.Contracts
{
    public interface IEquipeRepository
    {
        //CRUDs
        void Cadastrar(Equipe equipe);
        void Atualizar(Equipe equipe);
        void Excluir(int id);

        Equipe ObterEquipe(int id);
        IEnumerable<Equipe> ObterTodas();
    }
}
