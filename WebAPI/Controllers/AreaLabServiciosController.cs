using Aplicacion.AreaServLabServicios;
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
    public class AreaLabServiciosController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatAreasLabServicio>>> Get()
        {
            return await Mediator.Send(new Consulta.Ejecuta());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatAreasLabServicio>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaId.LabServicioUnico { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await Mediator.Send(data);
        }

    }
}
