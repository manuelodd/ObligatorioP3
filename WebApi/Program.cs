using Dominio.InterfacesRepositorio;
using LogicaAccesoDatos.RepositoriosEF;
using LogicaAccesoDatos.RepositoriosEF.Repositorios;
using LogicaAplicacion.CasosDeUso.Auditorias;
using LogicaAplicacion.CasosDeUso.Capitulos;
using LogicaAplicacion.CasosDeUso.Categorias;
using LogicaAplicacion.CasosDeUso.Historias;
using LogicaAplicacion.CasosDeUso.Lecturas;
using LogicaAplicacion.CasosDeUso.Usuarios;
using LogicaAplicacion.InterfacesCasosDeUso.Auditorias;
using LogicaAplicacion.InterfacesCasosDeUso.Capitulos;
using LogicaAplicacion.InterfacesCasosDeUso.Categorias;
using LogicaAplicacion.InterfacesCasosDeUso.Historias;
using LogicaAplicacion.InterfacesCasosDeUso.Lecturas;
using LogicaAplicacion.InterfacesCasosDeUso.Usuario;
using LogicaAplicacion.InterfacesCasosDeUso.Usuarios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<HistoriasContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("Historias"))
    );

builder.Services.AddDbContext<HistoriasContext>();
// inicializaciones repositorios
builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuariosEF>();
builder.Services.AddScoped<IRepositorioHistorias, RepositorioHistoriasEF>();
builder.Services.AddScoped<IRepositorioCategorias, RepositorioCategoriasEF>();
builder.Services.AddScoped<IRepositorioCapitulos, RepositorioCapitulosEF>();
builder.Services.AddScoped<IRepositorioAuditorias, RepositorioAuditoriasEF>();
builder.Services.AddScoped<IRepositorioOpciones, RepositorioOpcionesEF>();
builder.Services.AddScoped<IRepositorioLecturas, RepositorioLecturasEF>();
// inicializaciones CU usuarios
builder.Services.AddScoped<IObtenerUsuarioPorId, ObtenerUsuarioPorIdCU>();
builder.Services.AddScoped<IListarUsuarios, ListarUsuariosCU>();
builder.Services.AddScoped<IAltaUsuario, AltaUsuarioCU>();
builder.Services.AddScoped<ILoginAdmins, LoginAdminsCU>();
builder.Services.AddScoped<IListarLectores, ListarLectoresCU>();
builder.Services.AddScoped<IObtenerUsuarioHistoriasRankings, ObtenerUsuarioHistoriasRankingsCU>();
// inicializaciones CU historias
builder.Services.AddScoped<IAltaHistoria, AltaHistoriaCU>();
builder.Services.AddScoped<IListarHistorias, ListarHistoriasCU>();
builder.Services.AddScoped<IObtenerHistoriaPorId, ObtenerHistoriaPorIdCU>();
builder.Services.AddScoped<IEditarHistoria, EditarHistoriaCU>();
builder.Services.AddScoped<IPublicarHistoria, PublicarHistoriaCU>();
builder.Services.AddScoped<IObtenerFinalesAlcanzadosHistoria, ObtenerFinalesAlcanzadosHistoriaCU>();
builder.Services.AddScoped<IListarAntecedentesById, ListarAntecedentesByIdCU>();
builder.Services.AddScoped<IListarHistoriasPublicadas, ListarHistoriasPublicadasCU>();
builder.Services.AddScoped<IObtenerHistorialLecturasUsu, ObtenerHistorialLecturasUsuCU>();
builder.Services.AddScoped<IObtenerRankingsHistorias, ObtenerRankingsHistoriasCU>();
// inicializaciones CU categorias
builder.Services.AddScoped<IListarCategorias, ListarCategoriasCU>();
// inicializaciones CU capitulos
builder.Services.AddScoped<IAltaCapitulo, AltaCapituloCU>();
builder.Services.AddScoped<IEditarCapitulo, EditarCapituloCU>();
// inicializaciones CU auditorias
builder.Services.AddScoped<IRegistrarAuditoria, RegistrarAuditoriaCU>();
// inicializaciones CU lecturas
builder.Services.AddScoped<IEmpezarLectura, EmpezarLecturaCU>();
builder.Services.AddScoped<IObtenerCapituloLectura, ObtenerCapituloLecturaCU>();
builder.Services.AddScoped<ISeguirLectura, SeguirLecturaCU>();

// JWT Authentication
var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? string.Empty);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
