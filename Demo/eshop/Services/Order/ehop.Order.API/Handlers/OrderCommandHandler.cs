using ehop.Order.API.Commands;

namespace ehop.Order.API.Handlers
{
    public class OrderCommandHandler : ICommandHandler<CreateOrderCommand>,
                                       ICommandHandler<UpdateOrderStatusToFailedCommand>,
                                       ICommandHandler<OrderCanceledCommand>
    {
        public void Handle(CreateOrderCommand command)
        {

            //db'ye yazılıyor.
        }

        public void Handle(UpdateOrderStatusToFailedCommand command)
        {
            //db'de status failed olarak güncellenecek
        }

        public void Handle(OrderCanceledCommand command)
        {
            //müşterinin siparişini bul ve iptal et.
        }
    }

    public class UpdateOrderStatusToFailedCommandHandler : ICommandHandler<UpdateOrderStatusToFailedCommand>
    {
        public void Handle(UpdateOrderStatusToFailedCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
