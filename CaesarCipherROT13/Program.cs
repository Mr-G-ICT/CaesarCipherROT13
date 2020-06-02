using System;

namespace CaesarCipherROT13
{
    class Program
    {
        static void Main(string[] args)
        {
            CaesarCipher MyROTCipher = new CaesarCipher();
            string word;
            string choice;
            Console.WriteLine("enter your string");
            MyROTCipher.setWordToEncrypt = Console.ReadLine();

            Console.WriteLine("do you want to encrypt or decrypt");
            MyROTCipher.setChoiceOfEncryptDecrypt = Console.ReadLine();

            word = MyROTCipher.ROTCipher();

            Console.WriteLine(word);
        }

    
}
