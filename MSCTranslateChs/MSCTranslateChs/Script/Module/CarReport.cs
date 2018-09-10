using System;
using System.Collections.Generic;
using UnityEngine;
using MSCTranslateChs.Script.Common;
using MSCTranslateChs.Script.Module.Base;
using HutongGames.PlayMaker;

namespace MSCTranslateChs.Script.Module
{

    public class CarReport : BaseModule
    {
        private static readonly LOGGER logger = new LOGGER(typeof(CarReport));
        public override string ModuleComment { get => "车辆报告"; }

        public bool isShowWindow = false;

        Rect windowsRect;
        Vector2 scrollPoint;
        public float windowsWidth = 800;
        public float windowsHeight = 600;

        public Dictionary<string, Dictionary<string, object>> reportDict = new Dictionary<string, Dictionary<string, object>>();

        public override void Init()
        {
            windowsRect = new Rect(Screen.width / 2 - windowsWidth / 2, Screen.height / 2 - windowsHeight / 2, windowsWidth, windowsHeight);
        }

        public override void OnGUI()
        {
            if (isShowWindow)
            {
                windowsRect = GUI.Window(GlobalVariables.windowsIdByBoltTip, windowsRect, WindowFunction, "车辆报告");
            }
        }

        public override void Update()
        {
            SetCheckGameObjectList(out List<GameObject> checkGameObjectList);
            foreach (GameObject rootGameObject in checkGameObjectList)
            {
                string name = GetShowRootGameObjectName(rootGameObject);
                Dictionary<string, object> dict = new Dictionary<string, object>();
                dict.Add(name, dict);

                List<GameObject> allBoltPmGameObjectList = GameObjectUtil.GetChildGameObjectLikeName(rootGameObject, "boltpm");

                dict.Add(CarReport.BOLT_COUNT);

            }

        }



        public void WindowFunction(int windowsId)
        {
            scrollPoint = GUILayout.BeginScrollView(scrollPoint);
            if (GUILayout.Button("关闭"))
            {
                isShowWindow = false;
            }
            
           
            GUILayout.EndScrollView();
            GUI.DragWindow();
        }

        private void SetCheckGameObjectList(out List<GameObject> checkGameObjectList)
        {
             checkGameObjectList = new List<GameObject>();
            if (GlobalVariables.GetGlobalVariables().gameObjectEngine == null)
            {
                logger.LOG("找不到玩家的引擎,要么装车上了,要么还没碰引擎基本组件");
            }
            else
            {
                checkGameObjectList.Add(GlobalVariables.GetGlobalVariables().gameObjectEngine);
            }
            if (GlobalVariables.GetGlobalVariables().gameObjectSatsuma == null)
            {
                logger.LOG("找不到玩家的车辆,什么?逗我吧...");
            }
            else
            {
                checkGameObjectList.Add(GlobalVariables.GetGlobalVariables().gameObjectSatsuma);
            }
        }

        private string GetShowRootGameObjectName(GameObject rootGameObject)
        {
            if (rootGameObject.name == GlobalVariables.GetGlobalVariables().gameObjectEngineName)
            {
                return "引擎";
            }
            else if (rootGameObject.name == GlobalVariables.GetGlobalVariables().gameObjectSatsumaName)
            {
                return "SATSUMA";
            }
            return "既不是引擎又不是SATSUMA,那是啥?";
        }
    }
   
}
