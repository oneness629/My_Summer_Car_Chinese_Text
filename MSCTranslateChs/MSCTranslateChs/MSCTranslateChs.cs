using HutongGames.PlayMaker;
using MSCLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;


namespace MSCTranslateChs
{
    public class MSCTranslateChs  Mod
    {
        public override string ID = MSCTranslateChs;

        public override string Name = MSCTranslateChs;

        public override string Author = oneness629;

        public override string Version = 2.1;

        public override bool UseAssetsFolder = true;

        public bool IsLoadResources = false;
        public bool IsLoadGameObject = false;

        public Liststring subtitlesList = new Liststring();
        public Liststring interactionsList = new Liststring();
        public Liststring partnamesList = new Liststring();

        private int subtitlesListSize = 0;
        private int interactionsListSize = 0;
        private int partnamesListSize = 0;

        private string notTranslateString = [未翻译文本];
        private string autoTranslateStringing = [自动翻译中 ... ];
        private string autoTranslateString = [自动翻译];

        private TextMesh subtitlesTextMesh;
        private GUIStyle subtitlesGuiStyle;
        private Rect subtitlesRect;

        private TextMesh partnamesTextMesh;
        private GUIStyle partnamesGuiStyle;
        private Rect partnamesRect;

        private TextMesh interactionsTextMesh;
        private GUIStyle interactionsGuiStyle;
        private Rect interactionsRect;

        private Develop develop;

        private bool isEnableAutoTranslateApi = false;
        private string autoTranslateApiAppId;
        private string autoTranslateApiApikey;

        private TranslateApi translateApi;


        public override void OnLoad()
        {
            IsLoadResources = false;
            IsLoadGameObject = false;

            develop = new Develop(this);

            subtitlesGuiStyle = new GUIStyle();
            subtitlesGuiStyle.alignment = TextAnchor.MiddleCenter;
            subtitlesGuiStyle.fontSize = (int)(14.0f  (float)(Screen.width)  1000f);
            subtitlesGuiStyle.normal.textColor = new Color(255, 165, 0);

            subtitlesRect = new Rect(0, (Screen.height)  2.15f, Screen.width, Screen.height);


            partnamesGuiStyle = subtitlesGuiStyle;

            partnamesRect = new Rect(0, (Screen.height)  2.4f, Screen.width, Screen.height);

            interactionsGuiStyle = new GUIStyle();
            interactionsGuiStyle.alignment = TextAnchor.MiddleCenter;
            interactionsGuiStyle.fontSize = (int)(14.0f  (float)(Screen.width)  1000f);
            interactionsGuiStyle.normal.textColor = new Color(255, 255, 255);

            interactionsRect = new Rect(0, (Screen.height)  12f, Screen.width, Screen.height);

            ReadTranslateText();

            IsLoadResources = true;
        }

        private void ReadTranslateText()
        {
            Liststring configList = File.ReadAllLines(Path.Combine(ModLoader.GetModAssetsFolder(this), config.txt)).ToList();
            isEnableAutoTranslateApi = false;
            autoTranslateApiAppId = TranslateString(autoTranslateApi_AppId, configList);
            autoTranslateApiApikey = TranslateString(autoTranslateApi_Apikey, configList);
            isEnableAutoTranslateApi = TranslateString(isEnableAutoTranslateApi, configList).ToLower() == true;

            ModConsole.Print(自动翻译API启用状态  + isEnableAutoTranslateApi);
            ModConsole.Print(自动翻译API appid  + autoTranslateApiAppId);
            ModConsole.Print(自动翻译API apikey  + autoTranslateApiApikey);
            if (isEnableAutoTranslateApi)
            {
                ModConsole.Print(初始化自动翻译API);
                translateApi = new TranslateApi(autoTranslateApiAppId, autoTranslateApiApikey);
            }
            else
            {
                ModConsole.Print(不使用自动翻译API);
                translateApi = null;
            }

            subtitlesList = File.ReadAllLines(Path.Combine(ModLoader.GetModAssetsFolder(this), subtitles.txt)).ToList();
            interactionsList = File.ReadAllLines(Path.Combine(ModLoader.GetModAssetsFolder(this), interactions.txt)).ToList();
            partnamesList = File.ReadAllLines(Path.Combine(ModLoader.GetModAssetsFolder(this), partnames.txt)).ToList();

            subtitlesListSize = subtitlesList.Count;
            interactionsListSize = interactionsList.Count;
            partnamesListSize = partnamesList.Count;

            ModConsole.Print(翻译文本列表数量);
            ModConsole.Print(subtitlesListSize  + subtitlesListSize);
            ModConsole.Print(interactionsListSize  + interactionsListSize);
            ModConsole.Print(partnamesListSize  + partnamesListSize);
        }

        private void CheckAndWriteTranslateText()
        {
            if (subtitlesListSize  0 && subtitlesListSize  subtitlesList.Count)
            {
                File.WriteAllLines(Path.Combine(ModLoader.GetModAssetsFolder(this), subtitles.txt), subtitlesList.ToArray());
                subtitlesListSize = subtitlesList.Count;
                ModConsole.Print(新的未翻译文本已写入到subtitles.txt);
            }
            if (interactionsListSize  0 && interactionsListSize  interactionsList.Count)
            {
                File.WriteAllLines(Path.Combine(ModLoader.GetModAssetsFolder(this), interactions.txt), interactionsList.ToArray());
                interactionsListSize = interactionsList.Count;
                ModConsole.Print(新的未翻译文本已写入到interactions.txt);
            }
            if (partnamesListSize  0 && partnamesListSize  partnamesList.Count)
            {
                File.WriteAllLines(Path.Combine(ModLoader.GetModAssetsFolder(this), partnames.txt), partnamesList.ToArray());
                partnamesListSize = partnamesList.Count;
                ModConsole.Print(新的未翻译文本已写入到partnames.txt);
            }
        }

