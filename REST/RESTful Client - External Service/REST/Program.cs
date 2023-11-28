/*
 * RESTful Client implementado em C#
 * 
 * RECEITA: Para aceder a recursos Web:
 * 1 - URI (URL+Parametros) - HttpUtility
 * 2 - HttpWebRequest
 * 3 - HttpWebResponse
 * 
 * Mais:
 *  Parsing XML     - https://msdn.microsoft.com/en-us/library/hh534080.aspx
 *  Parsing JSON    - https://msdn.microsoft.com/en-us/library/hh674188.aspx
 *  
 *  JSON serialization in .NET
 *  --------------------------
 *  System.Runtime.Serialization
 *  System.ServiceModel.Web
 *  
 *  Ver http://json2csharp.com/
 *
 *  Exemplos REST Services:
 *    
 *  Explorar
 *      http://samples.openweathermap.org/data/2.5/forecast?q=M%C3%BCnchen,DE&appid=b1b15e88fa797225412429c1c50c122a1
 *      http://api.openweathermap.org/data/2.5/weather?q=CITYNAME&mode=MODE&appid=API
 *      APIKEY: b4e56d454f9ddc1a5b66102f99f28fa2
 * by lufer
 * LESI-EST-IPCA
 * */


using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;                            //NameSpace referência
using System.Runtime.Serialization;         //DataContract
using System.Runtime.Serialization.Json;
//Adicionar COM System.Runtime.Serialization em "Project Properties"
using System.Text;
using System.Web;                           //NameSpace referência - HttpUtility
using System.Xml.Linq;
using System.Xml.Serialization;

namespace RESTWS
{
    class Program
    {
        static void Main(string[] args)
        {
            #region VAR

            //Suportar Pedido e URI
            HttpWebRequest request;
            StringBuilder uri;
            string url;
            string apiKey = "b4e56d454f9ddc1a5b66102f99f28fa2"; //2023
            string mode = "json";

            #endregion

            #region WEATHER
            try
            {
                #region Weather
                //Weather URL
                url = "http://api.openweathermap.org/data/2.5/weather?q=[CITY]&mode=[MODE]&appid=[APIKEY]";

                #region ConstroiURI

                uri = new StringBuilder();
                uri.Append(url);
                uri.Replace("[CITY]", HttpUtility.UrlEncode("Viana do Castelo"));
                uri.Replace("[APIKEY]", apiKey);
                uri.Replace("[MODE]", mode);

                //String.Format();
                #endregion


                #region PreparaPedido

                //Prepara e envia pedido
                //
                request = WebRequest.Create(uri.ToString()) as HttpWebRequest;

                // Caso necessite de autenticação no pedido 
                //request.Credentials = new NetworkCredential("username", "password"); 

                // Mais flags
                // request.KeepAlive = false;
                // request.Timeout = 10 * 10000;

                #endregion

                #endregion

                #region EnviaPedidoAnalisaResposta

                //analisa resposta
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)     //via GET
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        string message = String.Format("GET falhou. Recebido HTTP {0}", response.StatusCode);
                        throw new ApplicationException(message);
                    }

                    //Se for JSON

                    //NOTA: "GetResponseStream" só pode ser usado uma vez!!!
                    //request: non-buffered stream that can only be read once

                    //Preserva conteudo num stream de memória
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string str = reader.ReadToEnd();
                    //Console.WriteLine(str);
                    var copyStream = new MemoryStream();
                    var writer = new StreamWriter(copyStream);
                    writer.Write(str);
                    writer.Flush();

                    //var copyStream = new MemoryStream();
                    //response.GetResponseStream().CopyTo(copyStream);
                    //StreamReader s = new StreamReader(copyStream);
                    //string json = s.ReadToEnd();
                    Console.WriteLine("Resposta:" + str);

                    //ou
                    //StreamReader reader = new StreamReader(response.GetResponseStream());
                    //string str = reader.ReadToEnd();
                    //Consolhttp://api.openweathermap.org/data/2.5/weather?q=Lisbon&mode=json&appid=b4e56d454f9ddc1a5b66102f99f28fa2e.WriteLine(str);

                    //ou 
                    //Console.WriteLine(GetPageAsString(uri.ToString()));

