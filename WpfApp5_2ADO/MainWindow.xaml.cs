using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.Linq;
using System.Text.RegularExpressions;

namespace WpfApp5_2ADO

{  
    public partial class MainWindow : Window
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=usersEmail;Integrated Security=True";
       
        public MainWindow()
        {
            InitializeComponent();  
        }
        private void CheckEmail()
        {  DataContext db = new DataContext(connectionString);
         const string EMAIL_PATTENR = @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)";
            Table<UserEmail> data = db.GetTable<UserEmail>();
            if (Regex.IsMatch(userEmail.Text, EMAIL_PATTENR))
            {
                MessageBox.Show("Good!");
                UserEmail userA = new UserEmail { Email = userEmail.Text, Name = userName.Text };
                db.GetTable<UserEmail>().InsertOnSubmit(userA);
                db.SubmitChanges();
                foreach(var user in data)
                {
                    res.Text+="email: "+user.Email + " name: " + user.Name+"\r\n";
                }
            }
            else
            {
                MessageBox.Show("not correct email,try again");
            }
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            CheckEmail();
        }
    }
}