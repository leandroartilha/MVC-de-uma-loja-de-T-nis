using System;
using ProjetoAspNet.Context;
using ProjetoAspNet.Models;
using ProjetoAspNet.Repositories.Interfaces;

namespace ProjetoAspNet.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}

