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

namespace CookingBytes.Controls
{
    /// <summary>
    /// Interaction logic for RecipeDisplay.xaml
    /// </summary>
    public partial class RecipeDisplay : UserControl
    {
        public RecipeDisplay(Cooking.Recipe recipe)
        {
            InitializeComponent();
            int row = 0;
            foreach (var ingredient in recipe.Ingredients)
            {
                Controls.Ingredient i = new Controls.Ingredient(ingredient);
                RecipeGrid.RowDefinitions.Add(new RowDefinition());
                Grid.SetRow(i, row++);
                Grid.SetColumn(i, 0);
                RecipeGrid.Children.Add(i);
            }
            RecipeGrid.RowDefinitions.Add(new RowDefinition());
            UIElement sep = new Separator();
            Grid.SetRow(sep, row++);
            Grid.SetColumn(sep, 0);
            RecipeGrid.Children.Add(sep);
            int stepNum = 0;
            foreach (var step in recipe.Steps)
            {
                Controls.Step s = new Step(++stepNum, step);
                RecipeGrid.RowDefinitions.Add(new RowDefinition());
                Grid.SetRow(s, row++);
                Grid.SetColumn(s, 0);
                RecipeGrid.Children.Add(s);
            }
            RecipeGrid.RowDefinitions.Add(new RowDefinition());
            sep = new Separator();
            Grid.SetRow(sep, row++);
            Grid.SetColumn(sep, 0);
            RecipeGrid.Children.Add(sep);
        }
    }
}
