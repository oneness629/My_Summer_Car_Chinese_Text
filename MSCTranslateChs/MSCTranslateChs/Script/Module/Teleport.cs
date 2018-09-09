using System;
using System.Collections.Generic;
using UnityEngine;
using MSCTranslateChs.Script.Common;
using MSCTranslateChs.Script.Module.Base;

namespace MSCTranslateChs.Script.Module
{
    
    public class Teleport : BaseModule
    {
        private static LOGGER logger = new LOGGER(typeof(Teleport));
        public override string ModuleComment { get => "远程传送"; }

        public bool isShowWindow = false;
        Rect windowsRect;
        Vector2 scrollPoint;
        readonly float windowsWidth = 300;
        readonly float windowsHeight = 700;

        public const String PLAYER = "PLAYER|玩家";
        public const String SATSUMA = "SATSUMA(557kg, 248)|拼装车";
        public const String FERNDALE = "FERNDALE(1630kg)|肌肉车";
        public const String GIFU = "GIFU(750/450psi)|污水车";
        public const String KEKMET = "KEKMET(350-400psi)|拖拉机";
        public const String HAYOSIKO = "HAYOSIKO(1500kg, 250)|面包车";
        public const String JONNEZ_ES = "JONNEZ ES(Clone)|摩托车";
        public const String RCO_RUSCKO12 = "RCO_RUSCKO12(270)|猪人车";

        public const String GRAVE_YARD_SPAWN = "GraveYardSpawn|玩家家";
        public const String SPAWN_TO_STORE = "SpawnToStore|商店";
        public const String SPAWN_TO_REPAIR = "SpawnToRepair|修车店";
        public const String SPAWN_TO_DRAG = "SpawnToDrag|直线加速赛场";
        public const String SPAWN_TO_COTTAGE = "SpawnToCottage|湖心小屋";
        public const String SPAWN_TO_VENTTI_PIG = "SpawnToVenttiPig|猪人家";
        public const String LANDFILL_SPAWN = "LandfillSpawn|垃圾场";
        public const String SPAWN_TO_DANCE = "SpawnToDance|舞会场";

        Dictionary<string, string> targetDynamicPosition = new Dictionary<string, string>();
        Dictionary<string, string> targetStaticPosition = new Dictionary<string, string>();
        string targetGameObjectText = "";

        public override void Init()
        {

            windowsRect = new Rect(Screen.width - windowsWidth, Screen.height - windowsHeight , windowsWidth, windowsHeight);
            targetDynamicPosition.Clear();
            targetDynamicPosition.Add("SATSUMA", SATSUMA);
            targetDynamicPosition.Add("FERNDALE", FERNDALE);
            targetDynamicPosition.Add("GIFU", GIFU);
            targetDynamicPosition.Add("KEKMET", KEKMET);
            targetDynamicPosition.Add("HAYOSIKO", HAYOSIKO);
            targetDynamicPosition.Add("JONNEZ_ES", JONNEZ_ES);
            targetDynamicPosition.Add("RCO_RUSCKO12", RCO_RUSCKO12);
            targetStaticPosition.Clear();
            targetStaticPosition.Add("GRAVE_YARD_SPAWN", GRAVE_YARD_SPAWN);
            targetStaticPosition.Add("SPAWN_TO_STORE", SPAWN_TO_STORE);
            targetStaticPosition.Add("SPAWN_TO_REPAIR", SPAWN_TO_REPAIR);
            targetStaticPosition.Add("SPAWN_TO_DRAG", SPAWN_TO_DRAG);
            targetStaticPosition.Add("SPAWN_TO_COTTAGE", SPAWN_TO_COTTAGE);
            targetStaticPosition.Add("SPAWN_TO_VENTTI_PIG", SPAWN_TO_VENTTI_PIG);
            targetStaticPosition.Add("LANDFILL_SPAWN", LANDFILL_SPAWN);
            targetStaticPosition.Add("SPAWN_TO_DANCE", SPAWN_TO_DANCE);
        }

        public override void OnGUI()
        {
            if (isShowWindow)
            {
                windowsRect = GUI.Window(GlobalVariables.windowsIdByTeleport, windowsRect, TeleportWindowFunction, "远程传送");
            }
        }

        public override void Update()
        {

            int keyIndex = 1;
            foreach (string key in targetDynamicPosition.Keys)
            {
                string view = targetDynamicPosition[key].Split('|')[1];
                string targetName = targetDynamicPosition[key].Split('|')[0];
                view = "(左Alt+" + keyIndex + ")" + view;
                if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.Alpha0 + keyIndex))
                {
                    TeleportTo(targetName, GlobalVariables.GetGlobalVariables().gameObjectPalyer);
                }
                keyIndex++;
            }

            keyIndex = 1;
            foreach (string key in targetStaticPosition.Keys)
            {
                string view = targetStaticPosition[key].Split('|')[1];
                string targetName = targetStaticPosition[key].Split('|')[0];
                view = "(右Ctrl+" + keyIndex + ")" + view;
                if (Input.GetKey(KeyCode.RightControl) && Input.GetKey(KeyCode.Alpha0 + keyIndex))
                {
                    TeleportTo(GlobalVariables.GetGlobalVariables().gameObjectPalyer, targetName);
                }
                keyIndex++;
            }

