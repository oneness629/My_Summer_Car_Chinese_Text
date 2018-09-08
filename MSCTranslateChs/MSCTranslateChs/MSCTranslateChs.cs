using MSCLoader;
using MSCTranslateChs.Script;
using MSCTranslateChs.Script.Common;
using MSCTranslateChs.Script.Module.Base;
using System;
using System.Reflection;
using System.Runtime.InteropServices;
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

        public static string onGUITip = " OnGUI";
        public static string updateTip = " Update";

        public override void OnLoad()
        {
            try
            {
                GlobalVariables.GetGlobalVariables().mscTranslateChs = this;
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
                    logger.LOG("尚未初始化");
                    return;
                }

                GlobalVariables.GetGlobalVariables().executionTime.Start(GlobalVariables.GetGlobalVariables().welcomeWindows.ModuleComment + onGUITip);
                if (GlobalVariables.GetGlobalVariables().welcomeWindows.IsEnable)
                {
                    GlobalVariables.GetGlobalVariables().welcomeWindows.OnGUI();
                }
                GlobalVariables.GetGlobalVariables().executionTime.End(GlobalVariables.GetGlobalVariables().welcomeWindows.ModuleComment + onGUITip);

                if (!GlobalVariables.GetGlobalVariables().mscTranslateChs.IsEnable)
                {
                    return;
                }

                foreach (BaseModule baseModule in GlobalVariables.GetGlobalVariables().executeModuleList)
                {
                    GlobalVariables.GetGlobalVariables().executionTime.Start(baseModule.ModuleComment + onGUITip);
                    if (baseModule.IsEnable)
                    {
                        try
                        {
                            baseModule.OnGUI();
                        }
                        catch (Exception e)
                        {
                            logger.LOG(baseModule.ModuleComment + " OnGUI 中出现异常 -> " + e.Message);
                            logger.LOG(e);
                        }
                    }
                    GlobalVariables.GetGlobalVariables().executionTime.End(baseModule.ModuleComment + onGUITip);
                }
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
                if (!GlobalVariables.GetGlobalVariables().isInit || Application.loadedLevelName != "GAME")
                {
                    logger.LOG("尚未初始化,初始化中...");
                    GlobalVariables.GetGlobalVariables().Init();
                }


                GlobalVariables.GetGlobalVariables().executionTime.Start(GlobalVariables.GetGlobalVariables().welcomeWindows.ModuleComment + updateTip);
                GlobalVariables.GetGlobalVariables().welcomeWindows.Update();
                GlobalVariables.GetGlobalVariables().executionTime.Start(GlobalVariables.GetGlobalVariables().welcomeWindows.ModuleComment + updateTip);

                if (!GlobalVariables.GetGlobalVariables().mscTranslateChs.IsEnable)
                {
                    return;
                }
                foreach (BaseModule baseModule in GlobalVariables.GetGlobalVariables().executeModuleList)
                {
                    GlobalVariables.GetGlobalVariables().executionTime.Start(baseModule.ModuleComment + updateTip);
                    if (baseModule.IsEnable)
                    {
                        try
                        {
                            baseModule.Update();
                        }
                        catch (Exception e)
                        {
                            logger.LOG(baseModule.ModuleComment + " Update 中出现异常 -> " + e.Message);
                            logger.LOG(e);
                        }
                    }
                    GlobalVariables.GetGlobalVariables().executionTime.End(baseModule.ModuleComment + updateTip);
                }

            }
            catch (Exception e)
            {
                logger.LOG("Update Exception: " + e.Message);
                logger.LOG(e);
            }
        }

    }
}
