﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace ContactsApp.Model
{
    /// <summary>
    /// Описывает менеджер проектов.
    /// </summary> 
    public class ProjectSerializer
    {
        /// <summary>
        /// Имя файла (путь)
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Сохраняет данные в userdata.json
        /// </summary>
        /// <param name="project"></param>
        public void SaveToFile(Project project) 
        {
            var way = (GetFolderPath(SpecialFolder.ApplicationData) + "\\Zhdanova\\ContactsApp");

            if (!(Directory.Exists(way)))
            {
                Directory.CreateDirectory(way);
                if (!File.Exists(FileName))
                {
                    File.Create(FileName);
                }
            }

            JsonSerializer serializer = new JsonSerializer();
            using (var stream = File.Open(@FileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                StreamWriter _streamWriter = new StreamWriter(stream);
                using (JsonWriter _writer = new JsonTextWriter(_streamWriter))
                {
                    serializer.Serialize(_writer, project);
                }
            }
        }

        /// <summary>
        /// Выгружает данные из userdata.json
        /// </summary>
        /// <returns></returns>
        public Project LoadFromFile()
        {
            var way = (GetFolderPath(SpecialFolder.ApplicationData) + "\\Zhdanova\\ContactsApp");
            Project project = null;
            if (!(Directory.Exists(way)))
            {
                Directory.CreateDirectory(way);
                if (!File.Exists(FileName))
                {
                    File.Create(FileName);
                }
            }
            try
            {
                JsonSerializer serializer = new JsonSerializer();
                using (var stream = File.Open(@FileName, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    StreamReader _streamReader = new StreamReader(stream);
                    using (JsonReader _reader = new JsonTextReader(_streamReader))
                    {
                        project = (Project)serializer.Deserialize(_reader, typeof(Project));
                    }
                }
            }
            catch
            {
                project = new Project();
            }
            if (project == null)
            {
                project = new Project();
            }
            return project;
        }

        public ProjectSerializer()
        {
            FileName = Environment.GetFolderPath(SpecialFolder.ApplicationData)
            + "\\Zhdanova\\ContactsApp\\userdata.json";
        }
    }  
}

