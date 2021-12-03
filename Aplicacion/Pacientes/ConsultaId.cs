using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Pacientes
{
    public class ConsultaId
    {

        public class PacienteUnica : IRequest<TblPaciente>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<PacienteUnica, TblPaciente>
        {

            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblPaciente> Handle(PacienteUnica request, CancellationToken cancellationToken)
            {
                var dato = await _context.TblPacientes.FindAsync(request.Id);
                /*if (tipoOrden == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El curso no existe" });
                }*/

                return dato;
            }
        }

    }
}