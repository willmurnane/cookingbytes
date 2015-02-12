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
    /// Interaction logic for Step.xaml
    /// </summary>
    public partial class Step : UserControl
    {
        protected Cooking.Step theStep;
        public int StepNumber { get; protected set; }
        public Step(int stepNumber, Cooking.Step step)
        {
            StepNumber = stepNumber;
            InitializeComponent();
            this.DataContext = theStep = step;
        }
    }
}
