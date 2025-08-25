using System;
using System.Windows;
using DAL.Entities;

namespace MiniMartHub
{
    public partial class ProductDialog : Window
    {
        public Product Product { get; private set; }
        private bool isEdit = false;

        public ProductDialog()
        {
            InitializeComponent();
            Product = new Product();
        }

        public ProductDialog(Product product) : this()
        {
            isEdit = true;
            Product = product;

            // Gán dữ liệu lên UI
            txtName.Text = product.Name;
            txtPrice.Text = product.Price.ToString();
            txtQuantity.Text = product.QuantityInStorage?.ToString();
            txtQR.Text = product.QrimageUrl;

            if (product.Status.Trim() == "ACTIVE")
                cbStatus.SelectedIndex = 0;
            else
                cbStatus.SelectedIndex = 1;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product.Name = txtName.Text.Trim();
                Product.Price = int.Parse(txtPrice.Text.Trim());
                Product.QuantityInStorage = string.IsNullOrEmpty(txtQuantity.Text)
                    ? 0 : int.Parse(txtQuantity.Text.Trim());
                Product.QrimageUrl = txtQR.Text.Trim();
                Product.Status = (cbStatus.SelectedItem as System.Windows.Controls.ComboBoxItem)
                    ?.Content.ToString();

                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập dữ liệu: " + ex.Message);
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
