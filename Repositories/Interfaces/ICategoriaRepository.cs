using System;
using ProjetoAspNet.Models;

namespace ProjetoAspNet.Repositories.Interfaces
{
	public interface ICategoriaRepository
	{
		IEnumerable<Categoria> Categorias { get;}
	}
}

