﻿using Microsoft.Extensions.Options;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{    
    public class CatalogoService : Service, ICatalogoService
    {
        private readonly HttpClient _httpCliente;

        public CatalogoService(HttpClient httpCliente, IOptions<AppSettings> appSettings)
        {
            httpCliente.BaseAddress = new Uri(appSettings.Value.CatalogoUrl);

            _httpCliente = httpCliente;
        }        

        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            var response = await _httpCliente.GetAsync($"/catalogo/produtos/");

            TratarErroResponse(response);

            return await DeserializarJsonParaObjeto<IEnumerable<ProdutoViewModel>>(response);
        }

        public async Task<ProdutoViewModel> ObterPorId(Guid id)
        {
            var response = await _httpCliente.GetAsync($"/catalogo/produtos/{id}");

            TratarErroResponse(response);

            return await DeserializarJsonParaObjeto<ProdutoViewModel>(response);
        }
    }


}
