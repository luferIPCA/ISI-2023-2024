/**
 * lufer
 * Cliente para usar Serviços Web SOAP
 * 
 * */
using System;
using System.Windows.Forms;

//Serviços externos!
using CalculadoraWindows.WS1;
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
            WS1.CalcSoapClient ws = new WS1.CalcSoapClient();

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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WS4.ServiceSoapClient ws = new WS4.ServiceSoapClient();
        }
    }
}
