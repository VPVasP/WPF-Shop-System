using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
namespace ShopApplication
{

    public partial class MainWindow : Window
    {
        private int Currency;
        private bool isItemBought;
        private List<Item> itemsList;
        private List<Item> boughtItemsList;
        public MainWindow()
        {
            InitializeComponent();
            itemsList = new List<Item>();
            boughtItemsList = new List<Item>();

            HideButtons();
            InitializeValues();
            InitializeItems();
        }

        //Hide the Sell Buttons and the Inventory Quantity Texts
        private void HideButtons()
        {
            SellMilkButton.Visibility = Visibility.Collapsed;
            MilkInventoryQuantity.Visibility = Visibility.Collapsed;
            SellBreadButton.Visibility = Visibility.Collapsed;
            BreadInventoryQuantity.Visibility = Visibility.Collapsed;
            SellEggsButton.Visibility = Visibility.Collapsed;
            EggsInventoryQuantity.Visibility = Visibility.Collapsed;
            SellCheeseButton.Visibility = Visibility.Collapsed;
            CheeseInventoryQuantity.Visibility = Visibility.Collapsed;
            SellTomatoButton.Visibility = Visibility.Collapsed;
            TomatoInventoryQuantity.Visibility = Visibility.Collapsed;
            SellAppleButton.Visibility = Visibility.Collapsed;
            AppleInventoryQuantity.Visibility = Visibility.Collapsed;
        }
        //Initialize The items Values and the UI
        private void InitializeItems()
        {
            itemsList.Add(new Item("Milk", 3, 0, 0));
            MilkProductName.Text = "Milk";
            MilkPrice.Text = "Price: 3$";
            itemsList.Add(new Item("Bread", 5, 1, 0));
            BreadProductName.Text = "Bread";
            BreadPrice.Text = "Price: 5$";
            itemsList.Add(new Item("Eggs", 7, 2, 0));
            EggProductName.Text = "Egg";
            EggPrice.Text = "Price: 7$";
            itemsList.Add(new Item("Cheese", 10, 3, 0));
            CheeseProductName.Text = "Cheese";
            CheesePrice.Text = "Price: 10$";
            itemsList.Add(new Item("Tomato", 15, 4, 0));
            TomatoProductName.Text = "Tomato";
            TomatoPrice.Text = "Price: 15$";
            itemsList.Add(new Item("Tomato", 15, 5, 0));
            TomatoProductName.Text = "Tomato";
            TomatoPrice.Text = "Price: 15$";
            itemsList.Add(new Item("Apple", 20, 6, 0));
            AppleProductName.Text = "Apple";
            ApplePrice.Text = "Price: 20$";


        }
        //Initialize the values of other UI Elements
        private void InitializeValues()
        {
            Currency = 200;
            UpdateCurrencyText();
            BoughtItemText.Text = "";
        }

        #region BuySpecificItems
        //Buy Milk Button
        private void BuyMilk(object sender, RoutedEventArgs e)
        {
               BuyItems("Milk");
               UpdateQuanityUI("Milk", MilkInventoryQuantity,SellMilkButton);
        }

        //Buy Bread Button
        private void BuyBread(object sender, RoutedEventArgs e)
        {
            BuyItems("Bread");
            UpdateQuanityUI("Bread", BreadInventoryQuantity, SellBreadButton);
        }

        //Buy Eggs Button
        private void BuyEggs(object sender, RoutedEventArgs e)
        {
            BuyItems("Eggs");
            UpdateQuanityUI("Eggs", EggsInventoryQuantity, SellEggsButton);
        }
        //Buy Cheese Button
        private void BuyCheese(object sender, RoutedEventArgs e)
        {
            BuyItems("Cheese");
            UpdateQuanityUI("Cheese", CheeseInventoryQuantity, SellCheeseButton);
        }
        //Buy Tomato Button
        private void BuyTomato(object sender, RoutedEventArgs e)
        {
            BuyItems("Tomato");
            UpdateQuanityUI("Tomato", TomatoInventoryQuantity, SellTomatoButton);
        }
        //Buy Apple Button
        private void BuyApple(object sender, RoutedEventArgs e)
        {
            BuyItems("Apple");
            UpdateQuanityUI("Apple", AppleInventoryQuantity, SellAppleButton);
        }
        #endregion BuySpecificItems

        #region SellSpecificItems

        //Sell Milk Button
        private void SellMilk(object sender, RoutedEventArgs e)
        {
            SellItems("Milk");
            UpdateQuanityUI("Milk", MilkInventoryQuantity, SellMilkButton);
        }
        //Sell Bread Button
        private void SellBread(object sender, RoutedEventArgs e)
        {
            SellItems("Bread");
            UpdateQuanityUI("Bread", BreadInventoryQuantity, SellBreadButton);
        }

        //Sell Eggs Button
        private void SellEggs(object sender, RoutedEventArgs e)
        {
            SellItems("Eggs");
            UpdateQuanityUI("Eggs", EggsInventoryQuantity, SellEggsButton);
        }
    
        //Sell Cheese Button
        private void SellCheese(object sender, RoutedEventArgs e)
        {
            SellItems("Cheese");
            UpdateQuanityUI("Cheese", CheeseInventoryQuantity, SellCheeseButton);
        }
        //Sell Tomato Button
        private void SellTomato(object sender, RoutedEventArgs e)
        {
            SellItems("Tomato");
            UpdateQuanityUI("Tomato", TomatoInventoryQuantity, SellTomatoButton);
        }
        //Sell Apple Button
        private void SellApple(object sender, RoutedEventArgs e)
        {
            SellItems("Apple");
            UpdateQuanityUI("Apple", AppleInventoryQuantity, SellAppleButton);
        }
        #endregion SellSpecificItems

        #region BuyAndSellItems
        //Buy Items with Name Function
        public void BuyItems(string itemName)
        {

            Item? item = itemsList.Find(item => item.itemName == itemName);
            if (item != null)
            {
                if (Currency >= item.price)
                {
                    Currency -= item.price;
                    Debug.WriteLine("Bought " + item.itemName);
                    UpdateCurrencyText();
                    BoughtItemText.Text = "You Bought " + item.itemName + " for " + item.price + "$";
                    boughtItemsList.Add(item);
                    item.quantity += 1;

                }
            }

        }
        //Sell Items with Name Function
        public void SellItems(string itemName)
        {
            Item? item = itemsList.Find(item => item.itemName == itemName);
            if (item != null && item.quantity >= 1)
            {
                Currency += item.price;
                UpdateCurrencyText();
                boughtItemsList.Remove(item);
                Debug.WriteLine("Sold " + item.itemName);
                BoughtItemText.Text = "You Sold " + item.itemName + " for " + item.price + "$";
                item.quantity -= 1;

            }
        }
        #endregion BuyAndSellItems
        #region UI Handler
        private void UpdateQuanityUI(string itemName, TextBlock itemTextBlock,Button sellButton)
        {
            Item? item = itemsList.Find(item => item.itemName == itemName);
            if (item != null)
            {
                itemTextBlock.Text = item.itemName + " Quantity: " + item.quantity.ToString();
            }
            if (item != null)
            {
                if (item.quantity == 0)
                {
                    sellButton.Visibility = Visibility.Collapsed;
                    itemTextBlock.Visibility = Visibility.Collapsed;
                }
                else
                {
                    sellButton.Visibility = Visibility.Visible;
                    itemTextBlock.Visibility = Visibility.Visible;
                }
            }
        }

        private void UpdateCurrencyText()
        {
            CurrencyText.Text = "Currency: " + Currency.ToString() + "$";
        }
    }
}
#endregion UI Handler