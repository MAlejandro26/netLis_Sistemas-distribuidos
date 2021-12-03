
using Aplicacion.Perfiles;
using Dominio.Model;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilesController : MiControllerBase
    {
      [HttpGet]
       public async Task<ActionResult<List<TblCatPerfiles>>> Get()
       {
            return await Mediator.Send(new Consulta.Ejecuta());
       }

       [HttpGet("{id}")]
       public async Task<ActionResult<TblCatPerfiles>> Detalle(Guid id)
       {
           return await Mediator.Send(new ConsultaId.CatPerfilUnico { Id = id });
       }

       [HttpPost("nuevo")]
       public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
       {
           return await Mediator.Send(data);
       }

       [HttpPut("{id}")]
       public async Task<ActionResult<Unit>> Editar(Guid id, Editar.Ejecuta data)
       {
            data.Id = id;
            return await Mediator.Send(data);
       }


        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id, Eliminar.Ejecuta data)
        {
            data.Id = id;
            return await Mediator.Send(data);
        }
    }
}
