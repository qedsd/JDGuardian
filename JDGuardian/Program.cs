var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(p=>
{
    // Ϊ Swagger JSON and UI����xml�ĵ�ע��·��
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

var mailSetting = builder.Configuration.GetSection("MailSetting").Get<JDGuardian.Models.MailSetting>();
if(mailSetting != null)
{
    if(mailSetting.IsVaild())
    {
        JDGuardian.Services.MailService.MailSetting = mailSetting;
    }
    else
    {
        Console.WriteLine("����δ������ɣ�����appsettings.json�ļ�");
    }
}
else
{
    Console.WriteLine("δ�������䣬����appsettings.json�ļ�");
    return;
}

var app = builder.Build();

app.Urls.Add("http://localhost:5002");
app.Urls.Add("https://localhost:5003");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("AllowCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
