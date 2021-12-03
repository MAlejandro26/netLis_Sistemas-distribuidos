using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Hospitals
{
    public class ConsultaId
    {

        public class HospitalUnico : IRequest<TblCatHospital>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<HospitalUnico, TblCatHospital>
        {

            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatHospital> Handle(HospitalUnico request, CancellationToken cancellationToken)
            {
                var hospital = await _context.TblCatHospitals.FindAsync(request.Id);
                /*if (tipoOrden == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El curso no existe" });
                }*/

                return hospital;
            }
        }

    }
}
