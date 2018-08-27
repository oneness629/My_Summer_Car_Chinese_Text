using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using MSCTranslateChs.Script.Develop;
using MSCLoader;

namespace MSCTranslateChs.Script.Teleport
{
    
    public class Teleport
    {
        public bool isShowWindow = false;
        Rect windowsRect = new Rect(0, 0, 800, 600);

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

        Dictionary<string, string> targetPosition = new Dictionary<string, string>();


        public Teleport()
        {
            targetPosition.Add("SATSUMA", SATSUMA);
            targetPosition.Add("FERNDALE", FERNDALE);
            targetPosition.Add("GIFU", GIFU);
            targetPosition.Add("KEKMET", KEKMET);
            targetPosition.Add("HAYOSIKO", HAYOSIKO);
            targetPosition.Add("JONNEZ_ES", JONNEZ_ES);
            targetPosition.Add("RCO_RUSCKO12", RCO_RUSCKO12);
            targetPosition.Add("GRAVE_YARD_SPAWN", GRAVE_YARD_SPAWN);
            targetPosition.Add("SPAWN_TO_STORE", SPAWN_TO_STORE);
            targetPosition.Add("SPAWN_TO_REPAIR", SPAWN_TO_REPAIR);
            targetPosition.Add("SPAWN_TO_DRAG", SPAWN_TO_DRAG);
            targetPosition.Add("SPAWN_TO_COTTAGE", SPAWN_TO_COTTAGE);
            targetPosition.Add("SPAWN_TO_VENTTI_PIG", SPAWN_TO_VENTTI_PIG);
        }

        public void Update()
        {
            if (isShowWindow)
            {
                windowsRect = GUI.Window(2, windowsRect, TeleportWindowFunction, "远程传送");
            }
        }

        public void TeleportWindowFunction(int windowsId)
        {
            GUILayout.Label("远程传送功能：");
            GUILayout.Label("将玩家/特定车辆 传送到特定位置（玩家/特定车辆）附近");
            GUILayout.Label("注意：如果传送玩家到特定位置，请不要坐在车内，否则···");
            GUILayout.Label(" ");
            GUILayout.Label("传送到玩家");
            GUILayout.BeginHorizontal("box");
            string playerTargetName = PLAYER.Split('|')[0];
            foreach (string key in targetPosition.Keys)
            {
                string view = targetPosition[key].Split('|')[1];
                string targetName = targetPosition[key].Split('|')[0];
                if (GUILayout.Button(view))
                {
                    TeleportTo(targetName, playerTargetName);
                }
            }
            GUILayout.EndHorizontal();
            GUILayout.Label(" ");
            GUILayout.Label("传送到目标");
            GUILayout.BeginHorizontal("box");
            foreach (string key in targetPosition.Keys)
            {
                string view = targetPosition[key].Split('|')[1];
                string targetName = targetPosition[key].Split('|')[0];
                if (GUILayout.Button(view))
                {
                    TeleportTo(playerTargetName, targetName);
                }
            }
            GUILayout.EndHorizontal();
            if (GUILayout.Button("关闭"))
            {
                isShowWindow = false;
            }

            GUI.DragWindow(new Rect(0, 0, 9999 ,9999));
        }

        public void TeleportTo(string teleportObjectName, string targetObjectName)
        {
            ModConsole.Print("远程传送 " + teleportObjectName + " 到 " + targetObjectName);
            GameObject targetGameObject = GameObject.Find(targetObjectName);
            if (targetGameObject == null)
            {
                ModConsole.Print("无法找到目标:" + targetObjectName);
                return;
            }

            Vector3 position = new Vector3(targetGameObject.transform.position.x + 3f, targetGameObject.transform.position.y, targetGameObject.transform.position.z);
            GameObject teleportObject = GameObject.Find(teleportObjectName);
            if (teleportObjectName == null)
            {
                ModConsole.Print("无法找到要传送的目标:" + teleportObjectName);
                return;
            }
            teleportObject.transform.position = position;
        }
    }

   
}
