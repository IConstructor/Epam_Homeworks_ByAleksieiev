using System.Globalization;
using System.Runtime.InteropServices;
using Epam_homeworkDI_ByAleksieiev_BLL;
using Epam_homeworkDI_ByAleksieiev_DAL;
using Epam_homeworkDI_ByAleksieiev_DAL.Repositories;
using System.Windows;
using System.Windows.Controls;

namespace Epam_homeworkDI_ByAleksieiev_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BuyButton.IsEnabled = false;
            _computerService = new ComputerService(new ComputerRepository());
            _customerService = new CustomerService(new CustomerRepository());
            _producerService = new ProducerService(new ProducerRepository());

            CustomerListBox.ItemsSource = _customerService.GetAllCustomers();
            ProducersListBox.ItemsSource = _producerService.GetAllProducers();
        }

        private ComputerService _computerService;
        CustomerService _customerService;
        private ProducerService _producerService;

        private void CustomerListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CustomerListBox.SelectedIndex != -1)
            {
                MoneyLabel.Content = "Money " + _customerService.GetAllCustomers()[CustomerListBox.SelectedIndex].Money;
            }
            else
            {
                MoneyLabel.Content = "";
            }
            IsItemsSelected();
        }

        private void ProducersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProducersListBox.SelectedIndex != -1)
            {
                var list = _computerService.GetComputersByProducerName(ProducersListBox.SelectedItem.ToString());
                ComputersListBox.Items.Clear();
                foreach (var item in list)
                {
                    ComputersListBox.Items.Add(item);
                }
                ComputersListBox.Items.Refresh();
                IsItemsSelected();
            }
        }

        private void ComputersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var computerEntity = ComputersListBox.SelectedItem as ComputerEntity;
            if (computerEntity != null)
                PriceLabel.Content = computerEntity.Price.ToString(CultureInfo.InvariantCulture);
            else PriceLabel.Content = "";
            IsItemsSelected();
        }

        public void IsItemsSelected()
        {
            if(CustomerListBox.SelectedIndex != -1 && ProducersListBox.SelectedIndex != -1 && ComputersListBox.SelectedIndex != -1)
            {
                BuyButton.IsEnabled = true;
            }
            else
            {
                BuyButton.IsEnabled = false;
            }
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckAccount())
            {
                _customerService.AddComputer(CustomerListBox.SelectedIndex, computer: (ComputersListBox.SelectedItems as ComputerEntity));

                _computerService.DeleteComputer(ComputersListBox.SelectedItem as ComputerEntity);

                ComputersListBox.Items.Remove(ComputersListBox.SelectedItem);
                ComputersListBox.Items.Refresh();

                ComputersListBox.SelectedIndex = -1;
                int tmp = CustomerListBox.SelectedIndex;
                CustomerListBox.SelectedIndex = -1;
                CustomerListBox.SelectedIndex = tmp;
                //ProducersListBox.SelectedIndex = -1;

                IsItemsSelected();
                MessageBox.Show("Successful transaction");
            }
            else
            {
                MessageBox.Show("You don't have enough money to buy the computer.");
            }
        }


        private bool CheckAccount()
        {
            var customerEntity = CustomerListBox.SelectedItem as CustomerEntity;
            var computerEntity = ComputersListBox.SelectedItem as ComputerEntity;
            if (computerEntity != null && (customerEntity != null && customerEntity.Money >= computerEntity.Price))
            {
                ((CustomerEntity) CustomerListBox.SelectedItem).Money -= ((ComputerEntity) ComputersListBox.SelectedItem).Price;
                _customerService.ModificateUser((CustomerEntity)CustomerListBox.SelectedItem);
                return true;
            }

            return false;
        }
    }
}
