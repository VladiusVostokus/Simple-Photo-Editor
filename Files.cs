using Microsoft.Win32;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace RGR5
{
    class Files
    {
        public Files()
        {

        }
        private Bitmap? OriginalImage;
        private Bitmap? EditedImage;
        private System.Windows.Controls.Image image;

        private void setImage(MainWindow mainWindow)
        {
            image = mainWindow.selectedImage;
        }

        public void Open(MainWindow mainWindow, BMPToSourse toSource)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Зображення *.bmp|*.bmp";
            openFileDialog.Title = "Виберіть зображення";

            if (openFileDialog.ShowDialog() == true)
            {
                string selectedFilePath = openFileDialog.FileName;
                try
                {
                    OriginalImage = new Bitmap(selectedFilePath);
                    EditedImage = new Bitmap(OriginalImage);
                    setImage(mainWindow);
                    image.Source = toSource(new Bitmap(OriginalImage));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка завантаження зображення: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        public void SaveAs()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Зображення *.bpm|*.bmp";

            if (saveFileDialog.ShowDialog() == true)
            {
                string saveFilePath = saveFileDialog.FileName;
                if (image != null)
                {
                    BitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create((BitmapSource)image.Source));

                    using (FileStream fs = new FileStream(saveFilePath, FileMode.Create))
                    {
                        encoder.Save(fs);
                    }
                }
                else 
                {
                    MessageBox.Show($"Помилка збереження зображення", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public void Save()
        {
            if(EditedImage != null) {

                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create((BitmapSource)image.Source));


                using FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\Photo.bmp", FileMode.Create);
                encoder.Save(fs);
                MessageBox.Show($"Зобреження збережено в {Environment.SpecialFolder.MyPictures}");
            }
            else
            {
                MessageBox.Show($"Спочатку відкрийте зображення", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        public Bitmap getOriginal()
        {
            return OriginalImage;
        }

        public Bitmap getEdited()
        {
            return EditedImage;
        }
    }
}
