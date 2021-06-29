using System;
using System.Collections.Generic;
using System.Data;
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

namespace ZamianaUnitermu
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Database _database;
        private Drawing _drawing;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (FontFamily f in Fonts.SystemFontFamilies)
            {
                uiFontFamily.Items.Add(f);
            }
            if (uiFontFamily.Items.Count > 0)
                uiFontFamily.SelectedIndex = 0;

            for (int i = 8; i <= 40; i++)
            {
                uiFontSize.Items.Add(i);
            }
            uiFontSize.SelectedIndex = 4;


            _database = new Database();

            RefreshUnitermsList();

            //uiUnitermsList.Items.Clear();


            //foreach (DataRow dataRow in _database.ExecuteQuery("select nazwa from unitermy;"))
            //{
            //    uiUnitermsList.Items.Add(dataRow["nazwa"]);
            //}
            //modified = false;
            //nowy = false;
            //lbUniterms.SelectionChanged += ehlbUNitermsSelectionChanged;
            DrawingVisual dv = new DrawingVisual();
            _drawing = new Drawing(uiCanvas.ActualWidth, uiCanvas.ActualHeight);
            uiCanvas.Children.Add(_drawing);


            uiBtnNew.Click += ClearCanvas;
            uiBtnCycle.Click += DrawBlueCanvas;
        }
        private void DrawBlueCanvas(object sender, RoutedEventArgs e)
        {
            uiCanvas.Children.Remove(_drawing);

            _drawing.Update();
            uiCanvas.Children.Add(_drawing);
        }

        private void ClearCanvas(object sender, RoutedEventArgs e)
        {
            uiCanvas.Children.Remove(_drawing);
            _drawing.Clear();
            uiCanvas.Children.Add(_drawing);

        }

        private void RefreshUnitermsList()
        {
            uiUnitermsList.Items.Clear();

            foreach (DataRow dataRow in _database.ExecuteQuery("select nazwa from unitermy;"))
            {
                uiUnitermsList.Items.Add(dataRow["nazwa"]);
            }
        }


    }
}
