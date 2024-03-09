
namespace ShopApplication
{
   public class Item(string name, int itemPrice, int id)
    {
        public int Id { get; set; } = id;
        public string itemName { get; set; } = name;

        public int price { get; set; } = itemPrice;

        public  string productNameText { get; set; }

        public  string productPriceText { get; set; }
    }

}
