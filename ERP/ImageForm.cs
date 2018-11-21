using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace ERP
{
    public partial class ImageForm : Telerik.WinControls.UI.RadForm
    {
        public byte[] ImgBtyes { set; get; }

        public ImageForm()
        {
            
            InitializeComponent();
        }

        private void ImageForm_Load(object sender, EventArgs e)
        {
            try
            {
                MemoryStream ms = new MemoryStream();
                ms.Write(this.ImgBtyes, 0, this.ImgBtyes.Length);
                this.pictureBox1.Image = Image.FromStream(ms);
            }catch{}
        }
        
    }
}
