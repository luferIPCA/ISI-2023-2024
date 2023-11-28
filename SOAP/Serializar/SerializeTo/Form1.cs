/**
 * lufer
 * Serializar: 
 *  Classe to JSON
 *  Classe to XML
 * 
 * */
using System;
using System.Windows.Forms;
using System.Web.Script.Serialization;  //Manipukar JSON: Add Reference to System.Web.Extensions
using Newtonsoft.Json;                  //Manipular JSON
using System.Xml.Serialization;         //Manipular XML
using System.IO;
using System.Xml.Linq;
using System.Xml;
//using System.Text.JSON;               //.NET Core

namespace SerializeTo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 2Json
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            Address obj = new Address();
            //com System.Xml.Serialization; 
            var json = new JavaScriptSerializer().Serialize(obj);
            MessageBox.Show(json.ToString());

            //ou com NewtonJson
            string aux = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.None);
            MessageBox.Show(aux);

            aux = JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
            MessageBox.Show(aux);

            //para ficheiro
            TextWriter writer = new StreamWriter(@"c:\temp\ISI\out.json");
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(writer, obj);
            writer.Close();
        }

        /// <summary>
        /// 2XML
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Address aux = new Address();
            XmlSerializer x = new XmlSerializer(aux.GetType());

            //para ficheiro
            TextWriter writer = new StreamWriter(@"c:\temp\ISI\out.xml");
            x.Serialize(writer, aux);
            writer.Close();

            //Para string
            StringWriter stringWriter = new StringWriter();
            x.Serialize(stringWriter, aux);
            string serializedXML = stringWriter.ToString();
            MessageBox.Show(serializedXML);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// JSON2XML
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            Address obj = new Address();
            //2json
            var json = new JavaScriptSerializer().Serialize(obj);
            //2XML
            XNode node = JsonConvert.DeserializeXNode(json, "Root");
            MessageBox.Show(node.ToString());

            //json2class
            Address obj2 = JsonConvert.DeserializeObject<Address>(json);
        }

        /// <summary>
        /// XML2JSON
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            //XML to file
            Address obj = new Address();
            XmlSerializer x = new XmlSerializer(typeof(Address));
            TextWriter writer = new StreamWriter(@"c:\temp\ISI\out.xml");
            x.Serialize(writer, obj);
            writer.Close();

            //XML to JSON
            XmlDocument doc = new XmlDocument();
            doc.Load(@"c:\temp\ISI\out.xml");
            string json = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented,true);
            MessageBox.Show(json);
        }

        /// <summary>
        /// JSON2Class
        /// https://json2csharp.com/
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            //Simular um JSON
            Address obj = new Address();
            var json = new JavaScriptSerializer().Serialize(obj);
            Address aux = JsonConvert.DeserializeObject<Address>(json);
            MessageBox.Show(aux.Street.ToString());
        }
    }
}
