/**
 * lufer
 * Cliente de Serviços SOAP
 * 
 * https://graphical.weather.gov/xml/SOAP_server/ndfdXMLserver.php?wsdl
 * */
using System;
using System.Windows.Forms;

using ClienteWS;

namespace ClienteWS
{
    public partial class Form1 : Form
    {
        WSCalc.CalcSoapClient ws;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ws = new WSCalc.CalcSoapClient();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = ws.Soma(int.Parse(textBox1.Text), int.Parse(textBox2.Text)).ToString();  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //WS2.TempConvertSoapClient ws2 = new TempConvertSoapClient();
            //textBox6.Text = ws2.FahrenheitToCelsius(textBox5.Text);

            //CountryWS.CountryInfoServiceSoapTypeClient ws3 = new CountryWS.CountryInfoServiceSoapTypeClient(new )
            //WS3.TextCasingSoapTypeClient ws4 = new WS3.TextCasingSoapTypeClient();


        }
    }
}
