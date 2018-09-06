using HutongGames.PlayMaker;
using MSCLoader;
using MSCTranslateChs.Script;
using MSCTranslateChs.Script.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;


namespace MSCTranslateChs
{
    public class MSCTranslateChs : Mod
    {
        private static LOGGER logger = new LOGGER(typeof(MSCTranslateChs));

        public override string ID => "MSCTranslateChs";

        public override string Name => "MSCTranslateChs";

        public override string Author => "oneness629";

        public override string Version => "2.7";

        public override bool UseAssetsFolder => true;


        public GlobalVariables globalVariables;


        public bool IsLoadResources = false;
        public bool IsLoadGameObject = false;
        
        public bool IsDevelop = true;
        public bool isEnableTeleport = true;

        

       
        public bool isShowWelcomeWindows = true;

        bool isInitSystemsGameObject = false;

        

        public override void OnLoad()
        {
            try
            {

                IsLoadResources = false;
                IsLoadGameObject = false;

                develop = new Develop(this);
                welcomeWindows = new WelcomeWindows(this);
                itemTransmitter = new ItemTransmitter(this);


               

                IsLoadResources = true;
            }
            catch (Exception e)
            {
                logger.LOG("OnLoad Exception : " + e.Message);
                logger.LOG(e);
            }
        }

        public override void OnGUI()
        {
            executionTime.Start("OnGUI");
            try
            {
                if (IsLoadResources && IsLoadGameObject && Application.loadedLevelName == "GAME")
                {
                    if (IsEnable)
                    {
                        
                        executionTime.Start("Develop");
                        if (IsDevelop)
                        {
                            develop.Update();
                            
                        }
                        executionTime.End("Develop");
                    }
                    if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.W))
                    {
                        isShowWelcomeWindows = true;
                    }
                    if (Input.GetKey(KeyCode.RightAlt) && Input.GetKey(KeyCode.W))
                    {
                        isShowWelcomeWindows = false;
                    }
                    executionTime.Start("WelcomeWindows");
                    if (isShowWelcomeWindows)
                    {
                        welcomeWindows.Update();
                    }
                    executionTime.End("WelcomeWindows");
                    executionTime.Start("Teleport");
                    if (isEnableTeleport)
                    {
                        teleport.Update();
                    }
                    executionTime.End("Teleport");

                    if (money.isShowWindow)
                    {
                        money.OnGUI();
                    }
                    if (boltTip.isShowWindow)
                    {
                        boltTip.OnGUI();
                    }
                    executionTime.Start("物品传送(背包)");
                    itemTransmitter.OnGUI();
                    executionTime.End("物品传送(背包)");


                }
            }
            catch (Exception e)
            {
                logger.LOG("OnGUI Exception : " + e.Message);
                logger.LOG(e);
            }
            executionTime.End("OnGUI");
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
                        subtitlesTextMesh = GameObjectUtil.FindGameObjectTextMesh("GUI/Indicators/Subtitles");
                        partnamesTextMesh = GameObjectUtil.FindGameObjectTextMesh("GUI/Indicators/Partname");
                        interactionsTextMesh = GameObjectUtil.FindGameObjectTextMesh("GUI/Indicators/Interaction");

                        IsLoadGameObject = true;
                    }
                    catch (Exception e)
                    {
                        IsLoadGameObject = false;
                        logger.LOG("加载GameObject过程出现异常: " + e.Message);
                    }
                }

                if (itemTransmitter.isEnable)
                {
                    itemTransmitter.Update();
                }

            }
        }

        // Camera cameraMenu;

        

        

        

        Camera guiCamera;
        bool isInitGuiGameObject = false;

        

        


    }
}
