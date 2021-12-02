using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Aplicacion.TipoMuestras
{
    public class ConsultaId
    {
        public class CatTipoMuestraUnico : IRequest<TblCatTipoMuestra>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<CatTipoMuestraUnico, TblCatTipoMuestra>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<TblCatTipoMuestra> Handle(CatTipoMuestraUnico request, CancellationToken cancellationToken)
            {
                var catTipoMuestra = await _context.TblCatTipoMuestras.FindAsync(request.Id);
                return catTipoMuestra;
            }
        }
    }
}
