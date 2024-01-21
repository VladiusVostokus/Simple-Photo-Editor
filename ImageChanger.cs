using System.Drawing;
using System.Drawing.Imaging;

namespace RGR5
{
    class ImageChanger
    {
        public ImageChanger(MainWindow mainWindow)
        {
            image = mainWindow.selectedImage;
            textblocks = new Textblocks(mainWindow);
        }

        private System.Windows.Controls.Image image;
        private Bitmap edited;
        private Bitmap original;
        private float red, green, blue, contrast, brightness;
        private readonly Textblocks textblocks;

        
        public void setImages(Bitmap ed, Bitmap orig)
        {
            edited = ed;
            original = orig;
        }

        public void setColors(double r, double g, double b, double ct, double bt) 
        {
            red = (float)r; 
            green = (float)g; 
            blue = (float)b;
            contrast = (float)ct;
            brightness = (float)bt;
        }
        
        public void ChangeImage(BMPToSourse toSource)
        {

            if (edited != null && original != null)
            {              
                textblocks.updateTextBlocks(red, green, blue, contrast, brightness);    
                if (contrast < 1)
                {
                    contrast = (float)(contrast / 2) + 0.5f;

                }

                float[][] light =
                {
                    [contrast + red, 0, 0, 0, 0],
                    [0, contrast + green, 0, 0, 0],
                    [0, 0, contrast + blue, 0, 0],
                    [0, 0, 0, 1, 0],
                    [brightness, brightness, brightness, 0, 1]
                };

                Bitmap bmp = new Bitmap(original);
                ImageAttributes imgattr = new ImageAttributes();
                Rectangle rc = new Rectangle(0, 0, bmp.Width, bmp.Height);
                imgattr.SetColorMatrix(new ColorMatrix(light));

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.DrawImage(bmp, rc, 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, imgattr);
                }

                edited = bmp; 
                image.Source = toSource(edited);
            }
        }
    }
}
