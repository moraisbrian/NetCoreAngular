using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NetCoreAngular.Api.Config;
using NetCoreAngular.Api.ViewModels;
using NetCoreAngular.Application.DTOs;
using NetCoreAngular.Application.Interfaces.Services;

namespace NetCoreAngular.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly AuthSettings _authSettings;
        public AuthController(IOptions<AuthSettings> authSettings, IUsuarioService usuarioService)
        {
            _authSettings = authSettings.Value;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel login)
        {
            try
            {
                var hash = Criptografia.GerarHash(login.Senha);
                var usuario = await _usuarioService.Autenticar(login.Usuario, hash);
                if (usuario != null)
                    return Ok(GerarJwt(usuario));
                else 
                    return BadRequest("Usuário ou senha inválidos");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult CriptografarSenha([FromBody] LoginViewModel login)
        {
            try
            {
                return Ok(Criptografia.GerarHash(login.Senha));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private string GerarJwt(UsuarioDTO usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_authSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _authSettings.Issuer,
                Audience = _authSettings.Audience,
                Expires = DateTime.UtcNow.AddMinutes(_authSettings.ExpiresMinute),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var response = new Dictionary<string, object>();
            response.Add("token", tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor)));
            response.Add("usuario", usuario.Nome);
            response.Add("usuarioId", usuario.Id);
            response.Add("usuarioEmail", usuario.Email);
            response.Add("usuarioDepartamento", usuario.DepartamentoId);
            response.Add("expiracaoToken", DateTime.UtcNow.AddMinutes(_authSettings.ExpiresMinute));
            var json = JsonConvert.SerializeObject(response);
            return json;
        }
    }
}