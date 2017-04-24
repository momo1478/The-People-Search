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
using System.Windows.Shapes;

namespace The_People_Search
{
    /// <summary>
    /// Interaction logic for NewUser.xaml
    /// </summary>
    public partial class NewUser : Window
    {
        PersonContext mainWindowPC;

        public NewUser(PersonContext context)
        {
            InitializeComponent();
            mainWindowPC = context;
        }

        private void Button_Create_User_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Person personToAdd = new Person()
                {
                    FirstName = textBox_FirstName.Text,
                    LastName = textBox_LastName.Text,
                    Address = textBox_Address.Text,
                    Age = int.Parse(textBox_Age.Text),
                    Interests = textBox_Interests.Text
                };

                mainWindowPC.People.Add(personToAdd);


                mainWindowPC.SaveChanges();
                MessageBox.Show("Successfully Added User!", "Added User!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to add user to Database, ensure you haven't added this person to the database!", "Unable to add Person", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            this.Close();
        }
    }
}
