using Aplicacion.ValoresNormales;
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
    public class ValoresNormalesController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatValoresNormales>>> Get()
        {
            return await Mediator.Send(new Consulta.Ejecuta());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatValoresNormales>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaId.ValoresUnica { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await Mediator.Send(data);
        }
    }
}