                    if (mode == "json")
                    {
                        //Serializa de JSON para Objecto
                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Root));
                        copyStream.Position = 0L;               //inicio do stream            
                        Root myClass = (Root)jsonSerializer.ReadObject(copyStream);
                        //Ou
                        //Root myClass = (Root)jsonSerializer.ReadObject(response.GetResponseStream());
                        ProcessResponse(myClass);
                    }
                    else //se for XML
                    {
                        // Converte em "ficheiro" a resposta recebida, em XML   
                        //GetXMLData(response.GetResponseStream());
                        GetXMLData(copyStream);
                    }
                }
                #endregion
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);

            }
            #endregion

        }

        #region Métodos auxiliares  XML  

        /// <summary>
        /// Método para devolver o conteúdo de uma página em string
        /// </summary>
        /// <param name="address">URI completo</param>
        /// <returns></returns>
        public static string GetPageAsString(String address)
        {
            string result = "";

            // Cria pedido Web 
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;
            // Analisa a resposta  
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Obtem a Resposta 
                StreamReader reader = new StreamReader(response.GetResponseStream());
                // Lê e converte em string
                result = reader.ReadToEnd();
            }
            return result;
        }

        /// <summary>
        /// Trata XML
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static void GetXMLData(Stream f)
        {
            DataSet ds = new DataSet();
            // converte o Stream num DataSet
            ds.ReadXml(f);
            // Mostra o XML do DataSet
            PrintDataSet(ds);
        }        
        
        /// <summary>
        /// Prepara output de XML
        /// </summary>
        /// <param name="ds">Dataset</param>
        public static void PrintDataSet(DataSet ds)
        {
            int x = ds.Tables.Count;
            foreach (DataTable table in ds.Tables)
            {
                for (int rn = 0; rn < table.Rows.Count; rn++)
                {
                    for (int cn = 0; cn < table.Columns.Count; cn++)
                    {

                        Console.WriteLine("Row: {0} : Col: {1} <{2}> = {3}", rn, cn, table.Columns[cn].Caption, table.Rows[rn][cn]);
                    }
                }

            }
        }

        #endregion       

        #region Métodos auxiliares_JSON
        static public void ProcessResponse(Root r)
        {
            double tmax = r.main.temp_max;
            Console.WriteLine("Temperatura: " +r.main.temp.ToString());
            Console.WriteLine("Humidade: " + r.main.humidity.ToString());
        }

        #endregion 
    }

    #region CONTRACTS_SERIALIZAÇÂO    

    #region WEATHER_CLASSES from JSON

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class Root
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public string @base { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }
    #endregion

    #region WEATHER_CLASSES from XML

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class current
    {

        private currentCity cityField;

        private currentTemperature temperatureField;

        private currentFeels_like feels_likeField;

        private currentHumidity humidityField;

        private currentPressure pressureField;

        private currentWind windField;

        private currentClouds cloudsField;

        private currentVisibility visibilityField;

        private currentPrecipitation precipitationField;

        private currentWeather weatherField;

        private currentLastupdate lastupdateField;

        /// <remarks/>
        public currentCity city
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }

        /// <remarks/>
        public currentTemperature temperature
        {
            get
            {
                return this.temperatureField;
            }
            set
            {
                this.temperatureField = value;
            }
        }

        /// <remarks/>
        public currentFeels_like feels_like
        {
            get
            {
                return this.feels_likeField;
            }
            set
            {
                this.feels_likeField = value;
            }
        }

        /// <remarks/>
        public currentHumidity humidity
        {
            get
            {
                return this.humidityField;
            }
            set
            {
                this.humidityField = value;
            }
        }

        /// <remarks/>
        public currentPressure pressure
        {
            get
            {
                return this.pressureField;
            }
            set
            {
                this.pressureField = value;
            }
        }

        /// <remarks/>
        public currentWind wind
        {
            get
            {
                return this.windField;
            }
            set
            {
                this.windField = value;
            }
        }

        /// <remarks/>
        public currentClouds clouds
        {
            get
            {
                return this.cloudsField;
            }
            set
            {
                this.cloudsField = value;
            }
        }

        /// <remarks/>
        public currentVisibility visibility
        {
            get
            {
                return this.visibilityField;
            }
            set
            {
                this.visibilityField = value;
            }
        }

        /// <remarks/>
        public currentPrecipitation precipitation
        {
            get
            {
                return this.precipitationField;
            }
            set
            {
                this.precipitationField = value;
            }
        }

        /// <remarks/>
        public currentWeather weather
        {
            get
            {
                return this.weatherField;
            }
            set
            {
                this.weatherField = value;
            }
        }

        /// <remarks/>
        public currentLastupdate lastupdate
        {
            get
            {
                return this.lastupdateField;
            }
            set
            {
                this.lastupdateField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class currentCity
    {

        private currentCityCoord coordField;

        private string countryField;

        private byte timezoneField;

        private currentCitySun sunField;

        private uint idField;

        private string nameField;

        /// <remarks/>
        public currentCityCoord coord
        {
            get
            {
                return this.coordField;
            }
            set
            {
                this.coordField = value;
            }
        }

        /// <remarks/>
        public string country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }

        /// <remarks/>
        public byte timezone
        {
            get
            {
                return this.timezoneField;
            }
            set
            {
                this.timezoneField = value;
            }
        }

        /// <remarks/>
        public currentCitySun sun
        {
            get
            {
                return this.sunField;
            }
            set
            {
                this.sunField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class currentCityCoord
    {

        private decimal lonField;

        private decimal latField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal lon
        {
            get
            {
                return this.lonField;
            }
            set
            {
                this.lonField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal lat
        {
            get
            {
                return this.latField;
            }
            set
            {
                this.latField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class currentCitySun
    {

        private System.DateTime riseField;

        private System.DateTime setField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime rise
        {
            get
            {
                return this.riseField;
            }
            set
            {
                this.riseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime set
        {
            get
            {
                return this.setField;
            }
            set
            {
                this.setField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class currentTemperature
    {

        private decimal valueField;

        private decimal minField;

        private decimal maxField;

        private string unitField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal min
        {
            get
            {
                return this.minField;
            }
            set
            {
                this.minField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal max
        {
            get
            {
                return this.maxField;
            }
            set
            {
                this.maxField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string unit
        {
            get
            {
                return this.unitField;
            }
            set
            {
                this.unitField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class currentFeels_like
    {

        private decimal valueField;

        private string unitField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string unit
        {
            get
            {
                return this.unitField;
            }
            set
            {
                this.unitField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class currentHumidity
    {

        private byte valueField;

        private string unitField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string unit
        {
            get
            {
                return this.unitField;
            }
            set
            {
                this.unitField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class currentPressure
    {

        private ushort valueField;

        private string unitField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string unit
        {
            get
            {
                return this.unitField;
            }
            set
            {
                this.unitField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class currentWind
    {

        private currentWindSpeed speedField;

        private currentWindGusts gustsField;

        private currentWindDirection directionField;

        /// <remarks/>
        public currentWindSpeed speed
        {
            get
            {
                return this.speedField;
            }
            set
            {
                this.speedField = value;
            }
        }

        /// <remarks/>
        public currentWindGusts gusts
        {
            get
            {
                return this.gustsField;
            }
            set
            {
                this.gustsField = value;
            }
        }

        /// <remarks/>
        public currentWindDirection direction
        {
            get
            {
                return this.directionField;
            }
            set
            {
                this.directionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class currentWindSpeed
    {

        private decimal valueField;

        private string unitField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string unit
        {
            get
            {
                return this.unitField;
            }
            set
            {
                this.unitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class currentWindGusts
    {

        private decimal valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class currentWindDirection
    {

        private ushort valueField;

        private string codeField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class currentClouds
    {

        private byte valueField;

        private string nameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class currentVisibility
    {

        private ushort valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class currentPrecipitation
    {

        private string modeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string mode
        {
            get
            {
                return this.modeField;
            }
            set
            {
                this.modeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class currentWeather
    {

        private ushort numberField;

        private string valueField;

        private string iconField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string icon
        {
            get
            {
                return this.iconField;
            }
            set
            {
                this.iconField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class currentLastupdate
    {

        private System.DateTime valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }


    #endregion

    #endregion



    

  

}
