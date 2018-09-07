using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using MSCLoader;
using MSCTranslateChs.Script.Common;

namespace MSCTranslateChs.Script.Model
{
    
    public class Teleport
    {
        private static LOGGER logger = new LOGGER(typeof(Teleport));

        public bool isEnable = true;
        public bool isShowWindow = false;
        Rect windowsRect;
        Vector2 scrollPoint;
        readonly float windowsWidth = 300;
        readonly float windowsHeight = 700;
        int windowsId = 6292;

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

        public Teleport()
        {

            windowsRect = new Rect(Screen.width - windowsWidth, Screen.height - windowsHeight , windowsWidth, windowsHeight);

            targetDynamicPosition.Add("SATSUMA", SATSUMA);
            targetDynamicPosition.Add("FERNDALE", FERNDALE);
            targetDynamicPosition.Add("GIFU", GIFU);
            targetDynamicPosition.Add("KEKMET", KEKMET);
            targetDynamicPosition.Add("HAYOSIKO", HAYOSIKO);
            targetDynamicPosition.Add("JONNEZ_ES", JONNEZ_ES);
            targetDynamicPosition.Add("RCO_RUSCKO12", RCO_RUSCKO12);

            targetStaticPosition.Add("GRAVE_YARD_SPAWN", GRAVE_YARD_SPAWN);
            targetStaticPosition.Add("SPAWN_TO_STORE", SPAWN_TO_STORE);
            targetStaticPosition.Add("SPAWN_TO_REPAIR", SPAWN_TO_REPAIR);
            targetStaticPosition.Add("SPAWN_TO_DRAG", SPAWN_TO_DRAG);
            targetStaticPosition.Add("SPAWN_TO_COTTAGE", SPAWN_TO_COTTAGE);
            targetStaticPosition.Add("SPAWN_TO_VENTTI_PIG", SPAWN_TO_VENTTI_PIG);
            targetStaticPosition.Add("LANDFILL_SPAWN", LANDFILL_SPAWN);
            targetStaticPosition.Add("SPAWN_TO_DANCE", SPAWN_TO_DANCE);
        }

        public void OnGUI()
        {

            KeyBindFunction();

            if (isShowWindow)
            {
                windowsRect = GUI.Window(windowsId, windowsRect, TeleportWindowFunction, "远程传送");
            }
        }

        public void KeyBindFunction()
        {
            string playerTargetName = PLAYER.Split('|')[0];

            int keyIndex = 1;
            foreach (string key in targetDynamicPosition.Keys)
            {
                string view = targetDynamicPosition[key].Split('|')[1];
                string targetName = targetDynamicPosition[key].Split('|')[0];
                view = "(左Alt+" + keyIndex + ")" + view;
                if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.Alpha0 + keyIndex))
                {
                    TeleportTo(targetName, playerTargetName);
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
                    TeleportTo(playerTargetName, targetName);
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
                    TeleportTo(playerTargetName, targetName);
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
            string playerTargetName = PLAYER.Split('|')[0];

            int keyIndex = 1;
            foreach (string key in targetDynamicPosition.Keys)
            {
                string view = targetDynamicPosition[key].Split('|')[1];
                string targetName = targetDynamicPosition[key].Split('|')[0];
                view = "(左Alt+" + keyIndex + ")" + view;
                if (GUILayout.Button(view))
                {
                    TeleportTo(targetName, playerTargetName);
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
                    TeleportTo(playerTargetName, targetName);
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
                    TeleportTo(playerTargetName, targetName);
                }
                keyIndex++;
            }
            GUILayout.Label("自定义位置（GameObject名字边上，按~看日志）");
            targetGameObjectText = GUILayout.TextField(targetGameObjectText);
            if (GUILayout.Button("传送到" + targetGameObjectText))
            {
                TeleportTo(playerTargetName, targetGameObjectText);
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
            string playerTargetName = PLAYER.Split('|')[0];
            TeleportTo(playerTargetName, targetObjectName);
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

            Vector3 position = new Vector3(targetGameObject.transform.position.x + 3f, targetGameObject.transform.position.y, targetGameObject.transform.position.z);
            GameObject teleportObject = GameObject.Find(teleportObjectName);
            if (teleportObjectName == null)
            {
                logger.LOG("无法找到要传送的目标:" + teleportObjectName);
                return;
            }
            teleportObject.transform.position = position;
        }
    }

   
}