        private void NoCheckAndWriteTranslateText()
        {
            File.WriteAllLines(Path.Combine(ModLoader.GetModAssetsFolder(this), subtitles.txt), subtitlesList.ToArray());
            subtitlesListSize = subtitlesList.Count;
            ModConsole.Print(新的未翻译文本已写入到subtitles.txt);
            File.WriteAllLines(Path.Combine(ModLoader.GetModAssetsFolder(this), interactions.txt), interactionsList.ToArray());
            interactionsListSize = interactionsList.Count;
            ModConsole.Print(新的未翻译文本已写入到interactions.txt);
            File.WriteAllLines(Path.Combine(ModLoader.GetModAssetsFolder(this), partnames.txt), partnamesList.ToArray());
            partnamesListSize = partnamesList.Count;
            ModConsole.Print(新的未翻译文本已写入到partnames.txt);
        }

        public override void OnGUI()
        {
            try
            {
                if (IsLoadResources && IsLoadGameObject && Application.loadedLevelName == GAME)
                {
                    string subtitlesText = subtitlesTextMesh.text.Trim();
                    if (subtitlesTextMesh.gameObject.activeSelf && !string.IsNullOrEmpty(subtitlesText))
                    {
                        GUI.Label(subtitlesRect, TranslateString(subtitlesText, subtitlesList), subtitlesGuiStyle);
                    }
                    string partnamesText = partnamesTextMesh.text.Trim();
                    if (partnamesTextMesh.gameObject.activeSelf && !string.IsNullOrEmpty(partnamesText))
                    {
                        GUI.Label(partnamesRect, TranslateString(partnamesText, partnamesList), partnamesGuiStyle);
                    }
                    string interactionsText = interactionsTextMesh.text.Trim();
                    if (interactionsTextMesh.gameObject.activeSelf && !string.IsNullOrEmpty(interactionsText))
                    {
                        GUI.Label(interactionsRect, TranslateString(interactionsText, interactionsList), interactionsGuiStyle);
                    }


                    CheckAndWriteTranslateText();
                    develop.Update();

                    if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.R))
                    {
                        ReadTranslateText();
                    }
                }
            }
            catch(Exception e)
            {
                ModConsole.Print(GUI异常  + e.Message);
            }
            
        }


        public override void Update()
        {
            if (IsLoadResources && Application.loadedLevelName == GAME)
            {
                if (!IsLoadGameObject)
                {
                     load gameobject
                    try
                    {
                        subtitlesTextMesh = FindGameObjectTextMesh(GUIIndicatorsSubtitles);
                        partnamesTextMesh = FindGameObjectTextMesh(GUIIndicatorsPartname);
                        interactionsTextMesh = FindGameObjectTextMesh(GUIIndicatorsInteraction);
                        IsLoadGameObject = true;
                    }
                    catch(Exception e)
                    {
                        IsLoadGameObject = false;
                        ModConsole.Print(加载GameObject过程出现异常  + e.Message);
                    }
                }
            }
        }

        private string TranslateString(string text, Liststring textList)
        {
            if (string.IsNullOrEmpty(text))
            {
                return ;
            }
            string listText = textList.FirstOrDefault((string s) = s.ToUpper().Contains(text.Trim().ToUpper()));
            if (string.IsNullOrEmpty(listText))
            {
                ModConsole.Print(文本在列表中未找到  + text);
                if (isEnableAutoTranslateApi)
                {
                    ModConsole.Print(自动翻译文本 + text);
                    Dictionarystring, object data = new Dictionarystring, object();
                    data.Add(text, text);
                    data.Add(textList, textList);
                    data.Add(textListIndex, textList.Count);

                    Thread thread = new Thread(new ParameterizedThreadStart(this.AutoTranslateString));
                    thread.IsBackground = true;
                    thread.Start(data);
                    textList.Add(text + = + autoTranslateStringing);
                    return autoTranslateStringing;
                }
                else
                {
                    textList.Add(text + = + notTranslateString);
                    return notTranslateString;
                }
                
            }
            string resultString = listText.Split('=')[1];
            if (!string.IsNullOrEmpty(resultString))
            {
                resultString = resultString.Replace(n, n);
            }
            return resultString;
        }

        private void AutoTranslateString(object data)
        {
            try
            {
                Dictionarystring, object dict = data as Dictionarystring, object;
                if (dict.ContainsKey(text) && dict.ContainsKey(textList) && dict.ContainsKey(textListIndex))
                {
                    string text = dict[text] as string;
                    Liststring textList = dict[textList] as Liststring;
                    Int32 textIndex = (int) dict[textListIndex];

                    if (translateApi != null)
                    {
                        string result = translateApi.TranslationEnglishToChineseFromBaiduFanyi(text);
                        ModConsole.Print(自动翻译文本完成，替换目标文本 + textList[textIndex] + index   + textIndex);
                        ModConsole.Print(自动翻译文本 + result + index   + textIndex);
                        textList[textIndex] = text + = + autoTranslateString + result;
                        NoCheckAndWriteTranslateText();
                        ReadTranslateText();
                    }
                }
            }
            catch (Exception e)
            {
                ModConsole.Print(AutoTranslateString Error   + e.Message);
            }
            
        }

        private TextMesh FindGameObjectTextMesh(string path)
        {
            GameObject gameObject = GameObject.Find(path);
            if (gameObject != null)
            {
                TextMesh textMesh = gameObject.GetComponentTextMesh();
                if (textMesh != null)
                {
                    return textMesh;
                }
            }
            throw new Exception(无法找到GameObject对应的TextMesh 路径- + path);
        }

    }
}
