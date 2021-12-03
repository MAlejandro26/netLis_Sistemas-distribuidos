using Aplicacion.Seguridad;
using Dominio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;


namespace WebAPI.Controllers
{
    [AllowAnonymous]
    public class UsuarioController : MiControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult<UsuarioData>> Login(Login.Ejecuta data)
        {
            return await Mediator.Send(data);
        }

        //[HttpPost("registrar")]
        //public async Task<ActionResult<UsuarioData>> Registrar(Registrar.Ejecuta paametros)
        //{
        //    return await Mediator.Send(paametros);
        //}

        //// http://localhost:5000/api/Usuario
        //[HttpGet]
        //public async Task<ActionResult<UsuarioData>> DevolverUsuario()
        //{
        //    return await Mediator.Send(new UsuarioActual.Ejecutar());
        //}
    }
}