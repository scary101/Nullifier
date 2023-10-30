﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
            path = path.Replace(extension, "");
            File.WriteAllText(path, json);
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
            string a = list[0].namePerson;
            string b = list[1].namePerson;
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
        public void LoadFile( string path)
        {
            string extension = Path.GetExtension(path);
            switch (extension)
            {
                case ".xml":
                    DesXml(path);
                    break;
                case ".json":
                    DesJson(path);
                    break;
            }
        }

    }
}
