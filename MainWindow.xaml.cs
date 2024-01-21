using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RGR5
{
    delegate BitmapImage BMPToSourse(Bitmap src);
    public partial class MainWindow : Window
    {
        private readonly Files files = new Files();
        private readonly Toolbar toolbar;
        private readonly Viewer viewer;
        private readonly ImageChanger imageChanger;

        public MainWindow()
        {
            InitializeComponent();

            TransformGroup transformGroup = new();
            ScaleTransform scaleTransform = new();
            transformGroup.Children.Add(scaleTransform);
            TranslateTransform translateTransform = new TranslateTransform();
            transformGroup.Children.Add(translateTransform);
            selectedImage.RenderTransform = transformGroup;

            Contrast.Visibility = Visibility.Hidden;
            Brightness.Visibility = Visibility.Hidden;
            RGBPanel.Visibility = Visibility.Hidden;

            toolbar = new Toolbar(this);
            viewer = new Viewer(this);
            imageChanger = new ImageChanger(this);
        }
        private void OpenFileClick(object sender, RoutedEventArgs e)
        {
            files.Open(this, BitmapToSource);
        }

        private static BitmapImage BitmapToSource(Bitmap src)
        {
            MemoryStream ms = new MemoryStream();
            src.Save(ms, ImageFormat.Bmp);

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            return image;
        }

        private void SaveFileClick(object sender, RoutedEventArgs e)
        {
            files.SaveAs();
        }
        private void SaveFile(object sender, RoutedEventArgs e)
        {
            files.Save();
        }

        private void MouseWheell(object sender, MouseWheelEventArgs e)
        {
            viewer.Zoom(e);
        }

        private void ChageImage(object sender, RoutedPropertyChangedEventArgs<double> e)
        { 
            if (files.getEdited() != null && files.getOriginal() != null)
            {
                imageChanger.setImages(files.getEdited(), files.getOriginal());
                imageChanger.setColors(
                    RedSlider.Value,
                    GreenSlider.Value,
                    BlueSlider.Value,
                    ContrastSlider.Value,
                    BrightnessSlider.Value
                    );

                imageChanger.ChangeImage(BitmapToSource);
            }
        }

        private void ShowRGB(object sender, RoutedEventArgs e)
        {
            if (files.getOriginal() == null)
            {
                MessageBox.Show($"Спочатку відкрийте зображення", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            toolbar.ShowRGB();
            Title = "Редагування RGB";
        }

        private void ShowContrast(object sender, RoutedEventArgs e)
        {
            if (files.getOriginal() == null)
            {
                MessageBox.Show($"Спочатку відкрийте зображення", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            toolbar.ShowContrast();
            Title = "Редагування контрасту";
        }

        private void ShowBrightness(object sender, RoutedEventArgs e)
        {
            if (files.getOriginal() == null)
            {
                MessageBox.Show($"Спочатку відкрийте зображення", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            toolbar.ShowBrightness();
            Title = "Редагування Світлоти";
        }

        private void ClearContrast(object sender, RoutedEventArgs e)
        {
            ContrastSlider.Value = 1;
        }

        private void ClearBrightness(object sender, RoutedEventArgs e)
        {
            BrightnessSlider.Value = 0;
        }

        private void ClearRGB(object sender, RoutedEventArgs e)
        {
            RedSlider.Value = 0;
            GreenSlider.Value = 0;
            BlueSlider.Value = 0;
        }
    }
}