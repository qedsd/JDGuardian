var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(p=>
{
    // 为 Swagger JSON and UI设置xml文档注释路径
    var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
    var xmlPath = Path.Combine(basePath, "JDGuardian.xml");
    p.IncludeXmlComments(xmlPath);
});
builder.Services.AddCors(options =>
{
    options.AddPolicy
        (name: "AllowCors",
            builde =>
            {
                builde.WithOrigins("*", "*", "*")
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            }
        );
});

var app = builder.Build();

app.Urls.Add("http://localhost:5002");
app.Urls.Add("https://localhost:5003");

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{

//}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("AllowCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
