using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Person> Personenliste { get; set; } = new ObservableCollection<Person>()
        {
            new Person(){Vorname="Rainer", Nachname="Zufall", Alter=65},
            new Person(){Vorname="Hugo", Nachname="Müller", Alter=15},
        };

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        private void Btn_Show_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((Spl_DataContextBeispiel.DataContext as Person)?.Vorname);
        }

        private void Btn_Altern_Click(object sender, RoutedEventArgs e)
        {
            (Spl_DataContextBeispiel.DataContext as Person).Alter++;
        }

        private void Btn_Neu_Click(object sender, RoutedEventArgs e)
        {
            Personenliste.Add(new Person() { Vorname = "Anna", Nachname = "Nass", Alter = 56 });
        }

        private void Btn_Löschen_Click(object sender, RoutedEventArgs e)
        {
            Personenliste.Remove(Lbx_Personen.SelectedItem as Person);
        }
    }
}
