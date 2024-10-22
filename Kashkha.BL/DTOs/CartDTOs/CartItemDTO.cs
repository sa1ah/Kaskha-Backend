namespace Kashkha.BL.DTOs.CartDTOs
{
    public class CartItemDTO
    {
        //Represents an individual item in the cart, including product details and quantity

           public int Id { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
        public string PicUrl { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice => Price * Quantity;

    }
}