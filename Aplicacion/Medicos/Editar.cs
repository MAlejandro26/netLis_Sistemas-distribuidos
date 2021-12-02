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
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public Guid IdMedico { get; set; }
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public Guid IdtblCatSucursales { get; set; }
            public Guid IdDepartamentoNac { get; set; }
            public Guid IdDepartamentoRes { get; set; }
            public Guid IdPaisNac { get; set; }
            public Guid IdPaisRes { get; set; }
            public Guid IdIdentificacion { get; set; }
            public Guid IdEstadoCivil { get; set; }
            public Guid IdSexo { get; set; }
            public string NumIdentificacion { get; set; }
            public string CodMinsa { get; set; }
            public DateTime FechaNac { get; set; }
            public string Email { get; set; }
            public string Telefono { get; set; }
            public string UrlFoto { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly netLisContext _context;

            public Manejador(netLisContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var dato = await _context.TblMedicos.FindAsync(request.IdMedico);
                if (dato == null)
                {
                    throw new Exception("La sucursal no existe");
                }

                dato.Nombres = request.Nombres ?? dato.Nombres;
                dato.Apellidos = request.Apellidos ?? dato.Apellidos;
                dato.IdtblCatSucursales = request.IdtblCatSucursales;
                dato.FechaModificacion = DateTime.Today;
                dato.IdDepartamentoNac = request.IdDepartamentoNac;
                dato.IdDepartamentoRes = request.IdDepartamentoRes;
                dato.IdPaisNac = request.IdPaisNac;
                dato.IdPaisRes = request.IdPaisRes;
                dato.IdIdentificacion = request.IdIdentificacion;
                dato.IdEstadoCivil = request.IdEstadoCivil;
                dato.IdSexo = request.IdSexo;
                dato.NumIdentificacion = request.NumIdentificacion ?? dato.NumIdentificacion;
                dato.CodMinsa = request.CodMinsa ?? dato.CodMinsa;
                dato.FechaNac = request.FechaNac;
                dato.Email = request.Email ?? dato.Email;
                dato.Telefono = request.Telefono ?? dato.Telefono;
                dato.UrlFoto = request.UrlFoto ?? dato.UrlFoto;
                dato.Estado = 2;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar sucursal");

            }
        }
    }
}
