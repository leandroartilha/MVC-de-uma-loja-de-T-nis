using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoAspNet.Models
{
	[Table("CarrinhoCompraItens")]
	public class CarrinhoCompraItem
	{
		public int CarrinhoCompraItemId { get; set; }

		public Tenis Tenis { get; set; }

		public int Quantidade { get; set; }

		[StringLength(200)]
		public string CarrinhoCompraId { get; set; }
	}
}

