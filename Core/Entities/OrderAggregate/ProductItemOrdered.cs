namespace Core.Entities.OrderAggregate
{
    public class ProductItemOrdered
    {
        public ProductItemOrdered()
        {
        }
        public ProductItemOrdered(int productItem, string productName, string pictureUrl) 
        {
            ProductItem = productItem;
            ProductName = productName;
            PictureUrl = pictureUrl;
        }
        public int ProductItem {get; set;}
        public string ProductName {get; set;}
        public string PictureUrl {get; set;}
    }
}