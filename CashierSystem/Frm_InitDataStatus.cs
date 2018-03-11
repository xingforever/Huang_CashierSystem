using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CashierSystem
{
    public partial class Frm_InitDataProgressBar : Form
    {
       
        public Frm_InitDataProgressBar()
        {
            InitializeComponent();
           
        }

        private void Frm_InitDataProgressBar_Load(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        ///加载动态GIF图
        /// </summary>
        public void GifStart()
        {
            try
            {
                Bitmap animatedGif = new Bitmap(@"waitting.gif");
                Graphics g = this.panel1.CreateGraphics();
                // A Gif image's frame delays are contained in a byte array  
                // in the image's PropertyTagFrameDelay Property Item's  
                // value property.  
                // Retrieve the byte array...  
                int PropertyTagFrameDelay = 0x5100;
                PropertyItem propItem = animatedGif.GetPropertyItem(PropertyTagFrameDelay);
                byte[] bytes = propItem.Value;
                // Get the frame count for the Gif...  
                FrameDimension frameDimension = new FrameDimension(animatedGif.FrameDimensionsList[0]);
                int frameCount = animatedGif.GetFrameCount(FrameDimension.Time);
                // Create an array of integers to contain the delays,  
                // in hundredths of a second, between each frame in the Gif image.  
                int[] delays = new int[frameCount + 1];
                int i = 0;
                for (i = 0; i <= frameCount - 1; i++)
                {
                    delays[i] = BitConverter.ToInt32(bytes, i * 4);
                }

                // Play the Gif one time...  
                while (true)
                {
                    for (i = 0; i <= animatedGif.GetFrameCount(frameDimension) - 1; i++)
                    {
                        animatedGif.SelectActiveFrame(frameDimension, i);
                        g.DrawImage(animatedGif, new Point(150, 0));
                        Application.DoEvents();
                        Thread.Sleep(delays[i] * 10);
                    }
                }
            }
            catch 
            {

                ;
            }
           
        }

        private void Frm_InitDataProgressBar_Shown(object sender, EventArgs e)
        {
            GifStart();
        }
    }
}
