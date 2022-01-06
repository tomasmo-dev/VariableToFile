
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace VarSave
{
    class Saver
    {
        public string path { get; }
        private Type type { get; }

        private bool overwriteF;

        /// <summary>
        /// Short Class for converting variables/structs to BinaryFiles
        /// </summary>
        /// <param name="_p">Path to save binary file to. Make sure no file with same name exists</param>
        /// <param name="overwriteFile">If final file should be overwritten if already exists (defaults to false)</param>

        public Saver(string _p, bool overwriteFile = false)
        {
            path = _p;

            overwriteF = overwriteFile;
        }

        /// <summary>
        /// Function That saves var/struct to file
        /// </summary>
        /// <returns>Success code</returns>
        public int SaveToFileLegacy(object value)
        {
            if (File.Exists(path) && !overwriteF)
            {
                throw new Exception("File already exist and overwrite disabled!");
            }

            BinaryFormatter bf = new();

            byte[] varConverted;

            using (MemoryStream ms = new())
            {
                bf.Serialize(ms, value);
                varConverted = ms.ToArray();
            }

            if (!overwriteF)
            {
                WriteToFile(varConverted);
                return 0;
            }
            else
            {
                ForceWriteToFile(varConverted);
                return 0;
            }


        }
        /// <summary>
        /// Same like SaveToFileLegacy but you dont need to cast to object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int SaveToFile<T>(T val)
        {
            if (File.Exists(path) && !overwriteF)
            {
                throw new Exception("File already exist and overwrite disabled!");
            }

            object value = (object)val;

            BinaryFormatter bf = new();

            byte[] varConverted;

            using (MemoryStream ms = new())
            {
                bf.Serialize(ms, value);
                varConverted = ms.ToArray();
            }

            if (!overwriteF)
            {
                WriteToFile(varConverted);
                return 0;
            }
            else
            {
                ForceWriteToFile(varConverted);
                return 0;
            }
        }

        #region FileSaving

        private void WriteToFile(byte[] value)
        {
            using (FileStream fs = new(path, FileMode.CreateNew))
            {
                FS_save(fs, value);
            }
        }

        private void ForceWriteToFile(byte[] value)
        {
            using (FileStream fs = new(path, FileMode.Create))
            {
                FS_save(fs, value);
            }
        }

        private void FS_save(FileStream fs, byte[] value)
        {
            fs.Write(value, 0, value.Length);
        }
        #endregion
    }
}