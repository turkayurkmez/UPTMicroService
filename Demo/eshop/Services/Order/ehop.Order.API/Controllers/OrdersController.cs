using ehop.Order.API.Commands;
using ehop.Order.API.Models;
using ehop.Order.API.Queries;
using eshop.MessageBus;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ehop.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMediator _mediator;

        public OrdersController(IPublishEndpoint publishEndpoint, IMediator mediator)
        {
            _publishEndpoint = publishEndpoint;
            _mediator = mediator;
        }

        [HttpPost]
        public IActionResult CreateOrder(CreateOrderRequest createOrderRequest)
        {
            Order.API.Models.Order order = new Models.Order
            {
                CustomerId = createOrderRequest.CustomerId,
                OrderDate = DateTime.Now,
                OrderItems = createOrderRequest.OrderItems,
                OrderState = OrderState.Pending
            };
            order.Id = 12;

            //CreateOrderCommand createOrderCommand = new CreateOrderCommand
            //{
            //    CustomerId = createOrderRequest.CustomerId,
            //    OrderItems = createOrderRequest.OrderItems
            //};

            //OrderCommandHandler orderCommandHandler = new OrderCommandHandler();
            //orderCommandHandler.Handle(createOrderCommand);

            CreateOrderWithMediatr createOrderWithMediatr = new CreateOrderWithMediatr
            {
                CustomerId = createOrderRequest.CustomerId,
                OrderItems = createOrderRequest.OrderItems
            };

            _mediator.Send(createOrderWithMediatr);

            //order db'ye "PENDING" olarak kaydedildi.

            var @event = new OrderCreatedEvent
            {
                CustomerId = createOrderRequest.CustomerId,
                OrderId = order.Id,
                CreditCardInfo = "fake cart  number",
                OrderItems = order.OrderItems.Select(o => new OrderItemMessage
                {
                    Amount = o.Amount,
                    Price = o.UnitPrice,
                    ProductId = o.ProductId
                }).ToList()

            };

            _publishEndpoint.Publish(@event);
            return Ok();
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetOrders(int customerId)
        {
            var getOrderQuery = new GetOrdersByUserIdWithMediatr
            {
                UserId = customerId
            };

            var orders = await _mediator.Send(getOrderQuery);
            return Ok(orders);
        }
    }
}

/*
 * 1. Sipariş Ekleme eventi fırlar. (OrderCreated)
2. Stocks API’si OrderCreated eventini consume eder.
3. Eğer yeterli stok varsa StockReserved event’i fırlar.
4. Eğer yeterli stok yoksa StockNotReserved event’i fırlar

 5.  Payment API’si StockReserved event’ini consume eder.

 6.  Eğer ödeme alabiliyorsa PaymentCompleted event’i fırlar.

1. Eğer ödeme alamıyorsa PaymentFailed event’i fırlar
2. Orders API PaymentCompleted eventini dinler ve işlem kapanır
3. Order API’si StockNotReserved eventini consume eder ve fırlarsa OrderFailed olarak db’de günceller.
4. Stocks API’si PaymentFailed eventini consume eder ve fırlarsa  stock’ları değiştirir.
5. Order API’si PaymentFailed eventini consume eder ve fırlarsa OrderFailed olarak db’de güncellenir.
 */