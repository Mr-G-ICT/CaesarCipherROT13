using System;
using System.Collections.Generic;
using System.Text;

namespace CaesarCipherROT13
{
    class ListOfCiphers
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

            for (int count = 0; count <= wordToEncrypt.Length - 1; count++)
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


        public string VernamCipher()
        {
            /*****************************************************************************/
            /* Name: Vernam Cipher
            /* Description: standard vernam cipher that initially works with upper case letters
            /* Inputs: word to convert, wether it is encryption or decryption
            /* outputs:
            /* potential improvements: build in characters that you can use, thinking an array
            /*****************************************************************************/
            
            string encryptedString ="";
            int ASCIILetter, keyLetter;
            int wordCount, keyCount = 0;
            int UpperOrLower = 65, keyUpperOrLower = 65; // this is to understand if Upper or lower case character and compensate accordingly in ascii conversion
            int diff;
            const string MYVERNAMKEY = "RANCHOBABA";


            for (wordCount = 0; wordCount <= wordToEncrypt.Length - 1; wordCount++)
            {
                UpperOrLower = 65;
                ASCIILetter = (int)Convert.ToChar(wordToEncrypt[wordCount]);

                //if it's a lowercase letter compensate
                if(ASCIILetter > 90)
                {
                    UpperOrLower = UpperOrLower + 32;
                }
                ASCIILetter = ASCIILetter - UpperOrLower;

                Console.WriteLine(ASCIILetter);

                if (keyCount == MYVERNAMKEY.Length)
                {
                    keyCount = 0;
                }

                if(keyCount <= MYVERNAMKEY.Length - 1)
                {
                    keyUpperOrLower = 65;
                    keyLetter = (int)Convert.ToChar(MYVERNAMKEY[keyCount]);

                    //if it's a lowercase letter compensate - this is to save time when changing keys
                    if (keyLetter > 90)
                    {
                        keyUpperOrLower = keyUpperOrLower + 32;
                    }

                    keyLetter = keyLetter - keyUpperOrLower;
                    ASCIILetter = ASCIILetter + keyLetter;
                    Console.WriteLine("keyuletter" + keyLetter);
                    //if the conversion goes beyond 26 then go back to start of the alphabet
                    if (ASCIILetter >= 26)
                    {
                        ASCIILetter = ASCIILetter - 26;
                       
                    }

                    keyCount = keyCount + 1;
                }
    


                encryptedString = encryptedString + Convert.ToChar( (ASCIILetter + UpperOrLower));
            }


            return encryptedString;
        }

    }
    }

