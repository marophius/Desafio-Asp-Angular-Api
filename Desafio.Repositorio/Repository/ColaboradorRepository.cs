using Desafio.Dominio.Models;
using Desafio.Repositorio.Database;
using Desafio.Repositorio.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Desafio.Repositorio.Repository
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly KulaContext _context;

        public ColaboradorRepository(KulaContext context)
        {
            _context = context;
        }

        public void Atualizar(Colaborador colaborador)
        {
            _context.Update(colaborador);
            _context.SaveChanges();
        }

        public void Cadastrar(Colaborador colaborador)
        {
            _context.Add(colaborador);
            _context.SaveChanges();
        }

        public void Excluir(int id)
        {
            Colaborador colaborador = ObterColaborador(id);
            _context.Remove(colaborador);
            _context.SaveChanges();
        }

        public Colaborador ObterColaborador(int id)
        {
            return _context.Colaboradores.Find(id);
        }

        public List<Colaborador> ObterTodos()
        {
            return _context.Colaboradores.ToList();
        }
    }
}
