using Aplicacion.Profesiones;
using Dominio;
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
    public class ProfesionesController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatProfesiones>>> Get()
        {
            return await Mediator.Send(new Consulta.Ejecuta());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatProfesiones>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaId.ProfesionUnica { Id = id });
        }

    }
}
