namespace RGR5
{
    class Textblocks
    {
        public Textblocks(MainWindow mainWindow)
        {
            Redblock = mainWindow.Redtxt;
            Greenblock = mainWindow.Greentxt;
            Blueblock = mainWindow.Bluetxt;
            Contrastblock = mainWindow.Contrasttxt;
            Brightnessblosk = mainWindow.Brightnesstxt;
        }

        private System.Windows.Controls.TextBlock Redblock;
        private System.Windows.Controls.TextBlock Greenblock;
        private System.Windows.Controls.TextBlock Blueblock;
        private System.Windows.Controls.TextBlock Contrastblock;
        private System.Windows.Controls.TextBlock Brightnessblosk;

        public void updateTextBlocks(double r, double g, double b, double ct, double bt)
        {
            Redblock.Text = ((int)(r * 100)).ToString();
            Greenblock.Text = ((int)(g * 100)).ToString();
            Blueblock.Text = ((int)(b * 100)).ToString();
            Contrastblock.Text = ((float)(ct * 10) - 10).ToString("F2");
            Brightnessblosk.Text = ((float)(bt * 10)).ToString("F2");
            
        }
    }
}
