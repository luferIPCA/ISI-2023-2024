/**
 * Cliente para Serializar dados com WS
 * lufer & Oscar
 * 2023
 * */
using System;
using System.Windows.Forms;

using ClienteSerializa.WS;

namespace ClienteSerializa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WS.ServiceSoapClient ws = new ServiceSoapClient();

            WS.ArrayOfPessoa aux = ws.GetAllPessoas();

            MessageBox.Show(aux[0].NomePessoa);

            WS.MyPessoas aux2 = ws.GetAllPessoasII();

           WS.MyPessoasII aux3 = ws.GetAllPessoasIII();

        }
    }
}
