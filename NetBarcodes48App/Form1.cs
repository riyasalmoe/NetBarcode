using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetBarcodeNetBarcodes48;

namespace NetBarcodes48App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var barcode = new Barcode("123456789", NetBarcodeNetBarcodes48.Type.Code128B);
            pictureBox1.Image = barcode.GetImage();

        }
    }
}
