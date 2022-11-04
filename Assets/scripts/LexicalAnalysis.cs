using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace XBlocks.Utils
{
    public class LexicalAnalysis : MonoBehaviour
    {
        string[] keywords = new string[] { "and", "clear", "break", "set", "to", "def", "del","else",  "repeat", "if", "in", "is",  "not", "or", "say"};

        bool isValidOperator(char ch)
        {
            if (ch == '+' || ch == '-' || ch == '*' ||
            ch == '/' || ch == '>' || ch == '<' )
                return true;
            return false;
        }

        bool isValidDelimiter(char s)
        {
            if (s == ' '  || s == '+' || s == '-' || s == '*' ||
               s == '/' ||  s == '>' ||
               s == '<')
                            return true;
            return false;
        }

        bool isvalidIdentifier(string str)
        {
            if (str[0] == '0' || str[0] == '1' || str[0] == '2' ||
            str[0] == '3' || str[0] == '4' || str[0] == '5' ||
            str[0] == '6' || str[0] == '7' || str[0] == '8' ||
            str[0] == '9' || isValidDelimiter(str[0]) == true)
                return (false);
            return (true);
        }

        bool isValidInteger(string str)
        {

            int i;
            int len = str.Length;
            if (len == 0)
            {
                return false;
            }

            for (i = 0; i < len; i++)
            {
                if (str[i] != '0' && str[i] != '1' && str[i] != '2' && str[i] != '3' && str[i] != '4' && str[i] != '5'
                && str[i] != '6' && str[i] != '7' && str[i] != '8' && str[i] != '9' || (str[i] == '-' && i > 0))
                    return (false);
            }
            return (true);
        }

        bool isRealNumber(string str)
        {
            int i = 0;
            int len = str.Length;
            bool hasDecimal = false;
            if (len == 0)
                return (false);
            for (i = 0; i < len; i++)
            {
                if (str[i] != '0' && str[i] != '1' && str[i] != '2' && str[i] != '3' && str[i] != '4' && str[i] != '5'
                && str[i] != '6' && str[i] != '7' && str[i] != '8' && str[i] != '9' && str[i] != '.' || (str[i] == '-' && i > 0))
                    return (false);
                if (str[i] == '.')
                    hasDecimal = true;
            }
            return hasDecimal;
        }

   /*   public int findIndex(this string[] array, string item)
        {
            return Array.FindIndex(array, val => val.Equals(item));
        }

        bool isKeyword(string target)
        {
            int position = findIndex(keywords, value);
            if(position > -1)
            {
                return true;
            } else
            {
                return false;
            }
        }

        void detectTokens(string str)
        {
            int left = 0, right = 0;
            int length = str.length;

            while (right < length && left <= right)
            {
                if (isValidDelimiter(str[right]) == false)
                {
                    right++;
                }
                if (isValidDelimiter(str[right]) == true && left == right)
                {
                    if (isValidOperator(str[right]) == true)
                    {
                        Debug.Log("Valid operator " + str[right]);
                    }
               
                        right++;
                    left = right;
                }
                else if (isValidDelimiter(str[right]) == true && left != right || (right == length && left != right))
                {
                    string subStr = str.Substring(left, right - left + 1);
                    if (isValidKeyword(subStr) == true)
                    {
                        Debug.Log("Valid keyword " + subStr);
                    }
                    else if (isValidInteger(subStr) == true)
                    {
                        Debug.Log("Valid Integer " + subStr);
                    }
                    else if (isRealNumber(subStr) == true)
                    {
                        Debug.Log("Real Number " + subStr);
                    }
                    else if (isvalidIdentifier(subStr) == true && isValidDelimiter(str[right - 1]) == false)
                    {
                        Debug.Log("Valid Identifier " + subStr);
                    }
                    else if (isvalidIdentifier(subStr) == false && isValidDelimiter(str[right - 1]) == false)
                    {
                        Debug.Log("Invalid Identifier " + subStr);
                        left = right;
                    }
                }
            }
            return;
        }*/

        void Start()
        {
            string str = "set a to 2";
            //detectTokens(str);
        }

        void Update()
        {

        }
    }

}
