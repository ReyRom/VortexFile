﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VortexFileClient.Extensions
{
    public partial class MessageBox : Form
    {
        MessageBoxButtons MessageBoxButtons 
        {
            set
            {
                switch (value)
                {
                    case MessageBoxButtons.OK:
                        OkButton.Visible = true;
                        break;
                    case MessageBoxButtons.OKCancel:
                        OkButton.Visible = CancelButton.Visible = true;
                        break;
                    case MessageBoxButtons.AbortRetryIgnore:
                        break;
                    case MessageBoxButtons.YesNoCancel:
                        YesButton.Visible = NoButton.Visible = CancelButton.Visible = true;
                        break;
                    case MessageBoxButtons.YesNo:
                        YesButton.Visible = NoButton.Visible = true;
                        break;
                    case MessageBoxButtons.RetryCancel:
                        break;
                    case MessageBoxButtons.CancelTryContinue:
                        break;
                }
            }
        }

        MessageBoxIcon MessageBoxIcon
        {
            set
            {
                switch (value)
                {
                    case MessageBoxIcon.None:
                        IconPictureBox.Width = 0;
                        break;
                    case MessageBoxIcon.Question:
                        IconPictureBox.Image = Properties.Resources.Question;
                        break;
                    case MessageBoxIcon.Error:
                        IconPictureBox.Image = Properties.Resources.Error;
                        break;
                    case MessageBoxIcon.Warning:
                        IconPictureBox.Image = Properties.Resources.Warning;
                        break;
                    case MessageBoxIcon.Information:
                        IconPictureBox.Image = Properties.Resources.Info;
                        break;
                }
            }
        }

        public static DialogResult Show(string text, string caption = "", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.None)
        {
            using (var dlg = new MessageBox())
            {
                dlg.HeaderLabel.Text = caption;
                dlg.TextLabel.Text = text;
                dlg.MessageBoxButtons = buttons;
                dlg.MessageBoxIcon = icon;
                return dlg.ShowDialog();
            }
        }
        public static DialogResult Show(string text, out string value, string caption = "", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.None)
        {
            using (var dlg = new MessageBox())
            {
                dlg.HeaderLabel.Text = caption;
                dlg.TextLabel.Text = text;
                dlg.MessageBoxButtons = buttons;
                dlg.MessageBoxIcon = icon;
                dlg.InputTextBox.Visible = true;
                var result = dlg.ShowDialog();
                value = dlg.InputTextBox.Text;
                return result;
            }
        }
        private Point mPoint;
        public MessageBox()
        {
            InitializeComponent();
        }
        private void HeaderLabel_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void HeaderLabel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }
    }
}