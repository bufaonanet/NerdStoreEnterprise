using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public class AutenticacaoService : Service, IAutenticacaoService
    {
        private readonly HttpClient _httpCliente;       

        public AutenticacaoService(HttpClient httpCliente, IOptions<AppSettings> appSettings)
        {
            httpCliente.BaseAddress = new Uri(appSettings.Value.AutenticacaoUrl);

            _httpCliente = httpCliente;
        }

        public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        {
            var loginContent = SerializarObjetoParaJson(usuarioLogin);

            var response = await _httpCliente.PostAsync("/api/identidade/autenticar", loginContent);

            if (!TratarErroResponse(response))
            {
                //var teste = response.Content.ReadAsStringAsync();

                return new UsuarioRespostaLogin
                {
                    ResponseResult = await DeserializarJsonParaObjeto<ResponseResult>(response)
                };
            }

            return await DeserializarJsonParaObjeto<UsuarioRespostaLogin>(response);
        }

        public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro)
        {
            var registroContent = SerializarObjetoParaJson(usuarioRegistro);

            var response = await _httpCliente.PostAsync("/api/identidade/nova-conta", registroContent);

            if (!TratarErroResponse(response))
            {
                return new UsuarioRespostaLogin
                {
                    ResponseResult = await DeserializarJsonParaObjeto<ResponseResult>(response)
                };
            }

            return await DeserializarJsonParaObjeto<UsuarioRespostaLogin>(response);
        }
    }
}
