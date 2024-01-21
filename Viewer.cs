using System.Windows.Input;
using System.Windows.Media;

namespace RGR5
{
    class Viewer
    {
        public Viewer(MainWindow mainWindow)
        {
            image = mainWindow.selectedImage;
        }

        private System.Windows.Controls.Image image;
        private double controller = 0;

        public void Zoom(MouseWheelEventArgs e)
        {

            var transform = (ScaleTransform)((TransformGroup)image.RenderTransform).Children.First(c => c is ScaleTransform);
            double zoom = e.Delta > 0 ? 0.2 : -0.2;
            controller += zoom;
            if (controller < -0.8)
            {
                controller = -0.8;
                return;
            }  
            transform.ScaleX += zoom;
            transform.ScaleY += zoom;
        }
    }
}
