using eshop.MessageBus;
using eshop.Stock.API.Consumers;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(configure =>
{
    configure.AddConsumer<OrderCreatedConsumer>();
    configure.AddConsumer<PaymentFailedConsumer>();
    configure.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        configurator.ReceiveEndpoint(nameof(PaymentFailedEvent), e => e.ConfigureConsumer<PaymentFailedConsumer>(context));

        configurator.ConfigureEndpoints(context);

        //OrderCreatedConsumer --> endpoint
    });
});

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
