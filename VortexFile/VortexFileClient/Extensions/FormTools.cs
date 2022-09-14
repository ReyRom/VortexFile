using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VortexFileClient.Extensions
{
    public static class FormTools
    {
        public static void FormToPanel(Form form, Panel panel) 
        {
            panel.Controls.Clear();
            form.TopLevel = false;
            panel.Controls.Add(form);
            panel.Dock = DockStyle.Fill;
            panel.Size = new Size(form.Size.Width, form.Size.Height);
            form.Show();
        }
    }
}
