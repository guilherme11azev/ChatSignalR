using ChatSignalR.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Registra o SignalR
builder.Services.AddSignalR();

// Permite servir arquivos estáticos (nosso HTML)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials()
              .SetIsOriginAllowed(_ => true);
    });
});

var app = builder.Build();

app.UseStaticFiles();
app.UseCors();

// Mapeia o Hub para a rota /chatHub
app.MapHub<ChatHub>("/chatHub");

// Rota raiz serve o index.html
app.MapGet("/", () => Results.Redirect("/index.html"));

app.Run();