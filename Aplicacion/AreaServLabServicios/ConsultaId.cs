using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.AreaServLabServicios

{
    public class ConsultaId
    {

        public class LabServicioUnico : IRequest<TblCatAreasLabServicio>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<LabServicioUnico, TblCatAreasLabServicio>
        {

            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatAreasLabServicio> Handle(LabServicioUnico request, CancellationToken cancellationToken)
            {
                var dato = await _context.TblCatAreasLabServicios.FindAsync(request.Id);
                /*if (tipoOrden == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El curso no existe" });
                }*/

                return dato;
            }
        }

    }
}
