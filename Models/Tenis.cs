using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoAspNet.Models
{
	[Table("Tenis")]
	public class Tenis
	{
		[Key]
		public int TenisId{get; set; }


		[Required(ErrorMessage = "O nome do tenis deve ser informado")]
		[StringLength(80, MinimumLength =10, ErrorMessage = "O nome do tenis deve ter de 10 a 80 caracteres")]
		[Display(Name = "Nome do Tenis")]
		public string? TenisNome { get; set; }

		[Required(ErrorMessage = "O nome do tenis deve ser informado")]
		[StringLength(80, MinimumLength = 10, ErrorMessage = "O nome da marca deve ter de 10 a 80 caracteres")]
		[Display(Name = "Nome da Marca")]
		public string? TenisMarca { get; set; }

		[Required(ErrorMessage = "A descrição do tenis deve ser informado")]
		[StringLength(200, MinimumLength = 20, ErrorMessage = "A descrição do tenis deve ter de 20 a 200 caracteres")]
		[Display(Name = "Descricao do Tenis")]
		public string? Descricao { get; set; }

		[Required(ErrorMessage = "O preço do tenis deve ser informado")]
		[Column(TypeName = "decimal(10,2)")]
		[Display(Name = "Preço do Tenis")]
		[Range(1, 5000.00, ErrorMessage = "O preço deve estar entre 1 e 5000 reias")]
		public int Preco { get; set; }

		[Display(Name = "Caminho Imagem")]
		[StringLength(200, ErrorMessage = "O caminho ndeve ter de 1 a 200  caracteres")]
        public string? ImagemUrl { get; set; }

		[Display(Name = "Preferido?")]
        public bool IsTenisPreferido { get; set; }

		[Display(Name ="Estoque")]
		public bool EmEstoque { get; set; }

		public int CategoriaId { get; set; }

		public virtual Categoria? Categoria { get; set; }

	}
}

