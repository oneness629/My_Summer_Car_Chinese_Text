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

        public static string OnGUITip = " OnGUI";
        public static string UpdateTip = " Update";

        public override void OnLoad()
        {
            try
            {
                GlobalVariables.GetGlobalVariables().mscTranslateChs = this;
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

                GlobalVariables.GetGlobalVariables().executionTime.Start(GlobalVariables.GetGlobalVariables().welcomeWindows.moduleComment + OnGUITip);
                if (GlobalVariables.GetGlobalVariables().welcomeWindows.isEnable)
                {
                    GlobalVariables.GetGlobalVariables().welcomeWindows.OnGUI();
                }
                GlobalVariables.GetGlobalVariables().executionTime.End(GlobalVariables.GetGlobalVariables().welcomeWindows.moduleComment + OnGUITip);

                if (!GlobalVariables.GetGlobalVariables().mscTranslateChs.IsEnable)
                {
                    return;
                }

                foreach (BaseModule baseModule in GlobalVariables.GetGlobalVariables().executeModuleList)
                {
                    GlobalVariables.GetGlobalVariables().executionTime.Start(baseModule.moduleComment + OnGUITip);
                    if (GlobalVariables.GetGlobalVariables().develop.isEnable)
                    {
                        baseModule.OnGUI();
                    }
                    GlobalVariables.GetGlobalVariables().executionTime.End(baseModule.moduleComment + OnGUITip);
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
                if (!GlobalVariables.GetGlobalVariables().isInit)
                {
                    GlobalVariables.GetGlobalVariables().Init();
                }


                GlobalVariables.GetGlobalVariables().executionTime.Start(GlobalVariables.GetGlobalVariables().welcomeWindows.moduleComment + UpdateTip);
                if (GlobalVariables.GetGlobalVariables().welcomeWindows.isEnable)
                {
                    GlobalVariables.GetGlobalVariables().welcomeWindows.Update();
                }
                GlobalVariables.GetGlobalVariables().executionTime.Start(GlobalVariables.GetGlobalVariables().welcomeWindows.moduleComment + UpdateTip);

                if (!GlobalVariables.GetGlobalVariables().mscTranslateChs.IsEnable)
                {
                    return;
                }
                foreach (BaseModule baseModule in GlobalVariables.GetGlobalVariables().executeModuleList)
                {
                    GlobalVariables.GetGlobalVariables().executionTime.Start(baseModule.moduleComment + UpdateTip);
                    if (GlobalVariables.GetGlobalVariables().develop.isEnable)
                    {
                        baseModule.Update();
                    }
                    GlobalVariables.GetGlobalVariables().executionTime.End(baseModule.moduleComment + UpdateTip);
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
