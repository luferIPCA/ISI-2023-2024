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
        //JWT gerado
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

    
        #region WEPAPI-COM JWT
        //https://localhost:44348/

        /// <summary>
        /// Get Token
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:44375/api/Security/login";
            // Compose the query URL...testar TextBox

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Envio da requisição de autenticação + envio de token
            HttpResponseMessage respToken = 
                client.PostAsync(url, 
                new StringContent(JsonSerializer.Serialize(new { username = "lufer", password = "Benfica2023" }), Encoding.UTF8, "application/json")).Result;
            //obtém o json token gerado
            string conteudo = respToken.Content.ReadAsStringAsync().Result;

            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(AuthenticateResponse));
            var ms = new MemoryStream(Encoding.Unicode.GetBytes(conteudo));
            AuthenticateResponse t = (AuthenticateResponse)jsonSerializer.ReadObject(ms);

            token = t.token;
            label2.Text = token;
            MessageBox.Show(token, "Token");

        }
      
        /// <summary>
        /// Get All Localhost
        /// Protected by JWT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button9_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:44375/api/User/all";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Associar o token ao header do objeto do tipo HttpClient
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            
            // Espera o resultado
            HttpResponseMessage response = await client.GetAsync(url);

            // Verifica se o retorno é 200
            if (response.IsSuccessStatusCode)
            {
                string s = await response.Content.ReadAsStringAsync();
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<User>));
                var ms = new MemoryStream(Encoding.Unicode.GetBytes(s));
                List<User> h = (List<User>)jsonSerializer.ReadObject(ms);
                dataGridView1.DataSource = h;
                //MessageBox.Show(s);
            }
            else //if (response.StatusCode != HttpStatusCode.OK)
            {
                string message = String.Format("GET falhou. Recebido HTTP {0}", response.StatusCode);
                MessageBox.Show(message);
                //throw new ApplicationException(message);
            }
        }

        /// <summary>
        /// AddNew Indicador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button11_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:44375/api/User/addUser";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            //Definir tipo de resultado: JSON
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // Associar o token ao header do objeto do tipo HttpClient
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            User ind = new User();

            ind.name = "NOVO";
            ind.id = 1;
            ind.role = "GUEST";

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


        #endregion

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
