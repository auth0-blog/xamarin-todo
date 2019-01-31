using System;

using Xamarin.Forms;

namespace Todo.CustomControls
{

    public class TodoCell : TextCell
    {
        public static readonly BindableProperty IsCheckedProperty =
            BindableProperty.Create("IsChecked", typeof(bool), typeof(TodoCell), defaultValue: false);

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }
    }
}