            keyIndex = 1;
            foreach (string key in targetDynamicPosition.Keys)
            {
                string view = targetDynamicPosition[key].Split('|')[1];
                string targetName = targetDynamicPosition[key].Split('|')[0];
                view = "(右ALT+" + keyIndex + ")" + view;
                if (Input.GetKey(KeyCode.RightAlt) && Input.GetKey(KeyCode.Alpha0 + keyIndex))
                {
                    TeleportTo(GlobalVariables.GetGlobalVariables().gameObjectPalyer, targetName);
                }
                keyIndex++;
            }
        }

        public void TeleportWindowFunction(int windowsId)
        {
            scrollPoint = GUILayout.BeginScrollView(scrollPoint);

            GUILayout.Label("远程传送功能：");
            GUILayout.Label("将玩家/特定车辆 传送到特定位置（玩家/特定车辆）附近");
            GUILayout.Label("注意：如果传送玩家到特定位置，请不要坐在车内，否则···");
            GUILayout.Label("(之后可能会加是否在车内判断)");
            GUILayout.Label(" ");
            GUILayout.Label("传送到玩家");
            GUILayout.BeginVertical("box");

            int keyIndex = 1;
            foreach (string key in targetDynamicPosition.Keys)
            {
                string view = targetDynamicPosition[key].Split('|')[1];
                string targetName = targetDynamicPosition[key].Split('|')[0];
                view = "(左Alt+" + keyIndex + ")" + view;
                if (GUILayout.Button(view))
                {
                    TeleportTo(targetName, GlobalVariables.GetGlobalVariables().gameObjectPalyer);
                }
                keyIndex++;
            }
            GUILayout.EndVertical();
            GUILayout.Label(" ");
            GUILayout.Label("传送到目标");
            GUILayout.BeginVertical("box");

            keyIndex = 1;
            foreach (string key in targetStaticPosition.Keys)
            {
                string view = targetStaticPosition[key].Split('|')[1];
                string targetName = targetStaticPosition[key].Split('|')[0];
                view = "(右Ctrl+" + keyIndex + ")" + view;
                if (GUILayout.Button(view))
                {
                    TeleportTo(GlobalVariables.GetGlobalVariables().gameObjectPalyer, targetName);
                }
                keyIndex++;
            }
            keyIndex = 1;
            foreach (string key in targetDynamicPosition.Keys)
            {
                string view = targetDynamicPosition[key].Split('|')[1];
                string targetName = targetDynamicPosition[key].Split('|')[0];
                view = "(右ALT+" + keyIndex + ")" + view;
                if (GUILayout.Button(view))
                {
                    TeleportTo(GlobalVariables.GetGlobalVariables().gameObjectPalyer, targetName);
                }
                keyIndex++;
            }
            GUILayout.Label("自定义位置（GameObject名字边上，按~看日志）");
            targetGameObjectText = GUILayout.TextField(targetGameObjectText);
            if (GUILayout.Button("传送到" + targetGameObjectText))
            {
                TeleportTo(GlobalVariables.GetGlobalVariables().gameObjectPalyer, targetGameObjectText);
            }
            GUILayout.EndVertical();
            if (GUILayout.Button("关闭"))
            {
                isShowWindow = false;
            }
            GUILayout.EndScrollView();
            GUI.DragWindow();
        }

        public void TeleportTo(string targetObjectName)
        {
            TeleportTo(GlobalVariables.GetGlobalVariables().gameObjectPalyer, targetObjectName);
        }

        public void TeleportTo(string teleportObjectName, string targetObjectName)
        {
            logger.LOG("远程传送 " + teleportObjectName + " 到 " + targetObjectName);
            GameObject targetGameObject = GameObject.Find(targetObjectName);
            if (targetGameObject == null)
            {
                logger.LOG("无法找到目标:" + targetObjectName);
                return;
            }
            GameObject teleportObject = GameObject.Find(teleportObjectName);
            if (teleportObject == null)
            {
                logger.LOG("无法找到要传送的目标:" + teleportObjectName);
                return;
            }
            TeleportTo(teleportObject, targetGameObject);
        }

        public void TeleportTo(GameObject teleportObject, string targetObjectName)
        {

            if (targetObjectName == null)
            {
                logger.LOG("无法找到传送的目标:" + targetObjectName);
                return;
            }
            GameObject targetObject = GameObject.Find(targetObjectName);
            TeleportTo(teleportObject, targetObject);
        }

        public void TeleportTo(string teleportObjectName, GameObject targetObject)
        {
            
            if (teleportObjectName == null)
            {
                logger.LOG("无法找到要传送的目标:" + teleportObjectName);
                return;
            }
            GameObject teleportObject = GameObject.Find(teleportObjectName);
            TeleportTo(teleportObject, targetObject);
        }

        public void TeleportTo(GameObject teleportObject, GameObject targetObject)
        {
            if (teleportObject == null || targetObject == null)
            {
                logger.LOG("远程传送传送/目标为空" + teleportObject + " / " + targetObject);
            }
            logger.LOG("远程传送 " + GameObjectUtil.GetGameObjectPath(teleportObject) + " 到 " + GameObjectUtil.GetGameObjectPath(targetObject));
            Vector3 position = new Vector3(targetObject.transform.position.x + 3f, targetObject.transform.position.y, targetObject.transform.position.z);
            teleportObject.transform.position = position;
        }
    }

   
}
