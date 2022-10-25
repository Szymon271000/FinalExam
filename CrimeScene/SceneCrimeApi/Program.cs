using SceneCrimeApi.Datas.Docker;
using SceneCrimeApi.Datas.Services;
using SceneCrimeApi.Mongo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddSingleton<IDbClient, DbClient>();
//builder.Services.AddScoped<ICrimeRepository, CrimeRepository>();



builder.Services.AddControllers();
//builder.Services.Configure<CrimeDbConfig>(builder.Configuration);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSwaggerGen();

var config = new ServerConfig();
builder.Configuration.Bind(config);
var todoContext = new CrimeContext(config.MongoDB);
var repo = new CrimeRepository(todoContext);
builder.Services.AddSingleton<ICrimeRepository>(repo);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
