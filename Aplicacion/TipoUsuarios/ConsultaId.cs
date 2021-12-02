using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.TipoUsuarios
{
    public class ConsultaId
    {

        public class TipoUsuarioUnico : IRequest<TblCatTipoUsuario>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<TipoUsuarioUnico, TblCatTipoUsuario>
        {

            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatTipoUsuario> Handle(TipoUsuarioUnico request, CancellationToken cancellationToken)
            {
                var dato = await _context.TblCatTipoUsuarios.FindAsync(request.Id);
                /*if (tipoOrden == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El curso no existe" });
                }*/

                return dato;
            }
        }

    }
}
