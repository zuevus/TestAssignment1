using TestAssignment1;
using TestAssignment1.Data;
using TestAssignment1.Service;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddDbContextFactory<TestAssignmentContext>();
builder.Services.AddHostedService<FiboWorker>();
builder.Services.AddScoped<IFiboService, FiboService>();

var host = builder.Build();
host.Run();
