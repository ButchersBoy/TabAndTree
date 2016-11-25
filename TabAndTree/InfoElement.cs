using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace TabAndTree
{
    public class InfoElement : ViewModelBase
    {

        public InfoElement()
        {
            Children = new ObservableCollection<InfoElement>();
        }

        /// <summary>
        /// The <see cref="IsExpanded" /> property's name.
        /// </summary>
        public const string IsExpandedPropertyName = "IsExpanded";

        private bool _isExpanded = false;

        /// <summary>
        /// Sets and gets the IsExpanded property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public bool IsExpanded
        {
            get
            {
                return _isExpanded;
            }

            set
            {
                if (_isExpanded == value)
                {
                    return;
                }

                var oldValue = _isExpanded;
                _isExpanded = value;

                if(_isExpanded)
                {

     
         
                    OnExpandedChanged();
                }

                RaisePropertyChanged(IsExpandedPropertyName, oldValue, value, true);
            }
        }
        async void OnExpandedChanged()
        {

            Children.Clear();

            Children.Add(new InfoElement() { Title = "Loading......", });

            await Task.Factory.StartNew(() =>
            {
            });
            await Task.Delay(3000);
            Children.Clear();
            for (var i = 0; i < 11; i++)
            {
                Children.Add(new InfoElement()
                {
                    Id = (i + 1).ToString(),
                    Title = $"Title__{_id}___{(i + 1)}",
                });

            }




            //await Task.Delay(5000);
           // RaisePropertyChanged(ChildrenPropertyName);
        }
        /// <summary>
        /// The <see cref="IsSelected" /> property's name.
        /// </summary>
        public const string IsSelectedPropertyName = "IsSelected";

        private bool _isSelected = false;

        /// <summary>
        /// Sets and gets the IsSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }

            set
            {
                if (_isSelected == value)
                {
                    return;
                }



                var oldValue = _isSelected;
                _isSelected = value;


                IsExpanded = _isSelected;

                RaisePropertyChanged(IsSelectedPropertyName, oldValue, value, true);
            }
        }


        /// <summary>
            /// The <see cref="Id" /> property's name.
            /// </summary>
        public const string IdPropertyName = "Id";

        private string _id = string.Empty;

        /// <summary>
        /// Sets and gets the Id property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                if (_id == value)
                {
                    return;
                }

                var oldValue = _id;
                _id = value;
                RaisePropertyChanged(IdPropertyName, oldValue, value, true);
            }
        }


        /// <summary>
            /// The <see cref="Title" /> property's name.
            /// </summary>
        public const string TitlePropertyName = "Title";

        private string _title = string.Empty;

        /// <summary>
        /// Sets and gets the Title property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                if (_title == value)
                {
                    return;
                }

                var oldValue = _title;
                _title = value;
                RaisePropertyChanged(TitlePropertyName, oldValue, value, true);
            }
        }

        /// <summary>
            /// The <see cref="Children" /> property's name.
            /// </summary>
        public const string ChildrenPropertyName = "Children";

        private ObservableCollection<InfoElement> _children = null;

        /// <summary>
        /// Sets and gets the Children property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public ObservableCollection<InfoElement> Children
        {
            get;set;
            //get
            //{
            //    return _children;
            //}

            //set
            //{
            //    if (_children == value)
            //    {
            //        return;
            //    }

            //    var oldValue = _children;
            //    _children = value;
            //    RaisePropertyChanged(ChildrenPropertyName, oldValue, value, true);
            //}
        }
    }
}
