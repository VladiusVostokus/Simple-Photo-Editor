using System.Windows;

namespace RGR5
{
    class Toolbar
    {
        public Toolbar(MainWindow mainWindow)
        {
            RGBpanel = mainWindow.RGBPanel;
            Contrastpanel = mainWindow.Contrast;
            Brightnesspanel = mainWindow.Brightness;
        }

        private readonly System.Windows.Controls.StackPanel RGBpanel;
        private readonly System.Windows.Controls.StackPanel Contrastpanel;
        private readonly System.Windows.Controls.StackPanel Brightnesspanel;

        public void ShowRGB()
        {
            RGBpanel.Visibility = Visibility.Visible;
            Contrastpanel.Visibility = Visibility.Hidden;
            Brightnesspanel.Visibility = Visibility.Hidden;
        }

        public void ShowBrightness() 
        {
            RGBpanel.Visibility = Visibility.Hidden;
            Contrastpanel.Visibility = Visibility.Hidden;
            Brightnesspanel.Visibility = Visibility.Visible;
        }

        public void ShowContrast() 
        {
            RGBpanel.Visibility = Visibility.Hidden;
            Contrastpanel.Visibility = Visibility.Visible;
            Brightnesspanel.Visibility = Visibility.Hidden;
        }
    }
}
