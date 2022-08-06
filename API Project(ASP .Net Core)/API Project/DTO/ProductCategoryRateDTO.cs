namespace API_Project.DTO
{
    public class ProductCategoryRateDTO
    {
        public int productId { get; set; }
        public string productTitle { get; set; }
        public float productPrice { get; set; }
        public string productDescription { get; set; }
        public int productCategoryId { get; set; }
        public string productCategory { get; set; }
        public string productImage { get; set; }
        public RateDTO productRating { get; set; }
    }
    public class CategoryProductsDTO
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public List<ProductCategoryRateDTO> products { get; set; } = new List<ProductCategoryRateDTO>();
    }
    public class RateDTO
    {
        public float rate { get; set; }
        public int count { get; set; }
    }
    public class PostProductDTO
    {
        public string productTitle { get; set; }
        public float productPrice { get; set; }
        public string productDescription { get; set; }
        public int productCategoryId { get; set; }
        public string productImage { get; set; }

    }
}
