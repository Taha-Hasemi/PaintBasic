using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintCizimUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool ciz = false;
        int baslax, baslay;
        int kalinlik = 3;
        ColorDialog colorDialog = new ColorDialog();

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Pen pen = new Pen(colorDialog.Color, kalinlik);
            Point point1 = new Point(baslax, baslay);
            Point point2 = new Point(e.X, e.Y);
            Graphics g = this.CreateGraphics();
            if (ciz == true)
            {
                g.DrawLine(pen, point1, point2);
                baslax = e.X;
                baslay = e.Y;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            ciz = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
        }

        private void comboBoxEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                try
                {
                    kalinlik = Convert.ToInt32(comboBoxEdit1.Text);
                }
                catch (Exception aciklama)
                {
                    comboBoxEdit1.Text = "";
                    MessageBox.Show(aciklama.Message, "Sorun");
                }
            }
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                kalinlik = Convert.ToInt32(comboBoxEdit1.Text);
            }
            catch (Exception aciklama)
            {
                comboBoxEdit1.Text = "";
                MessageBox.Show(aciklama.Message, "Sorun");
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ciz = true;
            baslax = e.X;
            baslay = e.Y;
        }
    }
}
