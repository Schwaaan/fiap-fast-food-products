﻿using FourSix.Controllers.ViewModels;
using FourSix.UseCases.UseCases.Produtos.AlteraProduto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FourSix.Controllers.Adapters.Produtos.AlteraProduto
{
    public class AlteraProdutoAdapter : IAlteraProdutoAdapter
    {
        private readonly IAlteraProdutoUseCase _useCase;

        public AlteraProdutoAdapter(IAlteraProdutoUseCase useCase)
        {
            this._useCase = useCase;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AlteraProdutoResponse))]
        public async Task<AlteraProdutoResponse> Alterar(Guid id, AlteraProdutoRequest produto)
        {
            var model = new ProdutoModel(await _useCase.Execute(id, produto.Nome, produto.Descricao, produto.Categoria, produto.Preco));

            return new AlteraProdutoResponse(model);
        }
    }
}
