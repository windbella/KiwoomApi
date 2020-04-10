using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using KiwoomController;
using AxKHOpenAPILib;

namespace KiwoomCore
{
    public partial class Core : Form
    {
        private KiwoomController.KWController contoroller = new KiwoomController.KWController();

        public Core()
        {
            InitializeComponent();
            this.Controls.Add(contoroller);
            contoroller.Dock = DockStyle.Fill;
        }

        public int CommConnect()
        {
            return contoroller.Api.CommConnect();
        }

    }
}
