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

        public List<string> subtitlesList;
        public List<string> interactionsList;
        public List<string> partnamesList;

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
            IsLoadResources = true;
        }

        public override void OnGUI()
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
                return text;
            }
            string listText = textList.FirstOrDefault((string s) => s.ToUpper().Contains(text.Trim().ToUpper()));
            if (string.IsNullOrEmpty(listText))
            {
                textList.Add(text + "=" + notTranslateString);
                ModConsole.Print("文本在列表中未找到: " + text);
                    
            }
            string resultString = listText.Split('=')[1];
            resultString = resultString.Replace("\\n","\n");
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
