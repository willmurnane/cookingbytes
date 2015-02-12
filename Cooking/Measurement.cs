using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingBytes.Cooking
{
    public class Measurement : INotifyPropertyChanged
    {
        /// <summary>
        /// Different kinds of measurement
        /// </summary>
        public enum Types
        {
            /// <summary>
            /// Native units: grams
            /// </summary>
            Weight,
            /// <summary>
            /// Native units: liters
            /// </summary>
            Volume,
            /// <summary>
            /// Native units: 1 ea.
            /// </summary>
            Each,
        }
        private Measurement(Types whatKind, double amount)
        {
            Type = whatKind;
            this.amount = amount;
            Globals.Instance.PropertyChanged += Instance_PropertyChanged;
        }

        void Instance_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "MeasurementSystem")
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Units"));
            }
            PropertyChanged(this, new PropertyChangedEventArgs("ScaledAmount"));
        }
        public Types Type { get; protected set; }
        /// <summary>
        /// Amount that is measured, in native units.
        /// </summary>
        public double Amount
        {
            get
            {
                switch (Type)
                {
                    case Types.Weight:
                        switch (Globals.Instance.MeasurementSystem)
                        {
                            case MeasurementSystems.Metric:
                                return amount;
                            case MeasurementSystems.Imperial:
                                return amount / 28.3495;
                            default:
                                throw new NotImplementedException();
                        }
                    case Types.Volume:
                        switch (Globals.Instance.MeasurementSystem)
                        {
                            case MeasurementSystems.Metric:
                                return amount;
                            case MeasurementSystems.Imperial:
                                return amount * 33.814;
                            default:
                                throw new NotImplementedException();
                        }
                    case Types.Each:
                        return amount;
                    default: throw new NotImplementedException();
                }
            }
        }
        public double ScaledAmount
        {
            get
            {
                return Amount * Globals.Instance.RecipeScale;
            }
            set
            {
                Globals.Instance.RecipeScale = value / Amount;
            }
        }
        public string Units
        {
            get
            {
                switch (Type)
                {
                    case Types.Weight:
                        switch (Globals.Instance.MeasurementSystem)
                        {
                            case MeasurementSystems.Metric:
                                return "g";
                            case MeasurementSystems.Imperial:
                                return "oz";
                            default:
                                throw new NotImplementedException();
                        }
                    case Types.Volume:
                        switch (Globals.Instance.MeasurementSystem)
                        {
                            case MeasurementSystems.Metric:
                                return "l";
                            case MeasurementSystems.Imperial:
                                return "fl oz";
                            default:
                                throw new NotImplementedException();
                        }
                    case Types.Each:
                        return "ea";
                    default: throw new NotImplementedException();
                }
            }
        }
        protected double amount;
        public override string ToString()
        {
            return String.Format("{0} {1}", Amount, Units);
        }
        public static Measurement Grams(double howMany)
        {
            return new Measurement(Types.Weight, howMany);
        }
        public static Measurement Kilograms(double howMany)
        {
            return new Measurement(Types.Weight, howMany * 1000);
        }
        public static Measurement Liters(double howMany)
        {
            return new Measurement(Types.Volume, howMany);
        }
        public static Measurement Each(double howMany)
        {
            return new Measurement(Types.Each, howMany);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
