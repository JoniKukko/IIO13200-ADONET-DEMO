//Koodannut ja testannut toimivaksi 6.3.2014 EsaSalmik
using System.Windows;
using JAMK.ICT.Data;
using System;
using System.Data;

namespace JAMK.ICT.ADOBlanco
{
    public partial class MainWindow : Window
    {
        private string ConnStr;
        private string TableName;
        private DataTable dtData;



        public MainWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }



        private void IniMyStuff()
        {
            this.ConnStr = Properties.Settings.Default.Tietokanta;
            this.TableName = Properties.Settings.Default.Taulu;

            this.getData();
            this.FillMyCombo();
        }



        private void getData()
        {
            string message = "";
            try
            {
                this.dtData = DBPlacebo.GetAllCustomersFromSQLServer(
                    this.ConnStr, this.TableName, out message
                    );
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                this.lbMessages.Content = message;
            }
        }



        private void FillMyCombo()
        {
            string message = "";
            try
            {
                cbCountries.ItemsSource = this.dtData.DefaultView;
                cbCountries.DisplayMemberPath = "City";
                cbCountries.SelectedValuePath = "City";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                this.lbMessages.Content = message;
            }
        }
        
        

        private void btnGet3_Click(object sender, RoutedEventArgs e)
        {
            this.dgCustomers.ItemsSource = DBPlacebo.GetTestCustomers().DefaultView;
        }

        

        private void btnGetAll_Click(object sender, RoutedEventArgs e)
        {
            string message = "";
            try
            {
                this.dgCustomers.ItemsSource = this.dtData.DefaultView;
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            finally
            {
                this.lbMessages.Content = message;
            }

        }

        

        private void btnGetFrom_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }
        


        private void btnYield_Click(object sender, RoutedEventArgs e)
        {
            JAMK.ICT.JSON.JSONPlacebo2015 roskaa = new JAMK.ICT.JSON.JSONPlacebo2015();
            MessageBox.Show(roskaa.Yield());
        }
    }
}
