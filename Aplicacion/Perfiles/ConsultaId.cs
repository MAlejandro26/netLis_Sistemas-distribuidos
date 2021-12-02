using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Perfiles
{
    public class ConsultaId
    {
        public class CatPerfilUnico : IRequest<TblCatPerfiles>
        {
            public Guid Id { get; set; }
        }

        public class Manejador: IRequestHandler<CatPerfilUnico, TblCatPerfiles>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatPerfiles> Handle(CatPerfilUnico request, CancellationToken cancellationToken)
            {
                var catperfil = await _context.TblCatPerfiles.FindAsync(request.Id);
                return catperfil;
            }
        }
    }
}
