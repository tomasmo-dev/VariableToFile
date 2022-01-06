using System;
using System.IO;
using static System.Environment;

namespace VarToFile
{
    internal class Example
    {
        static string DesktopPath = Path.Combine(Environment.GetFolderPath(SpecialFolder.Desktop), "some_name.bin");

        static void SaveExample()
        {
            VarSave.Saver saver = new(DesktopPath, true); // true to overwrite already existing files
            int success_val = saver.SaveToFileLegacy((object)"some value ||| MUST CAST TO OBJECT");//file exist checks in save functions // old version with use of casting
            int success_val1 = saver.SaveToFile<string>("some value"); // better version no casting to object

            Console.WriteLine($"{success_val} : Legacy code"); // returns 0 as successfull and throws exception on error
            Console.WriteLine($"{success_val1} : Newer Function");
        }

        static void LoadExample()
        {
            VarSave.Loader loader = new(DesktopPath);
            int success_val = loader.LoadFromFile();
            var value = loader.GetVar<string>();

            Console.WriteLine($"loader success value : {success_val}");
            Console.WriteLine($"loaded value : {value}");
        }

        static void GithubExample()
        {
            string save_this = "some string";

            VarSave.Saver save = new VarSave.Saver(@"Your path where you want your file saved here");
            int return_value = save.SaveToFile<string>(save_this);
            // string variable saved

            //To retrieve it from file use:
            VarSave.Loader load = new VarSave.Loader(@"Your path to saved file here");
            int return_value1 = load.LoadFromFile(); // variable loaded to memory
            string value = load.GetVar<string>(); // gets the value from memory

            //now value from file is saved into "value" variable

            Console.WriteLine(value);
        }

        static void Main()
        {
            SaveExample();
            Console.WriteLine(); // just new line
            LoadExample();
        }
    }
}
