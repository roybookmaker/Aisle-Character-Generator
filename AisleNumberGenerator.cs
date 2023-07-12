using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //USER INPUT//////////////////////////////////////
            //aisle number type - integer = 0 ; alphabet = 1
            int aislenumbertype = 1;
            
            //how much aisle number you want to generate?
            int aislelimit = 1000;
            
            //numbering length - lowest = 1
            int charlength = 3;
            //////////////////////////////////////////////////
            
            //DECLARATION/////////////////////////////////////
            //this for declare purposes only. this will be used on looping procedure later
            int highestnumber;
            int loopingnumber = 0;
            int lastnumberofarray;
            int currentpointer = 0;
            
            //for converting purposes
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            int convertnumbering = 0;
            //////////////////////////////////////////////////
            
            //now we set the initial array and fill it with base number
            int[] aislenumber = Enumerable.Repeat(0, charlength).ToArray();
            //if you're using .net core, USE :
            //int[] aislenumber = new int[charlength];
            //THEN
            //Array.Fill(aislenumber, aislenumbertype);
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //EXPLANATION :
            //this basically filled the starting array with lowest number. we can use aislenumbertype variable as lowest number.
            //this will be used for converting from number to alphabet.
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            
            //SET THE DIFFERENCE BETWEEN ALPHABET AND INTEGER RESULT///////////////////////////////////////////////////////
            if(aislenumbertype == 0){
                highestnumber = 9;
                //because the highest single integer is 9; 1-9.
            }
            else{
                highestnumber = 25;
                //because the highest number value of alphabet is 25. A = 0, Z = 25.
            }
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            lastnumberofarray = charlength - 1;
            //since length of array always start from 0, so last number of array != charlength, but always 1 number less than charlength.
            
            aislenumber[lastnumberofarray] -= 1;
            //this is so the first generated number is start from the very first

            //the looping part
            do {
                if(aislenumber.All(x => x == highestnumber)){
                    break;
                }
                else{
                    if(aislenumber[lastnumberofarray] < highestnumber){
                        currentpointer = lastnumberofarray;
                        aislenumber[lastnumberofarray] += 1;
                    }
                    else{
                        aislenumber[lastnumberofarray] = 0;

                        currentpointer -= 1;

                        if(aislenumber[currentpointer] < highestnumber){
                            aislenumber[currentpointer] += 1;
                        }
                        else{
                            aislenumber[currentpointer] = 0;
                            currentpointer -= 1;
                            aislenumber[currentpointer] += 1;
                        }
                    }
                }
                
                loopingnumber++;
                
                //now convert the result to string for console print
                if(aislenumbertype == 0){
                    string generatedaisle = String.Join("", aislenumber);
                    
                    //end result
                    Console.WriteLine(generatedaisle);
                }
                else{
                    char[] converted = Enumerable.Repeat('A', charlength).ToArray();
                
                    foreach(int i in aislenumber){
                        converted[convertnumbering] = alpha[i];
                        convertnumbering++;
                    }

                    convertnumbering = 0;

                    //end result
                    Console.WriteLine(converted);
                }
            }
            while (loopingnumber != aislelimit);
        }
    }
}