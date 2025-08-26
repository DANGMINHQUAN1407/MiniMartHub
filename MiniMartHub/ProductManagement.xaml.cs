using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;   // <-- thêm cái này cho UserControl
using BLL.Service;
using DAL.Entities;

namespace MiniMartHub
{
    public partial class ProductManagement : UserControl
    {
        private readonly ProductService _service;
        private ObservableCollection<Product> _products;

        public ProductManagement()
        {
            InitializeComponent();
            _service = new ProductService();
            LoadProducts();
        }
        private void UpdateProductStatus(Product product)
        {
            if (product.QuantityInStorage <= 0)
            {
                product.Status = "INACTIVE";
            }
            else
            {
                product.Status = "ACTIVE";
            }
        }

        private void LoadProducts()
        {
            try
            {
                var products = _service.GetAllProducts();
                _products = new ObservableCollection<Product>(products);
                dgProducts.ItemsSource = _products;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải sản phẩm: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            ProductDialog dialog = new ProductDialog();
            if (dialog.ShowDialog() == true)
            {
                try
                {
                    // cập nhật status theo quantity
                    UpdateProductStatus(dialog.Product);

                    _service.AddProduct(dialog.Product);
                    _products.Add(dialog.Product);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể thêm sản phẩm: " + ex.Message);
                }
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducts.SelectedItem is Product selected)
            {
                ProductDialog dialog = new ProductDialog(selected);
                if (dialog.ShowDialog() == true)
                {
                    try
                    {
                        // cập nhật status theo quantity
                        UpdateProductStatus(dialog.Product);

                        _service.UpdateProduct(dialog.Product);

                        int index = _products.IndexOf(selected);
                        if (index >= 0)
                        {
                            _products[index] = dialog.Product;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể cập nhật sản phẩm: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để sửa.");
            }
        }


        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgProducts.SelectedItem is Product selected)
            {
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa SP: {selected.Name}?",
                    "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        _service.DeleteProduct(selected.Id);
                        _products.Remove(selected);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể xóa sản phẩm: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa.");
            }
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadProducts();
        }
    }
}
