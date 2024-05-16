using FourSix.Domain.Entities.ProdutoAggregate;

namespace FourSix.Controllers.ViewModels
{
    public class ProdutoModel
    {
        public ProdutoModel(Produto produto)
        {
            Id = produto.Id;
            Nome = produto.Nome;
            Descricao = produto.Descricao;
            Categoria = produto.Categoria;
            Preco = produto.Preco;
        }
        public Guid Id { get; }
        public string Nome { get; }
        public string Descricao { get; }
        public EnumCategoriaProduto Categoria { get; }
        public decimal Preco { get; }
    }
}
