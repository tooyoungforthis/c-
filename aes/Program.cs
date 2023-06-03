// Написать программу зашифровывающий и расшифровывающий файл симметричным
//алгоритмом AES. Название файла и файла ключа передаётся в командной строке

using System;
using System.IO;
using System.Security.Cryptography;

namespace AesEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Выберите файл, который вы хотите зашифровать: ");
            string textFileName = Console.ReadLine();
            try
            {
                File.ReadAllText(textFileName);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Файл с таким именем не существует");
            }
            string plainText = File.ReadAllText(textFileName);



            Console.Write("Выберите файла ключа и вектора инициализации: ");
            string keyFileName = Console.ReadLine();
            try
            {
                File.ReadAllText(keyFileName);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Файл с таким именем не существует");
            }

            string keyBase64;
            string vectorBase64;
            string key_iv = File.ReadAllText(keyFileName);
            if (key_iv.Split(" ").Length != 2)
            {
                Console.WriteLine("Неверные значения ключа и/или инициализируещего вектора");
                return;
            }
            else
            {
                keyBase64 = key_iv.Split(" ")[0];
                vectorBase64 = key_iv.Split(" ")[1];
            }


            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("Ключ шифрования:");
            Console.WriteLine(keyBase64);

            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("Вектор инициализации (IV):");
            Console.WriteLine(vectorBase64);

            string cipherText = EncryptDataWithAes(plainText, out keyBase64, out vectorBase64);

            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("Зашифрованный текст:");
            Console.WriteLine(cipherText);

            string decryptedText = DecryptDataWithAes(cipherText, keyBase64, vectorBase64);

            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("Расшифрованный текст:");
            Console.WriteLine(decryptedText);
        }

        private static string EncryptDataWithAes(string plainText, out string keyBase64, out string vectorBase64)
        {
            /// Шифрование сообщения
            using (Aes aesAlgorithm = Aes.Create())
            {

                // Установим необходимые значения ключа и иницилизирующего вектора
                keyBase64 = Convert.ToBase64String(aesAlgorithm.Key);
                vectorBase64 = Convert.ToBase64String(aesAlgorithm.IV);

                // Создадим инстанс для зашифрования сообщения
                ICryptoTransform encryptor = aesAlgorithm.CreateEncryptor();

                byte[] encryptedData;

                // Шифрование сообщение будет производиться в memory stream через объект CryptoStream
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                        encryptedData = ms.ToArray();
                    }
                }

                return Convert.ToBase64String(encryptedData);
            }
        }

        private static string DecryptDataWithAes(string cipherText, string keyBase64, string vectorBase64)
        {
            /// Дешифрование сообщения
            using (Aes aesAlgorithm = Aes.Create())
            {
                aesAlgorithm.Key = Convert.FromBase64String(keyBase64);
                aesAlgorithm.IV = Convert.FromBase64String(vectorBase64);

                // Создадим инстанс для расшифрования сообщения
                ICryptoTransform decryptor = aesAlgorithm.CreateDecryptor();

                byte[] cipher = Convert.FromBase64String(cipherText);

                // Дешифрование сообщение будет производиться в memory stream через объект CryptoStream
                using (MemoryStream ms = new MemoryStream(cipher))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}