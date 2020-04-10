using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KiwoomController
{
    public partial class KWController: UserControl
    {
        public KWController()
        {
            InitializeComponent();
        }

        public AxKHOpenAPILib.AxKHOpenAPI Api
        {
            get => axKHOpenAPI;
        }
    }
}
