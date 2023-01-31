using ehop.Order.API.Consumers;
using eshop.MessageBus;
using MassTransit;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(Program));

builder.Services.AddMassTransit(configure =>
{
    configure.AddConsumer<ProductPriceChangedConsumer>();
    configure.AddConsumer<StockConsumer>();
    configure.AddConsumer<PaymentEventsConsumer>();
    configure.UsingRabbitMq((context, configurator) =>
    {
        configurator.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        configurator.ReceiveEndpoint(nameof(ProductPriceChangedEvent), e => e.ConfigureConsumer<ProductPriceChangedConsumer>(context));

        configurator.ConfigureEndpoints(context);
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
