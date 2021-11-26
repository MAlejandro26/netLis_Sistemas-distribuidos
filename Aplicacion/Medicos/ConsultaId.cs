using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Medicos
{
    public class ConsultaId
    {
        public class MedicoUnico : IRequest<TblMedico>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<MedicoUnico, TblMedico>
        {

            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblMedico> Handle(MedicoUnico request, CancellationToken cancellationToken)
            {
                var medico = await _context.TblMedicos.FindAsync(request.Id);
                /*if (tipoOrden == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El curso no existe" });
                }*/

                return medico;
            }
        }
    }
}
