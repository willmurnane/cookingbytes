using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CookingBytes.Cooking;

namespace CookingBytes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Recipe scrambledEggs;
        public MainWindow()
        {
            InitializeComponent();
            AbstractIngredient theIdeaOfEggs = new AbstractIngredient("Egg");
            AbstractIngredient theIdeaOfSalt = new AbstractIngredient("Salt");
            Ingredient eggs = theIdeaOfEggs.Instantiate(Measurement.Each(2));
            Ingredient pinchOfSalt = theIdeaOfSalt.Instantiate(Measurement.Grams(1));
            Tool nonstickPan = new Tool("Non-stick frying pan");
            Tool whisk = new Tool("Wire whisk");
            Tool offsetSpatula = new Tool("Offset Spatula");
            var preheatPan = new Step("Preheat the frying pan over medium-high heat.", nonstickPan);
            var whiskTheEggs = new FoodProducingStep("Whisk until smooth.", whisk, eggs);
            var addEggsToPan = new FoodProducingStep("Add eggs to pan.", nonstickPan, whiskTheEggs);
            var addSaltToTaste = new FoodProducingStep("Add salt as desired.", null, addEggsToPan, pinchOfSalt);
            var stir = new FoodProducingStep("Stir quickly and thoroughly until eggs reach desired texture. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", offsetSpatula, addSaltToTaste);
            scrambledEggs = new Recipe("Scrambled Eggs", preheatPan, whiskTheEggs, addEggsToPan, addSaltToTaste, stir);
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DisplayRecipe(scrambledEggs);
        }

        public void DisplayRecipe(Recipe what)
        {
            Controls.RecipeDisplay rd = new Controls.RecipeDisplay(what);
            this.RecipeContent.Content = rd;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (sender as ComboBox).SelectedItem as string;
            switch (text)
            {
                case "Metric": Globals.Instance.MeasurementSystem = MeasurementSystems.Metric; break;
                case "Imperial": Globals.Instance.MeasurementSystem = MeasurementSystems.Imperial; break;
                default: throw new NotImplementedException();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Globals.Instance.RecipeScale = 1.0;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Globals.Instance.RecipeScale *= 2;
        }
    }
}
