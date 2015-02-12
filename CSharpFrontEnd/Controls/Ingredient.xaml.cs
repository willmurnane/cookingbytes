﻿using System;
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
    /// Interaction logic for Ingredient.xaml
    /// </summary>
    public partial class Ingredient : UserControl
    {
        public Cooking.Ingredient ingObject;
        public Ingredient(Cooking.Ingredient ingredient)
        {
            InitializeComponent();
            this.DataContext = ingObject = ingredient;
        }
    }
}
