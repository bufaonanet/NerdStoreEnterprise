﻿using Microsoft.Extensions.Options;
using NSE.Core.Communication;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public interface IComprasBffService
    {
        Task<CarrinhoViewModel> ObterCarrinho();
        Task<int> ObterQuantidadeCarrinho();
        Task<ResponseResult> AdicionarItemCarrinho(ItemCarrinhoViewModel produto);
        Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId, ItemCarrinhoViewModel produto);
        Task<ResponseResult> RemoverItemCarrinho(Guid produtoId);
        Task<ResponseResult> AplicarVoucherCarrinho(string voucher);
    }

    public class ComprasBffService : Service, IComprasBffService
    {
        private readonly HttpClient _httpClient;

        public ComprasBffService(HttpClient httpCliente, IOptions<AppSettings> appSettings)
        {
            httpCliente.BaseAddress = new Uri(appSettings.Value.ComprasBffUrl);

            _httpClient = httpCliente;
        }

        public async Task<CarrinhoViewModel> ObterCarrinho()
        {
            var response = await _httpClient.GetAsync("/compras/carrinho/");

            TratarErrosResponse(response);

            return await DeserializarJsonParaObjeto<CarrinhoViewModel>(response);
        }

        public async Task<int> ObterQuantidadeCarrinho()
        {
            var response = await _httpClient.GetAsync("/compras/carrinho-quantidade/");

            TratarErrosResponse(response);

            return await DeserializarJsonParaObjeto<int>(response);
        }

        public async Task<ResponseResult> AdicionarItemCarrinho(ItemCarrinhoViewModel produto)
        {
            var itemContent = SerializarObjetoParaJson(produto);

            var response = await _httpClient.PostAsync("/compras/carrinho/items/", itemContent);

            if (!TratarErrosResponse(response)) return await DeserializarJsonParaObjeto<ResponseResult>(response);

            return RetornoOk();
        }

        public async Task<ResponseResult> AtualizarItemCarrinho(Guid produtoId, ItemCarrinhoViewModel produto)
        {
            var itemContent = SerializarObjetoParaJson(produto);

            var response = await _httpClient.PutAsync($"/compras/carrinho/items/{produto.ProdutoId}", itemContent);

            if (!TratarErrosResponse(response)) return await DeserializarJsonParaObjeto<ResponseResult>(response);

            return RetornoOk();
        }


        public async Task<ResponseResult> RemoverItemCarrinho(Guid produtoId)
        {
            var response = await _httpClient.DeleteAsync($"/compras/carrinho/items/{produtoId}");

            if (!TratarErrosResponse(response)) return await DeserializarJsonParaObjeto<ResponseResult>(response);

            return RetornoOk();
        }

        public async Task<ResponseResult> AplicarVoucherCarrinho(string voucher)
        {
            var itemContent = SerializarObjetoParaJson(voucher);

            var response = await _httpClient.PostAsync("/compras/carrinho/aplicar-voucher/", itemContent);

            if (!TratarErrosResponse(response)) return await DeserializarJsonParaObjeto<ResponseResult>(response);

            return RetornoOk();
        }
    }


}
