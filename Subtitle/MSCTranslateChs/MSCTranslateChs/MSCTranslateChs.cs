using HutongGames.PlayMaker;
using MSCLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;


namespace MSCTranslateChs
{
    public class MSCTranslateChs : Mod
    {
        public override string ID => "MSCTranslateChs";

        public override string Name => "MSCTranslateChs";

        public override string Author => "oneness629";

        public override string Version => "1.0";

        public override bool UseAssetsFolder => true;

        public bool IsLoadResources = false;
        public bool IsLoadGameObject = false;

        public List<string> subtitlesList = new List<string>();
        public List<string> interactionsList = new List<string>();
        public List<string> partnamesList = new List<string>();

        private int subtitlesListSize = 0;
        private int interactionsListSize = 0;
        private int partnamesListSize = 0;

        private string notTranslateString = "未翻译文本";

        private TextMesh subtitlesTextMesh;
        private GUIStyle subtitlesGuiStyle;
        private Rect subtitlesRect;

        private TextMesh partnamesTextMesh;
        private GUIStyle partnamesGuiStyle;
        private Rect partnamesRect;




        public override void OnLoad()
        {
            IsLoadResources = false;
            IsLoadGameObject = false;

            subtitlesGuiStyle = new GUIStyle();
            subtitlesGuiStyle.alignment = TextAnchor.MiddleCenter;
            subtitlesGuiStyle.fontSize = (int)(14.0f * (float)(Screen.width) / 1000f);
            subtitlesGuiStyle.normal.textColor = new Color(255, 165, 0);

            subtitlesRect = new Rect(0, (Screen.height) / 2.6f, Screen.width, Screen.height);

            partnamesGuiStyle = subtitlesGuiStyle;

            partnamesRect = new Rect(0, (Screen.height) / 2.7f, Screen.width, Screen.height);

            subtitlesList = File.ReadAllLines(Path.Combine(ModLoader.GetModAssetsFolder(this), "subtitles.txt")).ToList();
            interactionsList = File.ReadAllLines(Path.Combine(ModLoader.GetModAssetsFolder(this), "interactions.txt")).ToList();
            partnamesList = File.ReadAllLines(Path.Combine(ModLoader.GetModAssetsFolder(this), "partnames.txt")).ToList();

            subtitlesListSize = subtitlesList.Count;
            interactionsListSize = interactionsList.Count;
            partnamesListSize = partnamesList.Count;

            ModConsole.Print("翻译文本列表数量");
            ModConsole.Print("subtitlesListSize :" + subtitlesListSize);
            ModConsole.Print("interactionsListSize :" + interactionsListSize);
            ModConsole.Print("partnamesListSize :" + partnamesListSize);

            IsLoadResources = true;
        }

        private void checkAndWriteTranslateText()
        {
            if (subtitlesListSize > 0 && subtitlesListSize < subtitlesList.Count)
            {
                File.WriteAllLines(Path.Combine(ModLoader.GetModAssetsFolder(this), "subtitles.txt"), subtitlesList.ToArray());
                subtitlesListSize = subtitlesList.Count;
                ModConsole.Print("新的未翻译文本已写入到subtitles.txt");
            }
            if (interactionsListSize > 0 && interactionsListSize < interactionsList.Count)
            {
                File.WriteAllLines(Path.Combine(ModLoader.GetModAssetsFolder(this), "interactions.txt"), interactionsList.ToArray());
                interactionsListSize = interactionsList.Count;
                ModConsole.Print("新的未翻译文本已写入到interactions.txt");
            }
            /*
            if (Input.GetKeyDown(KeyCode.L))
            {
                ModConsole.Print("partnamesListSize: " + partnamesListSize);
                ModConsole.Print("partnamesList.Count: " + partnamesList.Count);
                ModConsole.Print("partnamesListSize > 0: " + (partnamesListSize > 0));
                ModConsole.Print("partnamesListSize > partnamesList.Count : " + (partnamesListSize  partnamesList.Count));
                ModConsole.Print("partnamesListSize > 0 && partnamesListSize > partnamesList.Count : " + (partnamesListSize > 0 && partnamesListSize > partnamesList.Count));
                ModConsole.Print(partnamesListSize > 0 && partnamesListSize > partnamesList.Count);
            }
            */
            if (partnamesListSize > 0 && partnamesListSize < partnamesList.Count)
            {
                File.WriteAllLines(Path.Combine(ModLoader.GetModAssetsFolder(this), "partnames.txt"), partnamesList.ToArray());
                partnamesListSize = partnamesList.Count;
                ModConsole.Print("新的未翻译文本已写入到partnames.txt");
            }
        }

        public override void OnGUI()
        {
            try
            {
                if (IsLoadResources && IsLoadGameObject && Application.loadedLevelName == "GAME")
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
                    checkAndWriteTranslateText();
                }
            }
            catch(Exception e)
            {
                ModConsole.Print("GUI异常: " + e.Message);
            }
            
        }


        public override void Update()
        {
            if (IsLoadResources && Application.loadedLevelName == "GAME")
            {
                if (!IsLoadGameObject)
                {
                    // load gameobject
                    try
                    {
                        subtitlesTextMesh = FindGameObjectTextMesh("GUI/Indicators/Subtitles");
                        partnamesTextMesh = FindGameObjectTextMesh("GUI/Indicators/Partname");
                        IsLoadGameObject = true;
                    }
                    catch(Exception e)
                    {
                        IsLoadGameObject = false;
                        ModConsole.Print("加载GameObject过程出现异常: " + e.Message);
                    }
                }
            }
        }

        private string TranslateString(string text, List<string> textList)
        {
            if (string.IsNullOrEmpty(text))
            {
                return "\"\"";
            }
            string listText = textList.FirstOrDefault((string s) => s.ToUpper().Contains(text.Trim().ToUpper()));
            if (string.IsNullOrEmpty(listText))
            {
                textList.Add(text + "=" + notTranslateString);
                ModConsole.Print("文本在列表中未找到: " + text);
                return notTranslateString;
            }
            string resultString = listText.Split('=')[1];
            if (!string.IsNullOrEmpty(resultString))
            {
                resultString = resultString.Replace("\\n", "\n");
            }
            return resultString;


        }


        private TextMesh FindGameObjectTextMesh(string path)
        {
            GameObject gameObject = GameObject.Find(path);
            if (gameObject != null)
            {
                TextMesh textMesh = gameObject.GetComponent<TextMesh>();
                if (textMesh != null)
                {
                    return textMesh;
                }
            }
            throw new Exception("无法找到GameObject对应的TextMesh 路径->" + path);
        }

    }
}
