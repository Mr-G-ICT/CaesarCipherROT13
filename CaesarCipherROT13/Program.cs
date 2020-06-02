using System;

namespace CaesarCipherROT13
{
    class Program
    {
        static void Main(string[] args)
        {
            ListOfCiphers MyCipherClass = new ListOfCiphers();
            string word = "";
            string choice;
            Console.WriteLine("enter your string");
            MyCipherClass.setWordToEncrypt = Console.ReadLine();

            Console.WriteLine("do you want to encrypt or decrypt");
            MyCipherClass.setChoiceOfEncryptDecrypt = Console.ReadLine();

            Console.WriteLine("please choose your cipher");
            choice = Console.ReadLine();

            switch(choice)
            {
                case "caesar":
                    word = MyCipherClass.ROTCipher();
                    break;
                case "vernam":
                    word = MyCipherClass.VernamCipher(); 
                    break;

            }


          

            Console.WriteLine(word);
        }


    }
}
