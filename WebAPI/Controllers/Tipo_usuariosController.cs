using Aplicacion.TipoUsuarios;
using Dominio.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tipo_usuariosController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatTipoUsuario>>> Get()
        {
            return await Mediator.Send(new Consulta.Ejecuta());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatTipoUsuario>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaId.TipoUsuarioUnico { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await Mediator.Send(data);
        }

    }
}
