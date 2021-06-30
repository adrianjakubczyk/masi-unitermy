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
        private int _rowIndex;
        private bool _modified;
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
                uiFontFamily.SelectedIndex = uiFontFamily.Items.IndexOf(new FontFamily("Arial"));


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


            uiBtnNew.Click += Clear;
            uiBtnCycle.Click += AddCycleUniterm;
            uiBtnElimination.Click += AddEliminationUniterm;
            uiBtnSave.Click += Save;
            uiBtnDelete.Click += Delete;

            uiExchange.Click += UpdateCanvas;
            uiFontFamily.SelectionChanged += UpdateCanvas;
            uiFontSize.SelectionChanged += UpdateCanvas;
            uiUnitermsList.SelectionChanged += SelectFromList;

            
            uiName.TextChanged += TextChanged;
            uiDescription.TextChanged += TextChanged;

            _rowIndex = -1;
            _modified = false;
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
                    MessageBox.Show("Zmienna: nie podano lub jest za długa");
                }

                string operation = addCycleWindow.cuiOperation.Text;
                if (operation.Length < 50 && operation.Length > 0)
                {
                    _drawing.CycleOperation = operation;
                }
                else
                {
                    MessageBox.Show("Operacja: nie podano lub jest za długa");
                }
                UpdateCanvas(sender, e);
                _modified = true;
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
                    MessageBox.Show("A: nie podano lub jest za długa");
                }

                string eliminationB = addEliminationWindow.euiB.Text;
                if (eliminationB.Length < 50 && eliminationB.Length > 0)
                {
                    _drawing.EliminationB = eliminationB;
                }
                else
                {
                    MessageBox.Show("B: nie podano lub jest za długa");
                }

                string eliminationCondition = addEliminationWindow.euiCondition.Text;
                if (eliminationCondition.Length < 50 && eliminationCondition.Length > 0)
                {
                    _drawing.EliminationCondition = eliminationCondition;
                }
                else
                {
                    MessageBox.Show("Warunek: nie podano lub jest za długi");
                }

                _drawing.EliminationOperation = addEliminationWindow.euiOperation.Text;

                UpdateCanvas(sender,e);
                _modified = true;
            }
        }

        private void TextChanged(object sender, RoutedEventArgs e)
        {
            _modified = true;
        }
            private void Clear(object sender, RoutedEventArgs e)
        {
            uiCanvas.Children.Remove(_drawing);
            _drawing.CycleVariable = "";
            _drawing.CycleOperation = "";
            _drawing.EliminationA = "";
            _drawing.EliminationB = "";
            _drawing.EliminationCondition = "";
            _drawing.EliminationOperation = "";
            _drawing.Clear();
            _rowIndex = -1;
            _modified = false;
            uiName.Text = "";
            uiDescription.Text = "";
            uiCanvas.Children.Add(_drawing);

        }

        private void UpdateCanvas(object sender, RoutedEventArgs e)
        {
            uiCanvas.Children.Remove(_drawing);

            _drawing.FontFamily = new FontFamily(uiFontFamily.SelectedItem.ToString());
            _drawing.FontSize = Int32.Parse(uiFontSize.SelectedItem.ToString());
            _drawing.Exchanged = (bool)uiExchange.IsChecked;

            _drawing.Update();

            uiCanvas.Children.Add(_drawing);

        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (uiName.Text.Length > 0 && uiName.Text.Length < 50)
            {
                if (_rowIndex>0)
                {
                    string query = "UPDATE uniterms SET " +
                        "variable='" + _drawing.CycleVariable + "', " +
                        "operation='" + _drawing.CycleOperation + "', " +
                        "eA='" + _drawing.EliminationA + "', " +
                        "eB='" + _drawing.EliminationB + "', " +
                        "eCondition='" + _drawing.EliminationCondition + "', " +
                        "eOperation='" + _drawing.EliminationOperation + "', " +
                        "name='" + uiName.Text + "', " +
                        "description='" + uiDescription.Text + "' " +
                        "WHERE id='" + _rowIndex + "';";

                    _database.Execute(query);


                }
                else
                {
                    string query = "SELECT IDENT_CURRENT('uniterms')+1 as id;";
                    foreach (DataRow dataRow in _database.Query(query))
                    {
                        _rowIndex = Int32.Parse(dataRow["id"].ToString());
                    }
                    

                    query = "INSERT INTO uniterms (variable,operation,eA,eB,eCondition,eOperation,name,description) VALUES('" +
                    _drawing.CycleVariable + "', '" +
                    _drawing.CycleOperation + "', '" +
                    _drawing.EliminationA + "', '" +
                    _drawing.EliminationB + "', '" +
                    _drawing.EliminationCondition + "', '" +
                    _drawing.EliminationOperation + "', '" +
                    uiName.Text + "', '" +
                    uiDescription.Text + "');";

                    _database.Execute(query);


                }
                _modified = false;
                RefreshUnitermsList();

            }
            else
            {
                MessageBox.Show("Błędna nazwa");
            }

        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            if (_rowIndex > 0)
            {
                switch (MessageBox.Show("Czy na pewno chcesz usunąć?", "Usuwanie", MessageBoxButton.YesNoCancel, MessageBoxImage.Question))
                {
                    case MessageBoxResult.Yes:
                        {
                            string query = "DELETE FROM uniterms WHERE id=" + _rowIndex;
                            _database.Execute(query);
                            RefreshUnitermsList();
                            Clear(null,null);
                            break;
                        }
                    case MessageBoxResult.No:
                    case MessageBoxResult.Cancel:
                    default: break;
                }
            }
        }

            private void SelectFromList(object sender, RoutedEventArgs e)
        {
            if (uiUnitermsList.SelectedItem != null)
            {
                string query = "SELECT * FROM uniterms WHERE id=" + uiUnitermsList.SelectedItem.ToString().Split(' ')[0];

                if (_modified)
                {
                    switch (MessageBox.Show("Czy chcesz zapisać zmiany?", "Zapis", MessageBoxButton.YesNoCancel, MessageBoxImage.Question))
                    {
                        case MessageBoxResult.Yes:
                            {
                                Save(null, null);
                                break;
                            }
                        case MessageBoxResult.No:
                        case MessageBoxResult.Cancel:
                        default: break;
                    }
                }

                foreach (DataRow dataRow in _database.Query(query))
                {
                    _drawing.CycleVariable = dataRow["variable"].ToString();
                    _drawing.CycleOperation = dataRow["operation"].ToString();
                    _drawing.EliminationA = dataRow["eA"].ToString();
                    _drawing.EliminationB = dataRow["eB"].ToString();
                    _drawing.EliminationCondition = dataRow["eCondition"].ToString();
                    _drawing.EliminationOperation = dataRow["eOperation"].ToString();
                    _rowIndex = Int32.Parse(dataRow["id"].ToString());
                    uiName.Text = dataRow["name"].ToString();
                    uiDescription.Text = dataRow["description"].ToString();
                    _modified = false;
                }
                UpdateCanvas(sender, e);
            }
            
        }


        private void RefreshUnitermsList()
        {
            uiUnitermsList.Items.Clear();

            foreach (DataRow dataRow in _database.Query("select id,name from uniterms;"))
            {
                uiUnitermsList.Items.Add(dataRow["id"]+" "+dataRow["name"]);
            }
        }

    }
}
