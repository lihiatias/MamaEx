﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    
    public class NumericalExpression
    {
        private Dictionary<int, string> Digit = new Dictionary<int, string>
        {
            {0, ""},
            {1, "One"},
            {2, "Two"},
            {3, "Three"},
            {4, "Four"},
            {5, "Five"},
            {6, "Six"},
            {7, "Seven"},
            {8, "Eight"},
            {9, "Nine"}
        };

        private Dictionary<int, string> Teens = new Dictionary<int, string>
        {
            {10, "Ten"},
            {11, "Eleven"},
            {12, "Twelve"},
            {13, "Thirteen"},
            {14, "Fourteen"},
            {15, "Fifteen"},
            {16, "Sixteen"},
            {17, "Seventeen"},
            {18, "Eighteen"},
            {19, "Nineteen"}
        };

        private Dictionary<int, string> Tens = new Dictionary<int, string>
        { 
            {2, "Twenty"},
            {3, "Thirty"},
            {4, "Forty"},
            {5, "Fifty"},
            {6, "Sixty"},
            {7, "Seventy"},
            {8, "Eighty"},
            {9, "Ninety"}
        };

        private Dictionary<int, string> Units = new Dictionary<int, string>
        {
            {0, ""},
            {1, "Thousand"},
            {2, "Million"},
            {3, "Billion"},
            {4, "Trillion"}
        };

        private long input_number;

        public NumericalExpression(long numbers) 
        {
            this.input_number = numbers;
        }
        public override string ToString()
        {
            if (input_number == 0)
                return "";
            string number_in_words = "";
            number_in_words = Transform(input_number);
            return number_in_words;
        }
        
        public string Transform(long number)
        {
            string number_in_words = "";
            if (number == 0)
                number_in_words = "";

            if (number>= 1000)
            {
                number_in_words = $"{Transform(number/1000)}{Units[(int)Math.Log10(number) / 3]} ";
                number %= 1000;
            }
            if (number > 100)
            {
                number_in_words+= $"{Digit[(int)number / 100]} Hundred ";
                number = number % 100;
            }
            if (number > 19 && number < 100)
            {
                number_in_words += $"{Tens[(int)number / 10]} ";
                number = number % 10;
            }
            
            if (number < 20 && number >= 10)
                number_in_words += $"{Teens[(int)number]} ";
            if (number < 10)
                number_in_words += $"{Digit[(int)number]} ";
            return number_in_words;
        }

        public long GetValue()
        {
            return input_number;   
        }

        public static int SumLetters(long number)
        {
            int count_words = 0;
            for (long i = 0; i < number; i++)
            {
                string words = new NumericalExpression(i).ToString();
                Array words_arr = words.Split(' ');
                count_words += words_arr.Length;
            }
            return count_words;
        }


    }
}
