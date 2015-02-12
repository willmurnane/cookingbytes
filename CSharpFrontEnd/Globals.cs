using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingBytes
{
    public enum MeasurementSystems
    {
        [Description("Metric")]
        Metric,
        [Description("English units")]
        Imperial,
        [Description("English units, converting weights to volumes")]
        ApproximateVolumeForWeight,
    }
    public class Globals : INotifyPropertyChanged
    {
        private Globals()
        {
            _recipeScale = 1.0;
            _measurementSystem = MeasurementSystems.Metric;
        }
        private static Globals instance;
        public static Globals Instance
        {
            get
            {
                if (instance == null)
                    instance = new Globals();
                return instance;
            }
        }
        private MeasurementSystems _measurementSystem;
        public MeasurementSystems MeasurementSystem
        {
            get { return _measurementSystem; }
            set
            {
                _measurementSystem = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MeasurementSystem"));
            }
        }
        private double _recipeScale;
        public double RecipeScale
        {
            get { return _recipeScale; }
            set
            {
                _recipeScale = value;
                PropertyChanged(instance, new PropertyChangedEventArgs("RecipeScale"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
