using Dominio.InterfacesRepositorio;
using LogicaAccesoDatos.RepositoriosEF;
using LogicaAccesoDatos.RepositoriosEF.Repositorios;
using LogicaAccesoDatos.RepositoriosMemoria;
using LogicaAplicacion.CasosDeUso.Capitulos;
using LogicaAplicacion.CasosDeUso.Categorias;
using LogicaAplicacion.CasosDeUso.Historias;
using LogicaAplicacion.CasosDeUso.Usuarios;
using LogicaAplicacion.InterfacesCasosDeUso.Capitulos;
using LogicaAplicacion.InterfacesCasosDeUso.Categorias;
using LogicaAplicacion.InterfacesCasosDeUso.Historias;
using LogicaAplicacion.InterfacesCasosDeUso.Usuario;
using LogicaAplicacion.InterfacesCasosDeUso.Usuarios;

namespace WebAPP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // SERVICIO DE SESSION
            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;                 
                options.Cookie.IsEssential = true;              
            });



            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // singleton ed Context
            builder.Services.AddDbContext<HistoriasContext>();
            // inicializaciones repositorios
            builder.Services.AddScoped<IRepositorioUsuarios, RepositorioUsuariosEF>();
            builder.Services.AddScoped<IRepositorioHistorias, RepositorioHistoriasEF>();
            builder.Services.AddScoped<IRepositorioCategorias, RepositorioCategoriasEF>();
            builder.Services.AddScoped<IRepositorioCapitulos, RepositorioCapitulosEF>();

            // inicializaciones CU usuarios
            builder.Services.AddScoped<IObtenerUsuarioPorId, ObtenerUsuarioPorIdCU>();
            builder.Services.AddScoped<IListarUsuarios, ListarUsuariosCU>();
            builder.Services.AddScoped<IAltaUsuario, AltaUsuarioCU>();
            builder.Services.AddScoped<ILoginAdmins, LoginAdminsCU>();
            // inicializaciones CU historias
            builder.Services.AddScoped<IAltaHistoria, AltaHistoriaCU>();
            builder.Services.AddScoped<IListarHistorias, ListarHistoriasCU>();
            builder.Services.AddScoped<IObtenerHistoriaPorId, ObtenerHistoriaPorIdCU>();
            builder.Services.AddScoped<IEditarHistoria, EditarHistoriaCU>();
            // inicializaciones CU categorias
            builder.Services.AddScoped<IListarCategorias, ListarCategoriasCU>();
            // inicializaciones CU capitulos
            builder.Services.AddScoped<IAltaCapitulo, AltaCapituloCU>();
            builder.Services.AddScoped<IListarAntecedentesById, ListarAntecedentesByIdCU>();




            var app = builder.Build();

            

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Usuario}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
