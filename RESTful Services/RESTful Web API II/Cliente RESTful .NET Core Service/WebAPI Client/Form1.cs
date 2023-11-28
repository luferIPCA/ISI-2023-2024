/*
 * lufer
 * WepApi RESTful Cient
 * See https://blog.stephencleary.com/2012/07/dont-block-on-async-code.html
 * */
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;                        //Encoding
using System.Text.Json;                   //Referir "System.Text.Json" em References
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WebAPI_Client
{
    public partial class Form1 : Form
    {
        
        private static string token;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region LOCAL-SERVICES

        #region WEPAPI-SEM JWT
        //https://localhost:44355/

        private const string Localurl = "https://localhost:44355/api/servicosPandemic/[ACTION]/";

        /// <summary>
        /// POST
        /// Registar mortes
        /// url:https://localhost:44355/api/servicosPandemic/[ACTION]/
        ///     https://localhost:44355/api/servicosPandemic/deaths?v=13
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button1_Click(object sender, EventArgs e)
        {
            // Compose the query URL.
            if (textBox3.Text.Length == 0)
            {
                MessageBox.Show("Indique quantas Mortes ocorreram!!!!"); return;
            }

            string url = Localurl.Replace("[ACTION]", "deaths");
            //url = url.Replace("[V]", textBox1.Text);               //Caso existam mais parâmetros em operações GET

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            //Definir tipo de resultado: JSON
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Parâmetro em JSON
            //Converte objeto para formato Json
            int model = int.Parse(textBox3.Text);
            string jsonString = JsonSerializer.Serialize(model);
            var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

            // Espera o resultado
            HttpResponseMessage response = await client.PostAsync(url, stringContent);  //Post

            // Verifica se o retorno é 200
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Done!");
            }
        }
    
        
        /// <summary>
        /// POST
        /// Registar novo registo
        /// url: https://localhost:44355/api/History/newIndicadorSync
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button3_Click(object sender, EventArgs e)
        {

            string url = "https://localhost:44355/api/History/[ACTION]";
            // Compose the query URL...testar TextBox
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("Defina valores"); return;
            }

            url = url.Replace("[ACTION]", "newIndicador");
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            //Definir tipo de resultado: JSON
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Parâmetro em JSON

            //var payload = "{\"CustomerId\": 5,\"CustomerName\": \"Pepsi\"}";
            Indicador ind = new Indicador();
            //ind.date = DateTime.Today;
            //ind.date = DateTime.Today.ToString();
            ind.infetados = int.Parse(textBox1.Text);
            ind.mortes = int.Parse(textBox3.Text);
            ind.recuperados = int.Parse(textBox2.Text);

            // Converte objeto para formato Json
            string jsonString = JsonSerializer.Serialize(ind);
            var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");   //Header

            // Espera o resultado
            HttpResponseMessage response = await client.PostAsync(url, stringContent);  //Post

            string result = response.Content.ReadAsStringAsync().Result;

            // Verifica se o retorno é 200
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Done!");
            }

        }
        /// <summary>
        /// LocalHost POST registo corrente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button10_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:44355/api/History/saveCurrent";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            //Definir tipo de resultado: JSON
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var stringContent = new StringContent("", Encoding.UTF8, "application/json");   //Header

            // Espera o resultado
            HttpResponseMessage response = await client.PostAsync(url, stringContent);  //Post

            string result = response.Content.ReadAsStringAsync().Result;

            // Verifica se o retorno é 200
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Done!");
            }
        }

        #endregion


        #endregion


        #region CLOUD-SERVICES

        /// <summary>
        /// Cloud Service
        /// Não está disponível!!!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button6_Click(object sender, EventArgs e)
        {
            //string url = "https://ipcawebapi.azurewebsites.net/";

            //string json = await ShowHistoryCloud(url);                                          
            //                                                                                                                                          //var settings = new DataContractJsonSerializerSettings() { DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:00") };                                                                                 //DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Indicador>),settings);
            //DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Indicador>));
            //var ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
            //List<Indicador> h = (List<Indicador>)jsonSerializer.ReadObject(ms);
            //dataGridView1.DataSource = h;
            
        }

        /// <summary>
        /// Cloud Save Current (POST)
        /// Não está disponivel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button5_Click(object sender, EventArgs e)
        {

            //string url = "https://benfica.azurewebsites.net/api/History/saveCurrent";

            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(url);
            ////Definir tipo de resultado: JSON
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //var stringContent = new StringContent("", Encoding.UTF8, "application/json");   //Header

            //// Espera o resultado
            //HttpResponseMessage response = await client.PostAsync(url, stringContent);  //Post

            //string result = response.Content.ReadAsStringAsync().Result;

            //// Verifica se o retorno é 200
            //if (response.IsSuccessStatusCode)
            //{
            //    MessageBox.Show("Done!");
            //}
        }

        /// <summary>
        /// Novo Indicador na CLoud
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button7_Click(object sender, EventArgs e)
        {
            //string url = "https://ipcawebapi.azurewebsites.net/newIndicador";
            //// Compose the query URL...testar TextBox
            //if (textBox1.Text.Length == 0)
            //{
            //    MessageBox.Show("Defina valores"); return;
            //}

            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(url);
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            ////Parâmetro em JSON
            //Indicador ind = new Indicador();
            ////ind.date = DateTime.Today;
            ////ind.date = DateTime.Today.ToString();
            //ind.infetados = int.Parse(textBox1.Text);
            //ind.mortes = int.Parse(textBox2.Text);
            //ind.recuperados = int.Parse(textBox3.Text);

            //// Converte objeto para formato Json
            //string jsonString = JsonSerializer.Serialize(ind);
            //var stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");   //Header

            //// Espera o resultado
            //HttpResponseMessage response = await client.PostAsync(url, stringContent);  //Post

            //string result = response.Content.ReadAsStringAsync().Result;

            //// Verifica se o retorno é 200
            //if (response.IsSuccessStatusCode)
            //{
            //    MessageBox.Show("Done!");
            //}

        }

        /// <summary>
        /// GET
        /// All
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button4_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:44355/";
            string json = await ShowHistory(url);
            //DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Indicador>),settings);
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Indicador>));
            var ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
            List<Indicador> h = (List<Indicador>)jsonSerializer.ReadObject(ms);
            dataGridView2.DataSource = h;
        }

        #endregion

        #region AUX

        /// <summary>
        /// GET assincrono
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<string> MyGetAsync(string uri)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uri);

            //will throw an exception if not successful
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            return content;
        }

        /// <summary>
        /// GET all
        /// </summary>
        public async Task<string> ShowHistory(string url)
        {
            //h1 - WebClient
            //WebClient client = new WebClient();
            //string json = client.DownloadString(url);

            //h2 - HttpClient
            string json = await MyGetAsync(url);
            return json;

        }

        /// <summary>
        /// GET Cloud
        /// </summary>
        public async Task<string> ShowHistoryCloud(string url)
        {
            string _url = url;

            //h1 - WebClient
            //WebClient client = new WebClient();
            //string json = client.DownloadString(url);

            //h2 - HttpClient
            string json = await MyGetAsync(url);
            return json;

        }



        #endregion

       

      
    }



    #region MODELS

    [DataContractAttribute]
    public class AuthenticateResponse
    {
        [DataMemberAttribute]
        public string name { get; set; }
        [DataMemberAttribute]
        public string token { get; set; }


        public AuthenticateResponse(string user, string token)
        {
            name = user;
            this.token = token;
        }
    }

    // NewtonSoft:
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Indicador
    {
        public int recuperados { get; set; }
        public int mortes { get; set; }
        public int infetados { get; set; }
       
        public string date { get; set; }
    }

  
    public class History
    {
        public List<Indicador> indicadores { get; set; }
        //[JsonIgnore]
        public int TotIndicadores { get; set; }      //Property omitida na serialização
    }

    [DataContractAttribute]
    public class User
    {
        [DataMemberAttribute]
        public string name { get; set; }

        [DataMemberAttribute]
        public int id { get; set; }

        [DataMemberAttribute]
        public string role { get; set; }

        [DataMemberAttribute]
        public object token { get; set; }
    }

    #endregion
}
