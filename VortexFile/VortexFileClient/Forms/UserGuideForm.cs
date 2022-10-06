using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VortexFileClient.Extensions;

namespace VortexFileClient.Forms
{
    public partial class UserGuideForm : Form, IStackableForm
    {
        public UserGuideForm()
        {
            InitializeComponent();
        }

        public event EventHandler<LoadFormEventArgs> LoadForm;
        public event EventHandler GoBack;
    }
}
