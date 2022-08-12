using System;
using ProjetoAspNet.Models;

namespace ProjetoAspNet.ViewModels
{
	public class ListarTenisViewModel
	{

		public IEnumerable<Tenis> Tenis { get; set; }

		public string CategoriaAtual { get; set; }

	}
}

