using ERP.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging;
using AForge.Imaging.Filters;
using System.Drawing.Imaging;
namespace ERP
{
    public partial class CameraForm : Form
    {

        private FilterInfoCollection videoDevices;
        public CameraForm()
        {
            InitializeComponent();
        }

        private VideoCaptureDevice videoDevice;
        private VideoCapabilities[] videoCapabilities;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // 枚举所有视频输入设备
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                    throw new ApplicationException();

                foreach (FilterInfo device in videoDevices)
                {
                    this.devicesCombo.Items.Add(device.Name);
                }

                devicesCombo.SelectedIndex = 0;
                EnableConnectionControls(true);
                connectButton_Click(null, null);
            }
            catch (ApplicationException)
            {
                MessageBox.Show("没有摄像头!");
                videoDevices = null;
            }
        }
        private void EnumeratedSupportedFrameSizes(VideoCaptureDevice videoDevice)
        {
            this.Cursor = Cursors.WaitCursor;

            videoResolutionsCombo.Items.Clear();

            try
            {
                videoCapabilities = videoDevice.VideoCapabilities;

                foreach (VideoCapabilities capabilty in videoCapabilities)
                {
                    videoResolutionsCombo.Items.Add(string.Format("{0} x {1}",
                        capabilty.FrameSize.Width, capabilty.FrameSize.Height));
                }

                if (videoCapabilities.Length == 0)
                {
                    videoResolutionsCombo.Items.Add("Not supported");
                }

                videoResolutionsCombo.SelectedIndex = 0;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSourcePlayer1.VideoSource != null)
            {
                videoSourcePlayer1.SignalToStop();
                videoSourcePlayer1.WaitForStop();
                videoSourcePlayer1.VideoSource = null;
            }
        }

        public int salesId { get; set; }
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
        private void searchBtn_Click(object sender, EventArgs e)
        {
            string file = AppDomain.CurrentDomain.BaseDirectory + "\\" + "清单.jpg";
            Bitmap bmpNew = null;
            Graphics g = null;
            Bitmap bitmap = null;
            try
            {

                IntPtr hbitmap = videoSourcePlayer1.GetCurrentVideoFrame().GetHbitmap();
                bitmap = System.Drawing.Image.FromHbitmap(hbitmap);
                
                bmpNew = new Bitmap(bitmap.Width, bitmap.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                g = Graphics.FromImage(bmpNew);
                g.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
                g.Dispose();
                

                bitmap.Dispose();
                //销毁对象 否则会内存溢出
                DeleteObject(hbitmap);
            }
            catch
            {
                if (g != null)
                    g.Dispose();
                if (bitmap != null)
                    bitmap.Dispose();
                return;
            }
            bmpNew.Save(file, ImageFormat.Jpeg);
           

            if (salesId != 0 && File.Exists(file))
            {
                
                Stream stream = new FileStream(file, FileMode.Open);
                byte[] img = new byte[stream.Length];
                stream.Read(img, 0, (int)stream.Length);
                SalesDal.upLoadFile(img, salesId);
                MessageBox.Show("上传成功！");
                stream.Close();
                stream.Dispose();

                this.Close();
                File.Delete(file);
            }
        }
        private void connectButton_Click(object sender, EventArgs e)
        {
            if (videoDevice != null)
            {
                if ((videoCapabilities != null) && (videoCapabilities.Length != 0))
                {
                    videoDevice.VideoResolution = videoCapabilities[videoResolutionsCombo.SelectedIndex];
                }

                videoSourcePlayer1.VideoSource = videoDevice;
                videoSourcePlayer1.Start();
                EnableConnectionControls(false);
            }
        }
        private void devicesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (videoDevices.Count != 0)
            {
                videoDevice = new VideoCaptureDevice(videoDevices[devicesCombo.SelectedIndex].MonikerString);
                EnumeratedSupportedFrameSizes(videoDevice);
            }
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        // Disconnect from video device
        private void Disconnect()
        {
            if (videoSourcePlayer1.VideoSource != null)
            {
                // stop video device
                videoSourcePlayer1.SignalToStop();
                videoSourcePlayer1.WaitForStop();
                videoSourcePlayer1.VideoSource = null;
 
                EnableConnectionControls(true);
            }
        }

        private void EnableConnectionControls(bool enable)
        {
            devicesCombo.Enabled = enable;
            videoResolutionsCombo.Enabled = enable;
            connectButton.Enabled = enable;
            disconnectButton.Enabled = !enable;
        }
    }
}
