using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculadoraWindows.WS2;

namespace CalculadoraWindows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WSExterno.CalcSoapClient ws = new WSExterno.CalcSoapClient();

            textBox3.Text = ws.Soma(int.Parse(textBox1.Text), int.Parse(textBox2.Text)).ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            WS2.MaisFuncsSoapClient ws = new WS2.MaisFuncsSoapClient();

           // textBox3.Text = ws.Sub(int.Parse(textBox1.Text), int.Parse(textBox2.Text)).ToString();

            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);
            ws.SubCompleted += Ws_SubCompleted;
            ws.SubAsync(x,y);
            MessageBox.Show("Passou");
        }

        private void Ws_SubCompleted(object sender, WS2.SubCompletedEventArgs e)
        {
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
            MessageBox.Show("Após Completed: "+ e.Result.ToString());
        }
    }
}
