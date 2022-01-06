
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace VarSave
{
    class Loader
    {
        public string path { get; }

        private object data;


        /// <summary>
        /// Simple class for loading data from binary files
        /// </summary>
        /// <param name="path">Path to binary file</param>
        public Loader(string _path)
        {
            path = _path;
        }

        /// <summary>
        /// Load data from file
        /// </summary>
        /// <returns>Success code</returns>
        public int LoadFromFile()
        {
            if (!File.Exists(path)) throw new FileNotFoundException($"File was not found in path : {path}");

            BinaryFormatter bf = new();
            using (FileStream fs = new(path, FileMode.Open))
            {
                data = bf.Deserialize(fs);
            }

            return 0;
        }
        public T GetVar<T>()
        {
            return (T)data;
        }
    }
}