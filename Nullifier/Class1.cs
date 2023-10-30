using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Nullifier
{
    public class KDA
    {
        public string namePerson;
        public int kill;
        public int death;
        public int assist;

        public  KDA() { }
        
        public KDA(string namePersons, int deaths, int assists,  int kills)
        {
            kill = kills;
            death = deaths;
            assist = assists;
            namePerson = namePersons;
        }
        

    }
    public class FileWork
    {
        private void SerJson(string path, List<KDA> list)
        {
            string json = JsonConvert.SerializeObject(list);
            string extension = Path.GetExtension(path);
        }
        private void SerXml(string path, List<KDA> list)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<KDA>));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, list);
            }
        }
        private void SerTxt(string path, List<KDA> list)
        {
            StreamWriter sw = new StreamWriter(path);
            foreach (KDA item in list)
            {
                sw.Write(item.namePerson);
                sw.WriteLine(",");
                sw.Write(item.kill.ToString());
                sw.WriteLine(",");
                sw.Write( item.death.ToString());
                sw.WriteLine(",");
                sw.Write( item.assist.ToString());
                sw.WriteLine(",");
            }
            sw.Close();

        }
        public void SaveFile(List<KDA> kda , string path)
        {
            string extension = Path.GetExtension(path);
            switch (extension)
            {
                case ".xml":
                    SerXml(path, kda);
                    break;
                case ".json":
                    SerJson(path, kda);
                    break;
                case ".txt":
                   SerTxt(path, kda);
                    break;
            }
        }
        private List <KDA> DesJson(string path)
        {
            string txt = File.ReadAllText(path);
            List<KDA> list = new List<KDA>();
            return list = JsonConvert.DeserializeObject<List<KDA>>(txt);
        }
        private List<KDA> DesXml(string path)
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<KDA>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                List<KDA> list = new List<KDA>();
                return list = (List<KDA>)xml.Deserialize(fs);
            }
        }
        private string DasTxt(string path)
        {
            string txt = File.ReadAllText(path);
            return txt;
        }
        public List<KDA> LoadFile( string path, List<KDA> list1)
        {
            string extension = Path.GetExtension(path);
            List<KDA> list = new List<KDA>();
            switch (extension)
            {
                case ".xml":
                    list = DesXml(path);
                    break;
                case ".json": 
                    list =DesJson(path);
                    break;
                case ".txt":
                    string txt = DasTxt(path);
                    Console.WriteLine(txt);
                    break;
            }
            return list;
        }

    }
}
