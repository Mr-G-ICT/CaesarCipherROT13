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
            /* Description: standard vernam cipher that works with upper, lower and special characters
            /* Inputs: word to convert, wether it is encryption or decryption
            /* outputs: an encrypted word
            /* Improvements: the encryption now works, now on to the decryption 
            /*****************************************************************************/
            
            string encryptedString ="";
            int ASCIILetter, keyLetter;
            int wordCount, keyCount = 0;
            int UpperOrLower = 65, keyUpperOrLower = 65; // this is to understand if Upper or lower case character and compensate accordingly in ascii conversion
            int diff;
            const string MYVERNAMKEY = "RANCHOBABAZ";

            //loop through the word to be encrypted.
            for (wordCount = 0; wordCount <= wordToEncrypt.Length - 1; wordCount++)
            {
                UpperOrLower = 65;
                ASCIILetter = (int)Convert.ToChar(wordToEncrypt[wordCount]);

                //if it's a lowercase letter compensate
                if(ASCIILetter > 90)
                {
                    UpperOrLower = UpperOrLower + 32;
                }

                    //work out the letter of the alphabet in standard form e.g. a=1, b=2
                    ASCIILetter = ASCIILetter - UpperOrLower;

                Console.WriteLine(ASCIILetter);


                //DOESN'T WORK...WILL Encrypt, but won't decrypt
                const string VALIDSYMBOLS = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
                //this is the bit where i put in symbols, if the number is not between 1 and 26 
                //then it has to be a symbol, so work this out.
                if ((ASCIILetter < 1 || ASCIILetter > 26) && choice != "decrypt")
                {
                    //so if the symbol is in the list, convert and encrypt otherwise return error
                    for (int symbolCount = 0; symbolCount <= VALIDSYMBOLS.Length - 1; symbolCount++)
                    {
                        if (wordToEncrypt[wordCount] == VALIDSYMBOLS[symbolCount])
                        {
                            ASCIILetter = symbolCount + 75;
                            break;
                        }
                    }
                }
                else {
                    ASCIILetter = ASCIILetter - 75;

                
                }


                //if we have reached the end of the key, reset it so that we can reuse the word
                if (keyCount == MYVERNAMKEY.Length)
                {
                    keyCount = 0;
                }

                    //reset this every time, as i need to check with each loop if the letter is upper or lower
                    keyUpperOrLower = 65;
                    keyLetter = (int)Convert.ToChar(MYVERNAMKEY[keyCount]);

                    //if it's a lowercase letter compensate - this is to save time when changing keys
                    if (keyLetter > 90)
                    {
                        keyUpperOrLower = keyUpperOrLower + 32;
                    }



                //work out the letter of the alphabet in standard form e.g. a=1 b=2
                keyLetter = keyLetter - keyUpperOrLower;

                if (choice == "decrypt")
                {

                    ASCIILetter = ASCIILetter - keyLetter;
                    Console.WriteLine("decrypt" + ASCIILetter);
                    if(ASCIILetter < 0)
                    {
                        ASCIILetter = ASCIILetter + 26;
                    }
                }
                else
                {
                    ASCIILetter = ASCIILetter + keyLetter;

                    //if the conversion goes beyond 26 then go back to start of the alphabet
                    if (ASCIILetter >= 26 && ASCIILetter <=75)
                    {
                        ASCIILetter = ASCIILetter - 26;

                    }
                }              

                    //move onto the next letter of the key
                    keyCount = keyCount + 1;

                //add the encrypted letter to the end of the string.
                Console.WriteLine("final letter"+ ASCIILetter + UpperOrLower);
                encryptedString = encryptedString + Convert.ToChar( (ASCIILetter + UpperOrLower));
            }


            return encryptedString;
        }

    }
    }

