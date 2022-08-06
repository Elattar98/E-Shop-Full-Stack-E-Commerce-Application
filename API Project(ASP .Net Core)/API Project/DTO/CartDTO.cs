namespace API_Project.DTO
{
    public class CartDTO
    {
        public int ItemId { get; set; }
        public int ItemQuantity { get; set; }
        public float ItemTotalCost { get; set; }
        public int ProductId { get; set; }
        public ProductDTO Product { get; set; }
    }
    public class ProductDTO
    {
        public int productId { get; set; }
        public string productTitle { get; set; }
        public float productPrice { get; set; }
    }
}
