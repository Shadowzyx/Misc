using System;
using ConsoleApp1.LinkedList;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleApp1.FileManager
{
    class FileWriter
    {
        string filename;

        public FileWriter(string filename)
        {
            this.filename = filename;
        }

        public void Serialize<T>(T elt, bool append = false)
        {
            using (Stream stream = File.Open(filename, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, elt);
            }
        }

        public ICollection<T> Deserialize<T>()
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            List<T> list = new List<T>();
            while (fs.Position != fs.Length)
            {
                var deserialized = (T)bf.Deserialize(fs);
                list.Add(deserialized);
            }
            fs.Close();
            return list;
        }
    }
}
