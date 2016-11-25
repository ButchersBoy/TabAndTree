using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace TabAndTree
{
    public class MainViewModel : ViewModelBase
    {

        public MainViewModel()
        {
            _elements = new ObservableCollection<InfoElement>();

            for(var i = 0; i <8;i++)
            {
                _elements.Add(new InfoElement()
                {
                    Id=(i+1).ToString(),
                    Title =$"Root _ {(i+1)}",
                });
            }
        }

        /// <summary>
        /// The <see cref="Elements" /> property's name.
        /// </summary>
        public const string ElementsPropertyName = "Elements";

        private ObservableCollection<InfoElement> _elements = null;

        /// <summary>
        /// Sets and gets the Elements property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public ObservableCollection<InfoElement> Elements
        {
            get
            {
                return _elements;
            }

            set
            {
                if (_elements == value)
                {
                    return;
                }

                var oldValue = _elements;
                _elements = value;
                RaisePropertyChanged(ElementsPropertyName, oldValue, value, true);
            }
        }


     
    }
}
