using AutoMapper;
using Business;
using Business.Services;
using Business.Services.Interfaces;
using Data.Data;
using Data.Repositories;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("IncidentsAccountsContractsConnectionDB");
builder.Services.AddDbContext<IncidentsAccountsContactsDBContext>(options =>
    options.UseSqlServer(connectionString!));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IIncidentRepository, IncidentRepository>();

builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IIncidentService, IncidentService>();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutoMapperProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
