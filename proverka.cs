using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shambalaRegistryExample_09_11_2023
{
    internal class proverka
    {

            // Процедура, которая проверяет, есть ли запись нужного ключа и значения в реестре
            static bool IsExecutingBefore(string registryKeyPath, string registryKeyValueName)
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(registryKeyPath);
                if (key == null)
                {
                    return false;
                }
                object valueName = key.GetValue(registryKeyValueName);
                return valueName != null;
            }

            // Процедура, которая добавляет запись о том, что программа запускалась
            static void SetExecutingBeforeKey(string registryKeyPath, string registryKeyValueName)
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(registryKeyPath))
                {
                    key.SetValue(registryKeyValueName, "1", RegistryValueKind.String);
                }
            }

            static void Main(string[] args)
            {
                // ЗАДАЧА: написать программу, которая выводит 2 разных сообщения:
                //      1) "Запеченые булочки", если они запускается на этом компьютере первый раз
                //      2) "Банальное 'ПРИВЕТ'", если программа ранее запускалась на этом компьютере
                // При этом условия должны соблюдаться для разных инсталяций программы

                // Алгоритм:
                // При запуске программа проверяет запись в реестре, о том, запускалась ли она ранее
                // Если не запускалась -> сделать запись в реестре
                // Иначе отработать второй сценарий
                try
                {
                    string keyPath = "IS_EXECUTING_BEFORE_KEY";
                    string valueName = "IS_EXECUTING_BEFORE";

                    if (IsExecutingBefore(keyPath, valueName))
                    {
                        Console.WriteLine("Банальное 'ПРИВЕТ'");
                    }
                    else
                    {
                        Console.WriteLine("Запеченые булочки");
                        SetExecutingBeforeKey(keyPath, valueName);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Что-то пошло не так: {ex}");
                }
                finally
                {
                    Console.ReadLine();
                }
            }
        }
    }
