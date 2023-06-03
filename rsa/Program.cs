// Написать программу зашифровующую и расшифровующую файл симметричным
// алгоритмом RSA. Название файла  и файла ключа передаются в командной строке.
// При отсутствии файла ключа, сгенерировать ключ и сохранить в файле
// или использовать сертификат

using System;
using System.Security.Cryptography;
using System.Text;

namespace RSA
{
    class Program
    {
        static void Main(string[] args)
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            var privateKey = RSA.ExportParameters(true);
            var publicKey = RSA.ExportParameters(false);

            UnicodeEncoding byteConverter = new UnicodeEncoding();

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
            string toEncrypt = File.ReadAllText(textFileName);
            Console.WriteLine($"Сообщение до шифрования: {toEncrypt}");

            byte[] encBytes = RSAEncrypt(byteConverter.GetBytes(toEncrypt), publicKey, false);
            string encrypt = byteConverter.GetString(encBytes);
            Console.WriteLine("Зашифрованное сообщение: " + encrypt);

            byte[] decBytes = RSADecrypt(encBytes, privateKey, false);
            Console.WriteLine("Рассшифрованное сообщение: " + byteConverter.GetString(decBytes));
        }

        static public byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            // Создание инстанса RSACryptoServiceProvider
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

            // Импорт информации о ключе
            RSA.ImportParameters(RSAKeyInfo);

            // Зашифрорвка переданного байт-массива
            return RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
        }

        static public byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            // Создание инстанса RSACryptoServiceProvider
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

            // Импорт информации о ключе
            RSA.ImportParameters(RSAKeyInfo);

            // Расшифрорвка переданного байт-массива
            return RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
        }
    }
}