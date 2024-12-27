namespace E_Commerce.API.Model.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string product_name { get; set; }
        public string product_description { get; set; }
        public string product_type { get; set; }
        public string product_image_url { get; set; }
        public long price { get; set; }
        public string brand { get; set; }
        public int quantity { get; set; }
    }
}
