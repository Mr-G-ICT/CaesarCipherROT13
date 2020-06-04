using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
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
            /* Description: standard vernam cipher that works with upper, lower
            /* Inputs: word to convert, wether it is encryption or decryption
            /* outputs: an encrypted word
            /* Improvements: needs to work for Symbols, but vernam doesn't do that.
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
                if(ASCIILetter >= 97 && ASCIILetter <= 122)
                {
                    Console.WriteLine("in here");
                    UpperOrLower = UpperOrLower + 32;
                }

                    //work out the letter of the alphabet in standard form e.g. a=1, b=2
                    ASCIILetter = ASCIILetter - UpperOrLower;

                //when fixed put in here all my research says this won't work in this algorithm
                //ASCIILetter = encryptDecryptSymbols(ASCIILetter);

                //if we have reached the end of the key, reset it so that we can reuse the word
                if (keyCount == MYVERNAMKEY.Length)
                {
                    keyCount = 0;
                }

                    //reset this every time, as i need to check with each loop if the letter is upper or lower
                    keyUpperOrLower = 64;
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
                encryptedString = encryptedString + Convert.ToChar( (ASCIILetter + UpperOrLower));
            }


            return encryptedString;
        }


        public int encryptDecryptSymbols(int LetterToConvert)
        {
/***********************************************************************/
/* CURRENTLY UNUSED - Was going to use this as part of vernam, but wouldnt work */
/* Description: used to encrypt symbols from a list of allowed
/* Inputs: a letter not recognised as an upper or lower case letter
/* outputs: the position in the array of the symbol identified
/*************************************************************************/

            //DOESN'T WORK...WILL Encrypt, but won't decrypt
            const string VALIDSYMBOLS = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            //this is the bit where i put in symbols, if the number is not between 1 and 26 
            //then it has to be a symbol, so work this out.
            if ((LetterToConvert < 1 || LetterToConvert > 26) && choice != "decrypt")
            {
                //so if the symbol is in the list, convert and encrypt otherwise return error
                for (int symbolCount = 0; symbolCount <= VALIDSYMBOLS.Length - 1; symbolCount++)
                {
                    if (Convert.ToChar((LetterToConvert + 65)) == VALIDSYMBOLS[symbolCount])
                    {
                        LetterToConvert = symbolCount - 26;
                        break;
                    }
                }
            }
            else
            {
                LetterToConvert = LetterToConvert + 26;
            }
            return LetterToConvert;

        }

public string BFIDCipher()
        {
            /*********************************************************************/
            /* Name: BFIDCipher
            /* Description: Learning how to construct a BFID cipher, this is a 2d array to store an encryption key
            /* then by multiplying the row and column can encrypt a letter       */
            /* Inputs: Word to Encrypt, taken from get fetch at top, a choice to encrypt or decrypt
            /* Outputs: an encrypted string 
            /***********************************************************************/
            string encryptedString = "";
            //removed J as we only have a 25 square and 26 letters of the alphabet
            //IMPROVEMENT extend to include more letters/symbols/numbers
            char[,] EncryptionKey = { {'R', 'A', 'N', 'C', 'H' } ,
                                      {'O', 'B', 'D', 'E', 'F' } ,
                                      {'G', 'I', 'K', 'L', 'M' } ,
                                      {'P', 'Q', 'S', 'T', 'U' } ,
                                      {'V', 'W', 'X', 'Y', 'Z' }
                                     };
            const int BLOCKSIZE = 5;

            string rowMatrix = "";
            string columnMatrix = "";

            int wordCount = 0;
            int rowCount;
            int columnCount;

            Console.WriteLine(EncryptionKey.GetLength(0));
            //find the letter in the matrix and store it's co-ordinates
            for (rowCount = 0; rowCount <= EncryptionKey.GetLength(0); rowCount++)
            {
                for(columnCount = 0; columnCount <= EncryptionKey.GetLength(1); columnCount++)
                {
                    if (Convert.ToChar(wordToEncrypt[wordCount]) == EncryptionKey[rowCount,columnCount])
                    {
                        rowMatrix = rowMatrix + rowCount;
                        columnMatrix = columnMatrix + columnCount;
                        break;
                    }
                }


            }


            return encryptedString
        }

       
    }
    }

