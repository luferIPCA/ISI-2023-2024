/*
 * lufer
 * ISI
 * CLients ASP.NET Core Web API 3.1
 * Required: System.Runtime.CompilerServices.Unsafe
 * JSON to Datagrid
 * DataTable dataTable = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
 * dataGridView.DataSource = dataTable;
 * */
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;                     //JsonSerializer  
using System.Windows.Forms;


namespace UsaREST1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Com Get, sem parâmetros (WebClient)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //https://localhost:44335/Valores/Get
            string url = "https://localhost:44335/Valores/Get";
            WebClient client = new WebClient();
            string json = client.DownloadString(url);

        }

        /// <summary>
        /// Com GET e Parâmetros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button2_Click(object sender, EventArgs e)
        {
            int val = int.Parse(textBox1.Text);
            HttpClient client = new HttpClient();
            string url = "https://localhost:44335/Valores/Add/" + val.ToString();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(url);  //chamada assincrona
            
            if (response.IsSuccessStatusCode)
            {
                //Assincrono
                string result = response.Content.ReadAsStringAsync().Result;
                //processar response
            }

        }

        /// <summary>
        /// Com POST
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button3_Click(object sender, EventArgs e)
        {
            //https://localhost:44335/Calc/addvalores
            HttpClient client = new HttpClient();
            string url = "https://localhost:44335/Calc/addvalores/";
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            //Parâmetro em JSON
            int model = int.Parse(textBox1.Text);

            Valor v = new Valor();
            v.V = model;
            string jsonString = JsonSerializer.Serialize<Valor>(v);

            // Converte objeto para formato Json

            var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");   //Header

            // Espera o resultado
            HttpResponseMessage response = await client.PostAsync(url, stringContent);
            string result = response.Content.ReadAsStringAsync().Result;
           

            // Verifica se o retorno é 200
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Done!");
            }

        }

        public class Valor
        {
            public int V { get; set; }
        }
    }
}
