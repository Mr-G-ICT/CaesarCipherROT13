using System;
using System.Collections.Generic;
using System.Text;

namespace CaesarCipherROT13
{
    class CaesarCipher
    {
        private string wordToEncrypt;

        public string setWordToEncrypt
        {
            //Set the string we are going to convert, do not use a get 
            //method as we don't ever need to get the string
            set { wordToEncrypt = value; }
        }
        public string choice;

        public string setChoiceOfEncryptDecrypt
        {
            //Set the string we are going to convert, do not use a get 
            //method as we don't ever need to get the string
            set { choice = value; }
        }

        public string ROTCipher() 
        {
/*************************************************************************/
/* Name: caesar cipher
/* Description: a standard ROT 13 encrypter/decrypter.
/* inputs: the word, wether you want to encrypt or decrypt
/* outputs: the encrypted/decrypted string
/* IMProvements: make it work for upper and lower case, will need more formatting tho'
/************************************************************************/

            const int SHIFT = 13;
            string encryptedString = "";
            int ASCIIletter;

            for(int count = 0; count <= wordToEncrypt.Length - 1; count++)
            {
               
                ASCIIletter = (int)Convert.ToChar(wordToEncrypt[count]);
                
                //check if it's a letter
                if (ASCIIletter >= 65 && ASCIIletter <= 90)
                {
                    if (choice == "encrypt")
                    {
                        //this is for decrypt
                        ASCIIletter = ASCIIletter + SHIFT;

                        if (ASCIIletter >= 90)
                        {
                            int diff = ASCIIletter - 90;
                            ASCIIletter = 64 + diff;
                        }

                    }
                    else
                    {
                        //this is for decrypt
                        ASCIIletter = ASCIIletter - SHIFT;
                        if (ASCIIletter <= 65)
                        {
                            int diff = 65 - ASCIIletter;
                            ASCIIletter = 91 - diff;
                        }

                    }

                }
                encryptedString = encryptedString + Convert.ToChar(ASCIIletter);
            }

            return encryptedString;
        }

    }
    }
}
