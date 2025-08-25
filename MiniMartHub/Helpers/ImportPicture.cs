using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Media.Imaging;

namespace MiniMartHub.Helpers
{
    public  class ImportPicture
    {
        /// <summary>
        /// Mở hộp thoại chọn ảnh và trả về đường dẫn file ảnh (null nếu hủy).
        /// </summary>
        public static string? SelectImage()
        {
            var dlg = new OpenFileDialog
            {
                Title = "Chọn ảnh",
                Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"
            };

            return dlg.ShowDialog() == true ? dlg.FileName : null;
        }

        /// <summary>
        /// Load ảnh từ đường dẫn thành BitmapImage (dùng cho WPF Image.Source).
        /// </summary>
        public static BitmapImage? LoadImage(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
                return null;

            try
            {
                var img = new BitmapImage();
                img.BeginInit();
                img.CacheOption = BitmapCacheOption.OnLoad; // tránh bị lock file
                img.UriSource = new Uri(path, UriKind.Absolute);
                img.EndInit();
                img.Freeze(); // cho phép dùng ở nhiều thread
                return img;
            }
            catch
            {
                return null;
            }
        }
    }
}
