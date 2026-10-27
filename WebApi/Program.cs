using Dominio.InterfacesRepositorio;
using LogicaAccesoDatos.RepositoriosEF.Repositorios;
using LogicaAplicacion.CasosDeUso.Categorias;
using LogicaAplicacion.CasosDeUso.Historias;
using LogicaAplicacion.CasosDeUso.Usuarios;
using LogicaAplicacion.InterfacesCasosDeUso.Categorias;
using LogicaAplicacion.InterfacesCasosDeUso.Historias;
using LogicaAplicacion.InterfacesCasosDeUso.Usuario;
using LogicaAplicacion.InterfacesCasosDeUso.Usuarios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

// inicializaciones repositorios
builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuariosEF>();
builder.Services.AddScoped<IRepositorioHistorias, RepositorioHistoriasEF>();
builder.Services.AddScoped<IRepositorioCategorias, RepositorioCategoriasEF>();

// inicializaciones CU usuarios
builder.Services.AddScoped<IObtenerUsuarioPorId, ObtenerUsuarioPorIdCU>();
builder.Services.AddScoped<IListarUsuarios, ListarUsuariosCU>();
builder.Services.AddScoped<IAltaUsuario, AltaUsuarioCU>();
builder.Services.AddScoped<ILoginAdmins, LoginAdminsCU>();
// inicializaciones CU historias
builder.Services.AddScoped<IAltaHistoria, AltaHistoriaCU>();
// inicializaciones CU categorias
builder.Services.AddScoped<IListarCategorias, ListarCategoriasCU>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
