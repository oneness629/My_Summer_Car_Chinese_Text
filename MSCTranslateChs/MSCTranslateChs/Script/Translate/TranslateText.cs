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
using System.Threading;

namespace MSCTranslateChs.Script.Translate
{
    public class TranslateText
    {
        private static LOGGER logger = new LOGGER(typeof(TranslateText));

        Mod mod;
        Dictionary<string, Dictionary<string, string>> translateTextDict = new Dictionary<string, Dictionary<string, string>>();
        Dictionary<string, int> translateTextSizeDict = new Dictionary<string, int>();

        public const string DICT_SUBTITLE = "subtitle";
        public const string DICT_INTERACTION = "interaction";
        public const string DICT_PARTNAME = "partname";
        public const string DICT_GAMEOVER = "gameover";
        public const string DICT_CONFIG = "config";

        public bool isReadAllText = false;
        public bool isEnableAutoTranslateApi = false;

        private TranslateApi translateApi;

        private string autoTranslateApiAppId;
        private string autoTranslateApiApikey;
        
        private string notTranslateString = "[未翻译文本]";
        private string autoTranslateStringing = "[自动翻译中 ... ]";

        public TranslateText(Mod mod)
        {
            this.mod = mod;
            ReadTranslateTextDict();
            InitTranslateApi();
        }

        public void InitTranslateApi()
        {
            autoTranslateApiAppId = translateTextDict[DICT_CONFIG]["AUTO_TRANSLATE_API_APP_ID"];
            autoTranslateApiApikey = translateTextDict[DICT_CONFIG]["AUTO_TRANSLATE_API_API_KEY"];
            isEnableAutoTranslateApi = translateTextDict[DICT_CONFIG]["IS_ENABLE_AUTO_TRANSLATE_API"].ToLower() == "true";

            logger.LOG("自动翻译API启用状态 :" + isEnableAutoTranslateApi);
            logger.LOG("自动翻译API appid :" + autoTranslateApiAppId);
            logger.LOG("自动翻译API apikey :" + autoTranslateApiApikey);
            if (isEnableAutoTranslateApi)
            {
                translateApi = new TranslateApi(autoTranslateApiAppId, autoTranslateApiApikey);
                logger.LOG("初始化自动翻译API完成");
            }
            else
            {
                logger.LOG("不使用自动翻译API");
                translateApi = null;
            }
        }

        public void ReadTranslateTextDict()
        {
            ReadTranslateTextDict(DICT_SUBTITLE);
            ReadTranslateTextDict(DICT_INTERACTION);
            ReadTranslateTextDict(DICT_PARTNAME);
            ReadTranslateTextDict(DICT_GAMEOVER);
            ReadTranslateTextDict(DICT_CONFIG);
            isReadAllText = true;
            logger.LOG("读取所有txt文件完成");
        }

        public void ReadTranslateTextDict(string dictKey)
        {
            List<string> list = File.ReadAllLines(Path.Combine(ModLoader.GetModAssetsFolder(mod), dictKey + ".txt")).ToList();
            Dictionary<string, string> dict = ConverUtil.ConverListToDictionary(list);
            translateTextDict[dictKey] = dict;
            translateTextSizeDict[dictKey] = dict.Count;
            logger.LOG("读取"+ dictKey + ".txt文件完成");
        }

        public void WriteTranslateTextDict()
        {
            WriteTranslateTextDict(DICT_SUBTITLE);
            WriteTranslateTextDict(DICT_INTERACTION);
            WriteTranslateTextDict(DICT_PARTNAME);
            WriteTranslateTextDict(DICT_GAMEOVER);
            WriteTranslateTextDict(DICT_CONFIG);
            logger.LOG("写入所有txt文件完成");
        }

        public void WriteTranslateTextDict(string dictKey)
        {
            List<string> list = ConverUtil.ConverDictionaryToList(translateTextDict[dictKey]);
            File.WriteAllLines(Path.Combine(ModLoader.GetModAssetsFolder(mod), dictKey + ".txt"), list.ToArray());
            logger.LOG("写入"+ dictKey + ".txt文件完成");
        }


        public string TranslateString(string text, string dictKey)
        {
            if (string.IsNullOrEmpty(text))
            {
                return "\"\"";
            }
            // 统一大写
            text = text.ToUpper();
            if (!translateTextDict[dictKey].ContainsKey(text))
            {
                logger.LOG("文本在列表"+ dictKey + "中未找到: " + text);
                if (isEnableAutoTranslateApi)
                {
                    logger.LOG("自动翻译文本:" + text);
                    translateTextDict[dictKey][text] = autoTranslateStringing;


                    Thread thread = new Thread(new ParameterizedThreadStart(this.AutoTranslateString));
                    Dictionary<string, string> param = new Dictionary<string, string>();
                    param.Add("text", text);
                    param.Add("dictKey", dictKey);
                    thread.IsBackground = true;
                    thread.Start(param);
                    return autoTranslateStringing;
                }
                else
                {
                    translateTextDict[dictKey][text] = notTranslateString;
                    return notTranslateString;
                }
            }
            return translateTextDict[dictKey][text];
        }

        private void AutoTranslateString(object dict)
        {
            try
            {
                Dictionary<string, string> paramDict = dict as Dictionary<string, string>;
                if (paramDict != null && paramDict["text"] != null && paramDict["dictKey"] != null)
                {
                    if (translateApi != null)
                    {
                        string waitTranslateString = paramDict["text"];
                        string dictKey = paramDict["dictKey"];
                        string result = translateApi.TranslationEnglishToChineseFromBaiduFanyi(waitTranslateString);
                        logger.LOG("自动翻译"+ dictKey + "文本完成，替换目标文本 -> \n" + translateTextDict[dictKey][waitTranslateString]);
                        translateTextDict[dictKey][waitTranslateString] = result;
                        logger.LOG("自动翻译" + dictKey + "文本结果:" + result);
                        WriteTranslateTextDict();
                        ReadTranslateTextDict();
                    }
                    else
                    {
                        logger.LOG("自动翻译API为空，不翻译");
                    }
                }
            }
            catch (Exception e)
            {
                logger.LOG("自动翻译出错:" + e.Message);
            }
        }

    }
}
