using Dominio;
using Dominio.Model;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Aplicacion.Medicos
{
    public class Nuevo
    {
        public class Ejecuta : IRequest
        {
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public Guid IdtblCatSucursales { get; set; }
            public DateTime FechaCreacion { get; set; }
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
            public int Estado { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Nombres).NotEmpty();
                RuleFor(x => x.Apellidos).NotEmpty();
                RuleFor(x => x.IdtblCatSucursales).NotEmpty();
                RuleFor(x => x.IdDepartamentoNac).NotEmpty();
                RuleFor(x => x.IdDepartamentoRes).NotEmpty();
                RuleFor(x => x.IdPaisNac).NotEmpty();
                RuleFor(x => x.IdPaisRes).NotEmpty();
                RuleFor(x => x.IdIdentificacion).NotEmpty();
                RuleFor(x => x.IdEstadoCivil).NotEmpty();
                RuleFor(x => x.IdSexo).NotEmpty();
                RuleFor(x => x.FechaNac).NotEmpty();
            }
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
                var medico = new TblMedico
                {
                    IdTblMedico = Guid.NewGuid(),
                    Nombres = request.Nombres, 
                    Apellidos = request.Apellidos,
                    IdtblCatSucursales = request.IdtblCatSucursales,
                    FechaCreacion = DateTime.Today,
                    IdDepartamentoNac = request.IdDepartamentoNac,
                    IdDepartamentoRes = request.IdDepartamentoRes,
                    IdPaisNac = request.IdPaisNac,
                    IdPaisRes = request.IdPaisRes,
                    IdIdentificacion = request.IdIdentificacion,
                    IdEstadoCivil = request.IdEstadoCivil,
                    IdSexo = request.IdSexo,
                    NumIdentificacion = request.NumIdentificacion,
                    CodMinsa = request.CodMinsa,
                    FechaNac = request.FechaNac,
                    Email = request.Email,
                    Telefono = request.Telefono,
                    UrlFoto = request.UrlFoto,
                    Estado = 1,
                };

                _context.TblMedicos.Add(medico);
                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo guardar el medico");
            }
        }
    }
}
