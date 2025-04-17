using Microsoft.EntityFrameworkCore;
using Tarefa1.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

// builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDBContext>();
builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<ApplicationDBContext>();
builder.Services.AddRazorPages(); // Adiciona o Razor Pages para as páginas de login, registo, etc.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // Redireciona para HTTPS
app.UseStaticFiles(); // Habilita arquivos estáticos

app.UseRouting(); // Habilita o roteamento

app.UseAuthentication(); // Habilita a autenticação. ATENÇÃO: Tem que se habilitar este antes da autorização (app.UseAuthorization())

app.UseAuthorization(); // Habilita a autorização
app.MapRazorPages(); // Habilita as páginas Razor

app.MapControllerRoute( // Configura a rota padrão
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run(); // Executa a aplicação
