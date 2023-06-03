// XoR-шифрование
using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите исходный текст: ");
        string input_text = Console.ReadLine();

        Console.Write("Введите ключ шифрования: ");
        string key = Console.ReadLine();

        Console.WriteLine("----------------------");

        // Создание инстанса шифрования
        Encryptor encryptor = new Encryptor(input_text, key);

        Console.WriteLine($"Текст в бинарном виде: {encryptor.binary_text}");
        Console.WriteLine($"Ключ в бинарном виде {encryptor.binary_key}");

        Console.WriteLine("----------------------");

        Console.Write("Закодированный текст: ");
        encryptor.Encode();
        encryptor.BinaryToString();

        Console.WriteLine("----------------------");
        Console.Write("Декодированный текст: ");
        encryptor.Decode();
        encryptor.BinaryToString();
    }
}


class Encryptor
{
    public string text;
    public string key;

    public string binary_text;
    public string binary_key;
    public Encryptor(string text, string key)
    {
        this.text = text;
        this.key = key;
        this.binary_key = Encryptor.StringToBinary(this.key);
        this.binary_text = Encryptor.StringToBinary(this.text);
    }

    public static string XoR(string key, string text)
    {
        /// Реализаций опереции XoR
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
            sb.Append(text[i] == key[i] ? '0' : '1');
        String result = sb.ToString();

        return result;
    }

    public void Encode()
    {
        /// Шифроввание сообщения
        StringBuilder sb = new StringBuilder();
        string num;

        for (int i = 0; i < this.binary_text.Length; i += this.binary_key.Length)
        {
            num = this.binary_text.Substring(i, this.binary_key.Length);
            sb.Append(Encryptor.XoR(num, this.binary_key));
        }
        this.binary_text = sb.ToString();
        Console.WriteLine(this.binary_text);
    }

    public void Decode()
    {
        /// Дешифрование сообщения
        {
            StringBuilder sb = new StringBuilder();
            string num;

            for (int i = 0; i < this.binary_text.Length; i += this.binary_key.Length)
            {
                num = this.binary_text.Substring(i, this.binary_key.Length);
                sb.Append(Encryptor.XoR(num, this.binary_key));
            }
            this.binary_text = sb.ToString();
            Console.WriteLine(this.binary_text);
        }
    }

    public static string StringToBinary(string text)
    {
        StringBuilder sb = new StringBuilder();

        foreach (char c in text.ToCharArray())
        {
            sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
        }

        return sb.ToString();
    }

    public void BinaryToString()
    {
        List<Byte> byteList = new List<Byte>();

        for (int i = 0; i < this.binary_text.Length; i += 8)
        {
            byteList.Add(Convert.ToByte(this.binary_text.Substring(i, 8), 2));
        }

        this.text = Encoding.ASCII.GetString(byteList.ToArray());
        Console.WriteLine(this.text);
    }



}