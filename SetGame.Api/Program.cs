using Microsoft.EntityFrameworkCore;
using SetGame.Api.Database.Read.QueryHandlers;
using SetGame.Api.Database.Write.CommandHandlers;
using SetGame.Api.Database.Write.Commands;
using SetGame.Set;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:3000");
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("GameDbConnectionString");
builder.Services.AddDbContext<SetGame.Api.Database.SetGameContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<ICommandHandler<NewGameCommand, Game>, GameCommandHandler>();
builder.Services.AddScoped<ICommandHandler<UpdateGameCommand>, GameCommandHandler>();

builder.Services.AddScoped<IQueryHandler<Guid, Game>, GameQueryHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
