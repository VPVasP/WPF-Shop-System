using System.Diagnostics;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
namespace ShopApplication
{

    public partial class MainWindow : Window
    {
        private int Currency;
        private bool isItemBought;
        private List<Item> itemsList;
        public MainWindow()
        {
            InitializeComponent();
            itemsList = new List<Item>();
            FindButtons();
            InitializeValues();
        }
        private void InitializeValues()
        {
            Currency = 20;
        }
        private void FindButtons()
        {
            BuyMilkButton = (Button)FindName("BuyMilkButton");
        }

        private void BuyMilk(object sender, RoutedEventArgs e)
        {
            Item item = new Item
            {
                itemName = "Milk",
                price = 5,
                Id = 0
            };
            Debug.WriteLine(Currency);
            if (Currency >= item.price)
            {
                itemsList.Add(item);
                Currency -= item.price;
                Debug.WriteLine("Bought " + item.itemName);
            }
            else
            {
                Debug.WriteLine("We don't have Enough Money");
            }
   
        }
        public void BuyItems(Item item, object sender, RoutedEventArgs e)
        {
            itemsList.Add(item);
            Currency -= item.price;
        }
        public void SellItems(Item item, object sender, RoutedEventArgs e)
        {
            if (isItemBought)
            {
                itemsList.Remove(item);
                Currency += item.price;
            }
        }
    }
}