using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CaliburnPlayground.Views
{
    /// <summary>
    /// Interaction logic for MatrixView.xaml
    /// </summary>
    public partial class MatrixView : UserControl
    {
        public MatrixView()
        {
            InitializeComponent();

        }

        private void stackPanel_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Left || e.Key == Key.Right)
            {
                var children = FindVisualChildren<DataGrid>(ItemsCont);
                var items = children.Where(m => m.Tag != null).ToList();
                for (int i = 0; i < items.Count(); i++)
                {
                    if (items.ElementAt(i) == sender as DataGrid)
                    {
                        var x = (sender as DataGrid).SelectedIndex;

                        int nextIndex = Key.Left == e.Key ? i - 1 : i + 1;
                        if (nextIndex >= 0 && nextIndex < items.Count())
                        {
                            items.ElementAt(nextIndex).SelectedIndex = x;
                            items.ElementAt(nextIndex).Focus();
                            items.ElementAt(nextIndex).CurrentCell = new DataGridCellInfo(items.ElementAt(nextIndex).Items[items.ElementAt(nextIndex).SelectedIndex], items.ElementAt(nextIndex).Columns[0]);
                        }
                    }
                }
                e.Handled = true;
            }
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}