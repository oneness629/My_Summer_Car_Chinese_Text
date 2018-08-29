using MSCLoader;
using MSCTranslateChs.Script.Common;
using MSCTranslateChs.Script.Common.Procurios.Public;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;


namespace MSCTranslateChs.Script.Translate
{
    public class TranslateText
    {
        Mod mod;
        Dictionary<string, Dictionary<string, string>> translateTextDict = new Dictionary<string, Dictionary<string, string>>();

        public const string DICT_SUBTITLE = "subtitle";
        public const string DICT_INTERACTION = "interaction";
        public const string DICT_PARTNAME = "partname";
        public const string DICT_GAMEOVER = "gameover";
        public const string DICT_CONFIG = "config";

        public bool isReadAllText = false;

        public TranslateText(Mod mod)
        {
            this.mod = mod;
            readTranslateTextDict();
        }

        public void readTranslateTextDict()
        {
            readTranslateTextDict(DICT_SUBTITLE);
            readTranslateTextDict(DICT_INTERACTION);
            readTranslateTextDict(DICT_PARTNAME);
            readTranslateTextDict(DICT_GAMEOVER);
            readTranslateTextDict(DICT_CONFIG);
            isReadAllText = true;
        }

        public void readTranslateTextDict(string dictKey)
        {
            List<string> list = File.ReadAllLines(Path.Combine(ModLoader.GetModAssetsFolder(mod), DICT_CONFIG + "txt")).ToList();
            Dictionary<string, string> dict = ConverUtil.ConverListToDictionary(list, "=");
            translateTextDict[dictKey] = dict;
        }

        public void writeTranslateTextDict(string dictKey)
        {
        }

    }
}
