using System.Windows;
namespace ShopApplication
{

    public partial class MainWindow : Window
    {
        private int Currency;
        private int ItemID;
        private int itemPrice;
        private bool isItemBought;
        private List<Item> itemsList;
        public MainWindow()
        {
            InitializeComponent();
            itemsList = new List<Item>();
        }
        public void BuyItems(Item item)
        {
            itemsList.Add(item);
            Currency -= item.price;
        }
        public void SellItems(Item item)
        {
            if (isItemBought)
            {
                itemsList.Remove(item);
                Currency += item.price;
            }
        }
    }
}