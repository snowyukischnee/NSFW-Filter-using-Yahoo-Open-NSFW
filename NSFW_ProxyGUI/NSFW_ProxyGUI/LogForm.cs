using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSFW_ProxyGUI {
    public partial class LogForm : Form {
        public LogForm(StringBuilder s) {
            InitializeComponent();
            LogTxt.Text = s.ToString();
        }
    }
}
