using System;
using System.Collections.Generic;
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
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace The_People_Search
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PersonContext context;
        public NewUser newUser;
        
        public MainWindow()
        {
            context = new PersonContext();
            newUser = new NewUser(context);

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource personViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("personViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // personViewSource.Source = [generic data source]

            context.People.Load();

            personViewSource.Source = context.People.Local;
        }

        private void Button_Search_Click(object sender, RoutedEventArgs e)
        {
            List<Person> searchResults = context.People.SqlQuery("Select * from Person where FirstName = @p0 or LastName = @p0", TextBox_Search.Text).ToList();
            this.personDataGrid.ItemsSource = searchResults;
        }

        private void Button_NewUser_Click(object sender, RoutedEventArgs e)
        {
            newUser.Show();
            newUser = new NewUser(context);
        }
    }
}
