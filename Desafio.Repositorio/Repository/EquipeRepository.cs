using Desafio.Dominio.Models;
using Desafio.Repositorio.Database;
using Desafio.Repositorio.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Desafio.Repositorio.Repository
{
    public class EquipeRepository : IEquipeRepository
    {
        private readonly KulaContext _context;

        public EquipeRepository(KulaContext context)
        {
            _context = context;
        }

        public void Atualizar(Equipe equipe)
        {
            _context.Update(equipe);
            _context.SaveChanges();
        }

        public void Cadastrar(Equipe equipe)
        {
            _context.Add(equipe);
            _context.SaveChanges();
        }

        public void Excluir(int id)
        {
            Equipe equipe = ObterEquipe(id);
            _context.Remove(equipe);
            _context.SaveChanges();
        }

        public Equipe ObterEquipe(int id)
        {
            return _context.Equipes.Find(id);
        }

        public IEnumerable<Equipe> ObterTodas()
        {
            return _context.Equipes.ToList();
        }
    }
}
