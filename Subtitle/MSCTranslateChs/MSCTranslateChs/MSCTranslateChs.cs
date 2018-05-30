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

                }
                else
                {
                    // load gameobject
                    subtitlesTextMesh = GameObject.Find("GUI/Indicators/Subtitles").GetComponent<TextMesh>();

                }
            }
        }


        public void Test()
        {
            try
            {
                GameObject[] pAllObjects = (GameObject[])Resources.FindObjectsOfTypeAll(typeof(GameObject));

                foreach (GameObject gameObject in pAllObjects)
                {
                    if (gameObject != null)
                    {
                        Transform parentTransform = gameObject.transform.parent;
                        if (parentTransform == null)
                        {
                            ModConsole.Print("topObjectList.Add(parentObj.name); : " + gameObject.name);
                        }
                        else
                        {
                            GameObject parentObj = parentTransform.gameObject;
                            if (parentObj == null)
                            {
                                ModConsole.Print("topObjectList game .Add(parentObj.name); : " + gameObject.name);
                            }
                        }
                        
                        ModConsole.Print("gameObject : " + gameObject.name + " activeSelf : " + gameObject.activeSelf);
                        log += ("gameObject name : " + gameObject.name + " activeSelf : " + gameObject.activeSelf + "\n");
                    }
                }
                WriteToText();
            }
            catch (Exception ex)
            {
                ModConsole.Print("error :" + ex);
            }
           
        }

        public void WriteToText()
        {
            
            // File.WriteAllLines(Path.Combine(ModLoader.GetModAssetsFolder(this), "partnames.txt"), m_PartNameList.ToArray());

            File.WriteAllLines(Path.Combine(ModLoader.GetModAssetsFolder(this), "topObjectList.txt"), topObjectList.ToArray());
            File.WriteAllText(Path.Combine(ModLoader.GetModAssetsFolder(this), "log.txt"), log);
            ModConsole.Print("writeToText");


        }
    }
}
