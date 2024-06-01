using TestAssignment1;
using TestAssignment1.Service;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton<FiboService>();
builder.Services.AddHostedService<Worker>();


var host = builder.Build();
host.Run();
