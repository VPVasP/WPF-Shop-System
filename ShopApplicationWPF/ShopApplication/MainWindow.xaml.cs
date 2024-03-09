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
            InitializeItems();
        }
        private void InitializeValues()
        {
            Currency = 20;
            UpdateCurrencyText();
        }
        private void FindButtons()
        {
            BuyMilkButton = (Button)FindName("BuyMilkButton");
        }
        private void InitializeItems()
        {
            itemsList.Add(new Item("Milk", 3, 0));
            MilkProductName.Text = "Milk";
            MilkPrice.Text = "Price: 3";
            itemsList.Add(new Item("Bread",5, 1));
            BreadProductName.Text ="Bread";
            BreadPrice.Text = "Price: 5";
            itemsList.Add(new Item("Eggs", 7, 2));
            EggProductName.Text = "Egg";
            EggPrice.Text = "Price:7";
        }
        private void BuyMilk(object sender, RoutedEventArgs e)
        {
            BuyItems("Milk");
        }

        private void BuyBread(object sender, RoutedEventArgs e)
        {
            BuyItems("Bread");
        }
        private void BuyEggs(object sender, RoutedEventArgs e)
        {
            BuyItems("Eggs");
        }
        private void UpdateCurrencyText()
        {
            CurrencyText.Text ="Currency: "+ Currency.ToString();
        }
        public void BuyItems(string itemName)
        {
            
                Item item = itemsList.Find(item => item.itemName == itemName);
                if (item != null)
                {
                    if (Currency >= item.price)
                    {
                        Currency -= item.price;
                        Debug.WriteLine("Bought " + item.itemName);
                        UpdateCurrencyText();
                        BoughtItemText.Text ="You Bought "+ item.itemName;
                    }
                }
            
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