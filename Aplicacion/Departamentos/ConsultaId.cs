using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Departamentos
{
    public class ConsultaId
    {

        public class DPTUnico : IRequest<TblCatDepartamento>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<DPTUnico, TblCatDepartamento>
        {

            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatDepartamento> Handle(DPTUnico request, CancellationToken cancellationToken)
            {
                var departamento = await _context.TblCatDepartamentos.FindAsync(request.Id);
                /*if (tipoOrden == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El curso no existe" });
                }*/

                return departamento;
            }
        }

    }
}
