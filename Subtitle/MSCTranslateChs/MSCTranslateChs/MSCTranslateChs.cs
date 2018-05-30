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

        private TextMesh subtitlesTextMesh;


        public override void OnLoad()
        {
            IsLoadResources = false;
            IsLoadGameObject = false;
            subtitlesList = File.ReadAllLines(Path.Combine(ModLoader.GetModAssetsFolder(this), "subtitles.txt")).ToList();
            interactionsList = File.ReadAllLines(Path.Combine(ModLoader.GetModAssetsFolder(this), "interactions.txt")).ToList();
            partnamesList = File.ReadAllLines(Path.Combine(ModLoader.GetModAssetsFolder(this), "partnames.txt")).ToList();
            IsLoadResources = true;
        }

        public override void OnGUI()
        {
            
        }


        public override void Update()
        {
            if (IsLoadResources && Application.loadedLevelName == "GAME")
            {
                if (IsLoadGameObject)
                {
                    ModConsole.Print(subtitlesTextMesh.text);
                }
                else
                {
                    // load gameobject
                    try
                    {
                        subtitlesTextMesh = FindGameObjectTextMesh("GUI/Indicators/Subtitles");
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

        
        public TextMesh FindGameObjectTextMesh(string path)
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
