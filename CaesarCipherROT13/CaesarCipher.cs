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
            //Set the choice of encrypt or Decrypt, do not use a get 
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
            int diff;

            for(int count = 0; count <= wordToEncrypt.Length - 1; count++)
            {
               
                ASCIIletter = (int)Convert.ToChar(wordToEncrypt[count]);

                if (choice == "encrypt")
                {
                    //this is for encrypt
                    ASCIIletter = ASCIIletter + SHIFT;

                    //check if it's a letter
                    if (ASCIIletter >= (65+ SHIFT) && ASCIIletter <= (90 + SHIFT))
                    {
                        if (ASCIIletter >= 90)
                        {
                            diff = ASCIIletter - 90;
                            ASCIIletter = 64 + diff;
                        }

                    }else if(ASCIIletter >= (97+ SHIFT) && ASCIIletter <= (122+ SHIFT))
                    {
                        //if it's lower case, but goes beyond the bounds.
                        if (ASCIIletter >= 122)
                        {
                            diff = ASCIIletter - 122;
                            ASCIIletter = 96 + diff;
                        }

                    }
                } else
                {
                    //this is for decrypt
                    ASCIIletter = ASCIIletter - SHIFT;
                    if (ASCIIletter >= (65-SHIFT) && ASCIIletter <= (90- SHIFT))
                    {
                        if (ASCIIletter < 65)
                        {
                            diff = 65 - ASCIIletter;
                            ASCIIletter = 91 - diff;
                        }
                      
                    }else if (ASCIIletter > (97-SHIFT) && ASCIIletter < (122-SHIFT))
                    {       
                        if (ASCIIletter < 97)
                        {
                            diff = 97 - ASCIIletter;
                            ASCIIletter = 123 - diff;
                        }
                    }
            

                }
                encryptedString = encryptedString + Convert.ToChar(ASCIIletter);
            }

            return encryptedString;
        }

    }
    }

