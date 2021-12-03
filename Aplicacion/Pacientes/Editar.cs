using Dominio.Model;
using MediatR;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Pacientes
{
    public class Editar
    {
        public class Ejecuta : IRequest
        {
            public Guid Id { get; set; }
            public Guid? IdIdentificacion { get; set; }
            public string NumIdentificacion { get; set; }
            public string NumInss { get; set; }
            public Guid? IdEstadoCivil { get; set; }
            public string Email { get; set; }
            public Guid? IdSexo { get; set; }
            public Guid? IdPaisNac { get; set; }
            public Guid? IdDepartamentoNac { get; set; }
            public Guid? IdPaisRes { get; set; }
            public Guid? IdDepartamentoRes { get; set; }
            public Guid? IdTipoSangre { get; set; }
            public Guid? IdProfesiones { get; set; }
            public string PrimerNombre { get; set; }
            public string SegundoNombre { get; set; }
            public string PrimerApellido { get; set; }
            public string SegundoApellido { get; set; }
            public string DireccionDomiciliar { get; set; }
            public string TelefonoDomiciliar { get; set; }
            public string TelefonoMovil { get; set; }
            public Guid? Religion { get; set; }
            public string Activo { get; set; }
            public string Emabrazada { get; set; }
            public string Fallecido { get; set; }
        }

        //public class EjecutaValidacion : AbstractValidator<Ejecuta>
        //{
        //    public EjecutaValidacion()
        //    {
        //        RuleFor(x => x.Titulo).NotEmpty();
        //        RuleFor(x => x.Descripcion).NotEmpty();
        //        RuleFor(x => x.FechaPublicacion).NotEmpty();
        //    }
        //}

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly netLisContext _context;

            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var dato = await _context.TblPacientes.FindAsync(request.Id);
                if (dato == null)
                {
                    throw new Exception("La TblPacientes no existe");
                }

                dato.IdIdentificacion = request.IdIdentificacion ?? dato.IdIdentificacion;
                dato.NumIdentificacion = request.NumIdentificacion ?? dato.NumIdentificacion;
                dato.NumInss = request.NumInss ?? dato.NumInss;
                dato.IdEstadoCivil = request.IdEstadoCivil ?? dato.IdEstadoCivil;
                dato.Email = request.Email ?? dato.Email;
                dato.IdSexo = request.IdSexo ?? dato.IdSexo;
                dato.IdPaisNac = request.IdPaisNac ?? dato.IdPaisNac;
                dato.IdDepartamentoNac = request.IdDepartamentoNac ?? dato.IdDepartamentoNac;
                dato.IdPaisRes = request.IdPaisRes ?? dato.IdPaisRes;
                dato.IdDepartamentoRes = request.IdDepartamentoRes ?? dato.IdDepartamentoRes;
                dato.IdTipoSangre = request.IdTipoSangre ?? dato.IdTipoSangre;
                dato.IdProfesiones = request.IdProfesiones ?? dato.IdProfesiones;
                dato.PrimerNombre = request.PrimerNombre ?? dato.PrimerNombre;
                dato.SegundoNombre = request.SegundoNombre ?? dato.SegundoNombre;
                dato.PrimerApellido = request.PrimerApellido ?? dato.PrimerApellido;
                dato.SegundoApellido = request.SegundoApellido ?? dato.SegundoApellido;
                dato.DireccionDomiciliar = request.DireccionDomiciliar ?? dato.DireccionDomiciliar;
                dato.TelefonoDomiciliar = request.TelefonoDomiciliar ?? dato.TelefonoDomiciliar;
                dato.TelefonoMovil = request.TelefonoMovil ?? dato.TelefonoMovil;
                dato.Religion = request.Religion ?? dato.Religion;
                dato.Activo = request.Activo ?? dato.Activo;
                dato.Emabrazada = request.Emabrazada ?? dato.Emabrazada;
                dato.Fallecido = request.Fallecido ?? dato.Fallecido;
                dato.Estado = 2;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar la TblPacientes");
            }
        }
    }
}
