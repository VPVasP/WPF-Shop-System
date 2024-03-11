using System.Diagnostics;
using System.Windows;
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

            SellMilkButton.Visibility = Visibility.Visible;
            MilkInventoryQuantity.Visibility = Visibility.Visible;
            MilkInventoryQuantityUI();
        }

        //Buy Bread Button
        private void BuyBread(object sender, RoutedEventArgs e)
        {
            BuyItems("Bread");
            SellBreadButton.Visibility = Visibility.Visible;
            BreadInventoryQuantity.Visibility = Visibility.Visible;
            BreadInventoryQuantityUI();
        }
        
        //Buy Eggs Button
        private void BuyEggs(object sender, RoutedEventArgs e)
        {
            BuyItems("Eggs");
            SellEggsButton.Visibility = Visibility.Visible;
            EggsInventoryQuantity.Visibility = Visibility.Visible;
            EggsInventoryQuantityUI();
        }
        //Buy Cheese Button
        private void BuyCheese(object sender, RoutedEventArgs e)
        {
            BuyItems("Cheese");
            SellCheeseButton.Visibility = Visibility.Visible;
            CheeseInventoryQuantity.Visibility = Visibility.Visible;
            CheeseInventoryQuantityUI();
        }
        //Buy Tomato Button
        private void BuyTomato(object sender, RoutedEventArgs e)
        {
            BuyItems("Tomato");
            SellTomatoButton.Visibility = Visibility.Visible;
            TomatoInventoryQuantity.Visibility = Visibility.Visible;
            TomatoInventoryQuantityUI();
        }
        //Buy Apple Button
        private void BuyApple(object sender, RoutedEventArgs e)
        {
            BuyItems("Apple");
            SellAppleButton.Visibility = Visibility.Visible;
            AppleInventoryQuantity.Visibility = Visibility.Visible;
            AppleInventoryQuantityUI();
        }
        #endregion BuySpecificItems

        #region SellSpecificItems

        //Sell Milk Button
        private void SellMilk(object sender, RoutedEventArgs e)
        {
            SellItems("Milk");
            MilkInventoryQuantityUI();
        }
        //Sell Bread Button
        private void SellBread(object sender, RoutedEventArgs e)
        {
            SellItems("Bread");
            BreadInventoryQuantityUI();
        }

        //Sell Eggs Button
        private void SellEggs(object sender, RoutedEventArgs e)
        {
            SellItems("Eggs");
            EggsInventoryQuantityUI();
        }
        //Sell Cheese Button
        private void SellCheese(object sender, RoutedEventArgs e)
        {
            SellItems("Cheese");
            CheeseInventoryQuantityUI();
        }
        //Sell Tomato Button
        private void SellTomato(object sender, RoutedEventArgs e)
        {
            SellItems("Tomato");
            TomatoInventoryQuantityUI();
        }
        //Sell Apple Button
        private void SellApple(object sender, RoutedEventArgs e)
        {
            SellItems("Apple");
            AppleInventoryQuantityUI();
        }
        #endregion SellSpecificItems

        #region BuyAndSellItems
        //Buy Items with Name Function
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
                    BoughtItemText.Text = "You Bought " + item.itemName + " for " + item.price + "$";
                    boughtItemsList.Add(item);
                    item.quantity += 1;

                }
            }

        }
        //Sell Items with Name Function
        public void SellItems(string itemName)
        {
            Item item = itemsList.Find(item => item.itemName == itemName);
            if (item != null && item.quantity >= 1)
            {
                Currency += item.price;
                UpdateCurrencyText();
                boughtItemsList.Remove(item);
                Debug.WriteLine("Sold " + item.itemName);
                BoughtItemText.Text = "You Sold " + item.itemName + " for " + item.price +"$"; 
                item.quantity -= 1;

            }
        }
        #endregion BuyAndSellItems
        #region UI Handler

        //Milk Inventory UI Handler
        private void MilkInventoryQuantityUI()
        {
            Item item = itemsList.Find(item => item.itemName == "Milk");
            if (item != null)
            {
                MilkInventoryQuantity.Text = item.itemName + " Quantity: " + item.quantity.ToString();
            }
            if (item.quantity == 0)
            {
                SellMilkButton.Visibility = Visibility.Collapsed;
                MilkInventoryQuantity.Visibility = Visibility.Collapsed;
            }
        }

        //Bread Inventory UI Handler
        private void BreadInventoryQuantityUI()
        {
            Item item = itemsList.Find(item => item.itemName == "Bread");
            if (item != null)
            {
                BreadInventoryQuantity.Text = item.itemName + " Quantity: " + item.quantity.ToString();
            }
            if (item.quantity == 0)
            {
                SellBreadButton.Visibility = Visibility.Collapsed;
                BreadInventoryQuantity.Visibility = Visibility.Collapsed;
            }
        }

        //Eggs Inventory UI Handler
        private void EggsInventoryQuantityUI()
        {
            Item item = itemsList.Find(item => item.itemName == "Eggs");
            if (item != null)
            {
                EggsInventoryQuantity.Text = item.itemName + " Quantity: " + item.quantity.ToString();
            }
            if (item.quantity == 0)
            {
                SellEggsButton.Visibility = Visibility.Collapsed;
                EggsInventoryQuantity.Visibility = Visibility.Collapsed;
            }
        }

        //CheeseInventory UI Handler
        private void CheeseInventoryQuantityUI()
        {
            Item item = itemsList.Find(item => item.itemName == "Cheese");
            if (item != null)
            {
                CheeseInventoryQuantity.Text = item.itemName + " Quantity: " + item.quantity.ToString();
            }
            if (item.quantity == 0)
            {
                SellCheeseButton.Visibility = Visibility.Collapsed;
                CheeseInventoryQuantity.Visibility = Visibility.Collapsed;
            }
        }

        //Tomato Inventory UI Handler
        private void TomatoInventoryQuantityUI()
        {
            Item item = itemsList.Find(item => item.itemName == "Tomato");
            if (item != null)
            {
                TomatoInventoryQuantity.Text = item.itemName + " Quantity: " + item.quantity.ToString();
            }
            if (item.quantity == 0)
            {
                SellTomatoButton.Visibility = Visibility.Collapsed;
                TomatoInventoryQuantity.Visibility = Visibility.Collapsed;
            }
        }

        //Apple Inventory UI Handler
        private void AppleInventoryQuantityUI()
        {
            Item item = itemsList.Find(item => item.itemName == "Apple");
            if (item != null)
            {
                AppleInventoryQuantity.Text =item.itemName+ " Quantity: " + item.quantity.ToString();
            }
            if (item.quantity == 0)
            {
                SellAppleButton.Visibility = Visibility.Collapsed;
                AppleInventoryQuantity.Visibility = Visibility.Collapsed;
            }
        }
        private void UpdateCurrencyText()
        {
            CurrencyText.Text = "Currency: " + Currency.ToString() + "$";
        }


    }



}
#endregion UI Handler