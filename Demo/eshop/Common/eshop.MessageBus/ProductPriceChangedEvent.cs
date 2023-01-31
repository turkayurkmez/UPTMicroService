namespace eshop.MessageBus
{
    public class ProductPriceChangedEvent
    {
        public ProductPriceChangeCommand ProductPriceChangeCommand { get; set; }
    }
    //[Serializable] -> Command'ler serileştirilebilir olmalı
    public class ProductPriceChangeCommand
    {
        public int ProductId { get; set; }
        public decimal? OldPrice { get; set; }
        public decimal? NewPrice { get; set; }
    }
}


