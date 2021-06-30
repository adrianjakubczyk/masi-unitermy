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

            
            //modified = false;
            //nowy = false;
            //lbUniterms.SelectionChanged += ehlbUNitermsSelectionChanged;
            
            _drawing = new Drawing(uiCanvas.ActualWidth, uiCanvas.ActualHeight);
            _drawing.FontFamily = new FontFamily(uiFontFamily.SelectedItem.ToString());
            _drawing.FontSize = Int32.Parse(uiFontSize.SelectedItem.ToString());
            uiCanvas.Children.Add(_drawing);


            uiBtnNew.Click += ClearCanvas;
            uiBtnCycle.Click += DrawBlueCanvas;
            uiBtnCycle.Click += AddCycleUniterm;
            uiBtnElimination.Click += AddEliminationUniterm;

            uiExchange.Click += UpdateCanvas;
            uiFontFamily.SelectionChanged += UpdateCanvas;
            uiFontSize.SelectionChanged += UpdateCanvas;
        }

        private void AddCycleUniterm(object sender, RoutedEventArgs e)
        {
            AddCycle addCycleWindow = new AddCycle();

            bool? added = addCycleWindow.ShowDialog();
            if ((bool)added)
            {
                string variable = addCycleWindow.cuiVariable.Text;
                if (variable.Length<50&& variable.Length > 0)
                {
                    _drawing.CycleVariable = variable;
                }
                else
                {
                    MessageBox.Show("Zmienna jest za długa");
                }

                string operation = addCycleWindow.cuiOperation.Text;
                if (operation.Length < 50 && operation.Length > 0)
                {
                    _drawing.CycleOperation = operation;
                }
                else
                {
                    MessageBox.Show("Operacja jest za długa");
                }
            }
        }
        private void AddEliminationUniterm(object sender, RoutedEventArgs e)
        {
            AddElimination addEliminationWindow = new AddElimination();

            bool? added = addEliminationWindow.ShowDialog();
            if ((bool)added)
            {
                string eliminationA = addEliminationWindow.euiA.Text;
                if (eliminationA.Length < 50 && eliminationA.Length > 0)
                {
                    _drawing.EliminationA = eliminationA;
                }
                else
                {
                    MessageBox.Show("A jest za długa");
                }

                string eliminationB = addEliminationWindow.euiA.Text;
                if (eliminationB.Length < 50 && eliminationB.Length > 0)
                {
                    _drawing.EliminationB = eliminationB;
                }
                else
                {
                    MessageBox.Show("B jest za długa");
                }

                string eliminationCondition = addEliminationWindow.euiCondition.Text;
                if (eliminationCondition.Length < 50 && eliminationCondition.Length > 0)
                {
                    _drawing.EliminationCondition = eliminationCondition;
                }
                else
                {
                    MessageBox.Show("Warunek jest za długi");
                }

                _drawing.EliminationOperation = addEliminationWindow.euiOperation.SelectedItem.ToString();
            }
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

        private void UpdateCanvas(object sender, RoutedEventArgs e)
        {
            uiCanvas.Children.Remove(_drawing);

            _drawing.FontFamily = new FontFamily(uiFontFamily.SelectedItem.ToString());
            _drawing.FontSize = Int32.Parse(uiFontSize.SelectedItem.ToString());
            _drawing.Exchanged = (bool)uiExchange.IsChecked;

            Console.WriteLine(_drawing.FontFamily + " size:" + _drawing.FontSize + " exchanged:" + _drawing.Exchanged);

            _drawing.Update();

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
