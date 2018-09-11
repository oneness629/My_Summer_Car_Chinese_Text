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
        public static readonly string BOLT_COUNT = "bolt_count";
        public static readonly string PART_AND_BOLT = "part_and_bolt";

        public override string ModuleComment { get => "车辆报告"; }
        

        public bool isShowWindow = false;

        Rect windowsRect;
        Vector2 scrollPoint;
        public float windowsWidth = 800;
        public float windowsHeight = 600;

        // 名称（车辆/引擎） 对应部件和螺栓
        public static Dictionary<string, Dictionary<string, object>> reportDict = new Dictionary<string, Dictionary<string, object>>();

        public override void Init()
        {
            windowsRect = new Rect(Screen.width / 2 - windowsWidth / 2, Screen.height / 2 - windowsHeight / 2, windowsWidth, windowsHeight);
        }

        public override void OnGUI()
        {
            if (isShowWindow)
            {
                windowsRect = GUI.Window(GlobalVariables.windowsIdByCarReport, windowsRect, WindowFunction, "车辆报告");
            }
        }

        public override void Update()
        {
            SetCheckGameObjectList(out List<GameObject> checkGameObjectList);
            foreach (GameObject rootGameObject in checkGameObjectList)
            {
                string name = GetShowRootGameObjectName(rootGameObject);
                Dictionary<string, object> partAndBoltDict = null;

                if (!reportDict.ContainsKey(name))
                {
                    partAndBoltDict = new Dictionary<string, object>();
                    reportDict.Add(name, partAndBoltDict);
                }
                else
                {
                    partAndBoltDict = reportDict[name];
                }
                

                List<GameObject> allBoltPmGameObjectList = GameObjectUtil.GetChildGameObjectLikeName(rootGameObject, "boltpm");
                if (partAndBoltDict.ContainsKey(CarReport.BOLT_COUNT))
                {
                    partAndBoltDict[CarReport.BOLT_COUNT] = allBoltPmGameObjectList.Count;
                }
                else
                {
                    partAndBoltDict.Add(CarReport.BOLT_COUNT, allBoltPmGameObjectList.Count);
                }


                // 部件GameObject -> 螺栓GameObject List
                Dictionary<GameObject, List<GameObject>> partDict = new Dictionary<GameObject, List<GameObject>>();
                if (partAndBoltDict.ContainsKey(CarReport.PART_AND_BOLT))
                {
                    partAndBoltDict[CarReport.PART_AND_BOLT] = partDict;
                }
                else
                {
                    partAndBoltDict.Add(CarReport.PART_AND_BOLT, partDict);
                }


                foreach (GameObject booltPmGameObject in allBoltPmGameObjectList)
                {
                    FsmGameObject partFsmGameObject = GameObjectUtil.GetPlayMakerFSMGameObject(booltPmGameObject, "screw", "PartAssembled");
                    if (partFsmGameObject != null && partFsmGameObject.Value != null)
                    {
                        if (partDict.ContainsKey(partFsmGameObject.Value))
                        {
                            partDict[partFsmGameObject.Value].Add(booltPmGameObject);
                        }
                        else
                        {
                            partDict.Add(partFsmGameObject.Value , new List<GameObject>() { booltPmGameObject });
                        }
                    }
                }


            }

        }



        public void WindowFunction(int windowsId)
        {
            scrollPoint = GUILayout.BeginScrollView(scrollPoint);
            if (GUILayout.Button("关闭"))
            {
                isShowWindow = false;
            }

            foreach (string name in reportDict.Keys)
            {
                GUILayout.Label("");
                GUILayout.Label(name);
                if (reportDict.ContainsKey(name))
                {
                    Dictionary<string, object> partAndBoltDict = reportDict[name] as Dictionary<string, object>;
                    if (partAndBoltDict.ContainsKey(CarReport.BOLT_COUNT) && partAndBoltDict.ContainsKey(CarReport.PART_AND_BOLT))
                    {
                        int boltCount = Convert.ToInt16(partAndBoltDict[CarReport.BOLT_COUNT]);
                        Dictionary<GameObject, List<GameObject>> partDict = partAndBoltDict[CarReport.PART_AND_BOLT] as Dictionary<GameObject, List<GameObject>>;

                        GUILayout.Label("已安装部件一共有个" + boltCount + "螺栓/丝");

                        foreach (GameObject partGameObject in partDict.Keys)
                        {
                            GUILayout.Label("部件名称:" + partGameObject.name);
                            List<GameObject> boltPmGameObjectList = partDict[partGameObject];
                            if (boltPmGameObjectList != null)
                            {
                                GUILayout.Label("该部件有" + boltPmGameObjectList .Count + "个螺栓/丝");
                            }
                            else
                            {
                                GUILayout.Label("该部件没有螺栓/丝");
                            }

                        }

                    }
                }
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
