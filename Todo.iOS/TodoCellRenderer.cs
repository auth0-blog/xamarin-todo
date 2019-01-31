using System;
using System.ComponentModel;
using Todo.CustomControls;
using Todo.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TodoCell), typeof(TodoCellRenderer))]
namespace Todo.iOS
{
    public class TodoCellRenderer : TextCellRenderer
    {
        UITableViewCell nativeCell;

        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            nativeCell = base.GetCell(item, reusableCell, tv);

            SetAccessory((TodoCell)item);

            return nativeCell;
        }

        protected override void HandleCellPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            base.HandleCellPropertyChanged(sender, args);

            var cell = (TodoCell)sender;

            if (args.PropertyName == TodoCell.IsCheckedProperty.PropertyName)
            {
                SetAccessory(cell);
            }
        }

        private void SetAccessory(TodoCell cell)
        {
            nativeCell.Accessory = cell.IsChecked ? UITableViewCellAccessory.Checkmark : UITableViewCellAccessory.None;
        }
    }
}
