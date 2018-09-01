using MSCLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace MSCTranslateChs.Script.Common
{
    public class ConverUtil
    {
        private static LOGGER logger = new LOGGER(typeof(ConverUtil));

        public static Dictionary<string, string> ConverListToDictionary(List<string> list, string splitText = "=")
        {
            if (list != null)
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                foreach (string text in list)
                {
                    string [] result = text.Split(splitText.ToCharArray());
                    if (result != null && result.Length == 2 && result[0] != null && result[1] != null &&
                        result[0].Trim().Length > 0 && result[1].Trim().Length > 0
                        )
                    {
                        string key = result[0];
                        string value = result[1];
                        key = key.Replace("\\n", "\n");
                        value = value.Replace("\\n", "\n");
                        if(!dictionary.ContainsKey(key))
                        {
                            dictionary.Add(key, value);
                        }
                    }
                    else
                    {
                        logger.LOG("无法转换文本：" + text);
                    }
                }
                return dictionary;
            }

            return null;
        }

        public static List<string> ConverDictionaryToList(Dictionary<string, string> dictionary, string splitText = "=")
        {
            if (dictionary != null)
            {
                List<string> list = new List<string>();
                foreach (string key in dictionary.Keys)
                {
                    if (key != null && dictionary.ContainsKey(key))
                    {
                        string text = key.Replace("\n", "\\n") + splitText + dictionary[key].Replace("\n", "\\n");
                        list.Add(text);
                    }
                }
                return list;

            }
            return null;
        }

        

        public static void Main(string[] args)
        {

            List<string> list = new List<string>();
            list.Add("111=222");
            list.Add("aaa=222aaa");
            Dictionary<string, string> dict = ConverUtil.ConverListToDictionary(list, "=");
            
            logger.LOG(dict.ToString());
            list = ConverUtil.ConverDictionaryToList(dict, "=");
            logger.LOG(dict.ToArray().ToString());

            

        }
    }
}
