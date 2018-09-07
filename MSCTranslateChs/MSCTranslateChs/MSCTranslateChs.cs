using HutongGames.PlayMaker;
using MSCLoader;
using MSCTranslateChs.Script;
using MSCTranslateChs.Script.Common;
using MSCTranslateChs.Script.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using UnityEngine;

[assembly: AssemblyVersionAttribute("2.7")]
namespace MSCTranslateChs
{
    [ComVisible(false)]
    public class MSCTranslateChs : Mod
    {
        private static LOGGER logger = new LOGGER(typeof(MSCTranslateChs));

        public override string ID => "MSCTranslateChs";

        public override string Name => "MSCTranslateChs";

        public override string Author => "oneness629";

        public override string Version => "2.7";

        public override bool UseAssetsFolder => true;

        public bool IsEnable = true;

        public override void OnLoad()
        {
            try
            {
                GlobalVariables.GetGlobalVariables().Init();
            }
            catch (Exception e)
            {
                logger.LOG("OnLoad Exception : " + e.Message);
                logger.LOG(e);
            }
        }

        public override void OnGUI()
        {
            GlobalVariables.GetGlobalVariables().executionTime.Start("OnGUI");
            try
            {
                if (!GlobalVariables.GetGlobalVariables().isInit || Application.loadedLevelName != "GAME")
                {
                    return;
                }



                GlobalVariables.GetGlobalVariables().executionTime.Start("开发模式 OnGUI");
                if (GlobalVariables.GetGlobalVariables().develop.isEnable)
                {
                    GlobalVariables.GetGlobalVariables().develop.OnGUI();
                }
                GlobalVariables.GetGlobalVariables().executionTime.End("开发模式 OnGUI");

                GlobalVariables.GetGlobalVariables().executionTime.Start("欢迎窗口 OnGUI");
                if (GlobalVariables.GetGlobalVariables().welcomeWindows.isEnable)
                {
                    GlobalVariables.GetGlobalVariables().welcomeWindows.OnGUI();
                }
                GlobalVariables.GetGlobalVariables().executionTime.End("欢迎窗口 OnGUI");
                GlobalVariables.GetGlobalVariables().executionTime.Start("远程传送 OnGUI");
                if (GlobalVariables.GetGlobalVariables().teleport.isEnable)
                {
                    GlobalVariables.GetGlobalVariables().teleport.OnGUI();
                }
                GlobalVariables.GetGlobalVariables().executionTime.End("远程传送 OnGUI");
                GlobalVariables.GetGlobalVariables().executionTime.End("金钱调整 OnGUI");
                if (GlobalVariables.GetGlobalVariables().money.isEnable)
                {
                    GlobalVariables.GetGlobalVariables().money.OnGUI();
                }
                GlobalVariables.GetGlobalVariables().executionTime.End("金钱调整 OnGUI");
                if (GlobalVariables.GetGlobalVariables().boltTip.isEnable)
                {
                    GlobalVariables.GetGlobalVariables().boltTip.OnGUI();
                }
                GlobalVariables.GetGlobalVariables().executionTime.Start("物品传送 OnGUI");
                if (GlobalVariables.GetGlobalVariables().itemTransmitter.isEnable)
                {
                    GlobalVariables.GetGlobalVariables().itemTransmitter.OnGUI();
                }
                GlobalVariables.GetGlobalVariables().executionTime.End("物品传送 OnGUI");
            }
            catch (Exception e)
            {
                logger.LOG("OnGUI Exception : " + e.Message);
                logger.LOG(e);
            }
            GlobalVariables.GetGlobalVariables().executionTime.End("OnGUI");
        }

        

        public override void Update()
        {
            try
            {
                if (!GlobalVariables.GetGlobalVariables().isInit)
                {
                    GlobalVariables.GetGlobalVariables().Init();
                }


                GlobalVariables.GetGlobalVariables().executionTime.Start("欢迎窗口 Update");
                if (GlobalVariables.GetGlobalVariables().welcomeWindows.isEnable)
                {
                    GlobalVariables.GetGlobalVariables().welcomeWindows.Update();
                }
                GlobalVariables.GetGlobalVariables().executionTime.End("欢迎窗口 Update");


                GlobalVariables.GetGlobalVariables().executionTime.Start("物品传送 Update");
                if (GlobalVariables.GetGlobalVariables().itemTransmitter.isEnable)
                {
                    GlobalVariables.GetGlobalVariables().itemTransmitter.Update();
                }
                GlobalVariables.GetGlobalVariables().executionTime.End("物品传送 Update");

            }
            catch (Exception e)
            {
                logger.LOG("Update Exception: " + e.Message);
                logger.LOG(e);
            }
        }

    }
}
