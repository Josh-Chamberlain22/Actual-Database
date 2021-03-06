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
using System.Data.OleDb;
//Name: Joshua Chamberlain
//Date: 02/14/2022
//Description: This program connects to a database and displays the data in the textbox using a button.
namespace Database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OleDbConnection cn;
        OleDbConnection cn1;
        public MainWindow()
        {
            InitializeComponent();
            cn = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = |DataDirectory|Actual Database.accdb");
            cn1 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = |DataDirectory|Actual Database.accdb");
        }
        //Allows the button to display the text from the Assets table.
        private void See_Assets_Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from Assets";
            OleDbCommand cmd = new OleDbCommand(query, cn);
            cn.Open();
            OleDbDataReader read = cmd.ExecuteReader();
            string data = "";
            while (read.Read())
            {
                data += "Employee ID" + "\n";
                data += read[0].ToString() + "\n";
                data += "Asset ID" + "\n";
                data += read[1].ToString() + "\n";
                data += "Description" + "\n";
                data += read[2].ToString() + "\n";
            }
            this.Asset_Table.Text = data;
            cn.Close();
        }
        // Allows the Button to display the text from the Employees table.
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string query1 = "select * from Employees";
            OleDbCommand cmd1 = new OleDbCommand(query1, cn1);
            cn1.Open();
            OleDbDataReader read1 = cmd1.ExecuteReader();
            string Edata = "";
            while(read1.Read())
            {
                Edata += "Employee ID" + "\n";
                Edata += read1[0].ToString() + "\n";
                Edata += "First Name" + "\n";
                Edata += read1[1].ToString() + "\n";
                Edata += "Last Name: " + "\n";
                Edata += read1[2].ToString() + "\n";
            }
            this.Employee_Table.Text = Edata;
            cn1.Close();
        }
    }
}
