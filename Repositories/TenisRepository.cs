using System;
using Microsoft.EntityFrameworkCore;
using ProjetoAspNet.Context;
using ProjetoAspNet.Models;
using ProjetoAspNet.Repositories.Interfaces;

namespace ProjetoAspNet.Repositories
{
    public class TenisRepository : ITenisRepository
    {

        private readonly AppDbContext _context;

        public TenisRepository(AppDbContext contexto)
        {
            _context = contexto;
        }
        public IEnumerable<Tenis> Tenis => _context.Tenis.Include(c => c.Categoria);

        public IEnumerable<Tenis> TenisPreferidos => _context.Tenis
            .Where(t => t.IsTenisPreferido)
            .Include(c => c.Categoria);

        public Tenis GetTenisById(int tenisId)
        {
            return _context.Tenis.FirstOrDefault(t => t.TenisId == tenisId);
        }

    }
}

