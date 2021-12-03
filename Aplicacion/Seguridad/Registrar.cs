using Dominio;
using MediatR;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Aplicacion.Contratos;
using Microsoft.EntityFrameworkCore;
using Aplicacion.ManejadorError;
using System.Net;
using FluentValidation;
using Dominio.Model;

namespace Aplicacion.Seguridad
{
    public class Registrar
    {
        public class Ejecuta : IRequest<UsuarioData>
        {
            public Guid Id_empleado { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Username { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, UsuarioData>
        {
            private readonly netLisContext _context;
            private readonly UserManager<TblUsuario> _userManager;
            private readonly IJwtGenerador _jwtgenerador;

            public Manejador(netLisContext context, UserManager<TblUsuario> userManager, IJwtGenerador jwtGenerador)
            {
                _context = context;
                _userManager = userManager;
                _jwtgenerador = jwtGenerador;
            }

            public class EjecutaValidador : AbstractValidator<Ejecuta>
            {
                public EjecutaValidador()
                {
                    RuleFor(x => x.Email).NotEmpty();
                    RuleFor(x => x.Password).NotEmpty();
                    RuleFor(x => x.Username).NotEmpty();
                }
            }
            public async Task<UsuarioData> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var existe = await _context.Users.Where(x => x.Email == request.Email).AnyAsync();
                if (existe)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "El email ingresado ya existe" });
                }

                var existeUserName = await _context.Users.Where(x => x.UserName == request.Username).AnyAsync();

                if (existeUserName)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "Existe un usuario con este username" });
                }

                var usuario = new TblUsuario
                {
                    IdEmpleado = request.Id_empleado,
                    Email = request.Email,
                    UserName = request.Username
                };

                var resultado = await _userManager.CreateAsync(usuario, request.Password);

                if (resultado.Succeeded)
                {
                    return new UsuarioData
                    {
                        IdEmpleado = usuario.IdEmpleado,
                        Token = _jwtgenerador.CrearToken(usuario),
                        Email = usuario.Email,
                        UserName = usuario.UserName
                    };
                }
                throw new ManejadorExcepcion(HttpStatusCode.InternalServerError, "No se pudo agregar el nuevo usuario");
            }
        }
    }
}
