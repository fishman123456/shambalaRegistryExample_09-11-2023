using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shambalaRegistryExample_09_11_2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region
            //Console.OutputEncoding = Encoding.UTF8;
            //        Console.WriteLine(Registry.CurrentUser.Name);
            //        Console.ReadKey();
            //        string[] currentUserSubKeyNames = Registry.CurrentUser.GetSubKeyNames();
            //        foreach (string key in currentUserSubKeyNames)
            //        { Console.WriteLine($"\t{key}"); }
            //    Console.ReadKey();


            //    string[] classesRootSubKeyNames = Registry.ClassesRoot.GetSubKeyNames();
            //        foreach (string key in classesRootSubKeyNames)
            //        { Console.WriteLine($"\t{key}"); }
            //Console.ReadKey();
            //PrintSubKey(Registry.CurrentUser);
            //PrintSubKey(Registry.ClassesRoot);
            //PrintSubKey(Registry.Users);
            //PrintSubKey(Registry.CurrentConfig);
            //PrintSubKey(Registry.PerformanceData);
            //PrintSubKey(Registry.DynData);
            #endregion
            //PrintSubKey(Registry.CurrentUser.OpenSubKey("Printers\\ConvertUserDevModesCount"));
            
        }
        static void PrintSubKey(RegistryKey key)
        {
            try
            { 
                    Console.WriteLine($"key: {key.Name}");
                    Console.WriteLine($"value: {key}");
                    string[] valueNames = key.GetValueNames();
                    for (int i = 0; i < key.ValueCount; i++)
                    {
                        Console.WriteLine($"{valueNames[i]} = {key.GetValue(valueNames[i])} ");
                    }

                    string[] classesRootSubKeyNames = key.GetSubKeyNames();
                foreach (string keys in classesRootSubKeyNames)
                { Console.WriteLine($"\t{keys}"); }
                Console.ReadKey();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void CreateKeyWithValue()
        {
            // создать под ключ  в каком либо ключе
            RegistryKey key = Registry.CurrentUser.CreateSubKey("new_key");
            // закрыть ключ
            key.Close();
        }

        static void GetandChengeKeyValue()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey("new_key", true))
            {
                
            }
        }
    }
}
