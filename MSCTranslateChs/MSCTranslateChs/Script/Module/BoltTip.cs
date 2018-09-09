using System;
using System.Collections.Generic;
using UnityEngine;
using MSCTranslateChs.Script.Common;
using MSCTranslateChs.Script.Module.Base;
using HutongGames.PlayMaker;

namespace MSCTranslateChs.Script.Module
{

    public class BoltTip : BaseModule
    {
        private static readonly LOGGER logger = new LOGGER(typeof(BoltTip));
        public override string ModuleComment { get => "螺栓提示"; }

        public bool isShowWindow = false;

        Rect windowsRect;
        Vector2 scrollPoint;
        readonly float windowsWidth = 500;
        readonly float windowsHeight = 550;

        private GUIStyle mouseTipGuiStyle;

        public string defaultBoltMaterialName = "BOLTS";
        public string activeBoltMaterialName = "activebolt";
        public Material defaultBoltMaterial;
        public Material activeBoltMaterial;


        public override void Init()
        {
            windowsRect = new Rect(Screen.width / 2 - windowsWidth / 2, Screen.height / 2 - windowsHeight / 2, windowsWidth, windowsHeight);

            mouseTipGuiStyle = new GUIStyle()
            {
                alignment = TextAnchor.LowerLeft,
                fontSize = (int)(8.0f * (float)(Screen.width) / 1000f),
            };
            mouseTipGuiStyle.normal.textColor = new Color(255, 255, 255);

            Material[] materials = Resources.FindObjectsOfTypeAll<Material>();
            foreach (Material material in materials)
            {
                if (defaultBoltMaterialName.Equals(material.name))
                {
                    defaultBoltMaterial = material;
                }
                if (activeBoltMaterialName.Equals(material.name))
                {
                    activeBoltMaterial = material;
                }
            }
        }

        public override void OnGUI()
        {
            if (isShowWindow)
            {
                windowsRect = GUI.Window(GlobalVariables.windowsIdByBoltTip, windowsRect, WindowFunction, "螺栓提示");
            }
            if (IsEnable)
            {
                RayGameObject();
            }
        }

        public override void Update()
        {
        }


        private void RayGameObject()
        {
            

            if (GlobalVariables.GetGlobalVariables().physicsRaycast.mainCameraRaycastHits != null && GlobalVariables.GetGlobalVariables().physicsRaycast.mainCameraRaycastHits.Length > 0)
            {
                string text = "";
                foreach (RaycastHit hitInfo in GlobalVariables.GetGlobalVariables().physicsRaycast.mainCameraRaycastHits)
                {
                    GameObject targetGameObject = hitInfo.collider.gameObject;
                    if (GlobalVariables.GetGlobalVariables().gameObjectSatsumaName.Equals(targetGameObject.transform.root.gameObject.name))
                    {
                        Color heightLightColor = Color.yellow;
                        GameObject partAssembledGameObject = null;
                        FsmFloat fsmFloatTightness = null;
                        FsmFloat fsmFloatTireHealth = null;
                        FsmString fsmStringPart = null;
                        List<GameObject> allBoltPmGameObjectList = null;
                        if (targetGameObject.name.ToLower().IndexOf("boltpm") > -1)
                        {
                            PlayMakerFSM[] playMakerFSMArray = targetGameObject.GetComponents<PlayMakerFSM>();

                            foreach (PlayMakerFSM playMakerFSM in playMakerFSMArray)
                            {
                                if (playMakerFSM != null && playMakerFSM.FsmName != null && playMakerFSM.FsmName.ToLower().Equals("screw"))
                                {
                                    FsmGameObject fsmGameObject = playMakerFSM.FsmVariables.FindFsmGameObject("PartAssembled");
                                    if (fsmGameObject != null)
                                    {
                                        partAssembledGameObject = fsmGameObject.Value;
                                    }
                                }
                            }
                            GameObject parentGameObject = targetGameObject.transform.parent.gameObject;
                            if (parentGameObject != null)
                            {
                                allBoltPmGameObjectList = GameObjectUtil.GetChildGameObjectLikeName(parentGameObject, "boltpm");
                            }
                        }
                        if (partAssembledGameObject == null)
                        {
                            partAssembledGameObject = targetGameObject;
                        }
                        
                        PlayMakerFSM[] partAssembledPlayMakerFSMArray = partAssembledGameObject.GetComponents<PlayMakerFSM>();

                        foreach (PlayMakerFSM playMakerFSM in partAssembledPlayMakerFSMArray)
                        {
                            if (playMakerFSM != null && playMakerFSM.FsmName != null && 
                                    (
                                    playMakerFSM.FsmName.ToLower().Equals("use") ||
                                    playMakerFSM.FsmName.ToLower().Equals("boltcheck")
                                    )
                                )
                            {
                                fsmFloatTightness = playMakerFSM.FsmVariables.FindFsmFloat("Tightness");
                                fsmFloatTireHealth = playMakerFSM.FsmVariables.FindFsmFloat("TireHealth");
                            }
                            if (playMakerFSM != null && playMakerFSM.FsmName != null && playMakerFSM.FsmName.ToLower().Equals("paint"))
                            {
                                fsmStringPart = playMakerFSM.FsmVariables.FindFsmString("Part");
                            }
                        }
                        if (partAssembledGameObject == null || fsmFloatTightness == null) // || fsmFloatTireHealth == null || fsmStringPart == null)
                        {
                            text += "\n 取不到部件数据 路径 -> partAssembled:" + partAssembledGameObject + " Tightness:" + fsmFloatTightness + " TireHealth:" + fsmFloatTireHealth + " Part" + fsmStringPart +  "\n";
                            text += "\n -> " + GameObjectUtil.GetGameObjectPath(targetGameObject) + "\n";
                        }
                        else
                        {
                            text += "\n -> " + GameObjectUtil.GetGameObjectPath(targetGameObject) + "\n";
                            if (fsmStringPart == null)
                            {
                                text += "\n 部件名称 -> (GameObject)" + partAssembledGameObject.name.Replace("(Clone)", "").Replace("(itemx)", "").Replace("(xxxxx)", "") + "\n";
                            }
                            else
                            {
                                text += "\n 部件名称 -> (PART)" + fsmStringPart.Value + "\n";
                            }
                            if (fsmFloatTireHealth == null)
                            {
                                text += "\n 部件生命值 -> 无\n";
                            }
                            else
                            {
                                text += "\n 部件生命值 -> " + fsmFloatTireHealth.Value + "\n";
                            }
                            if (allBoltPmGameObjectList == null)
                            {
                                allBoltPmGameObjectList = GameObjectUtil.GetChildGameObjectLikeName(partAssembledGameObject, "boltpm");
                            }
                            
                            text += "\n 部件螺栓情况 -> " + fsmFloatTightness.Value + " -> ";
                            if (allBoltPmGameObjectList.Count * 8 == fsmFloatTightness.Value)
                            {
                                text += "已经锁紧";
                                heightLightColor = Color.yellow;
                            }
                            else
                            {
                                text += "尚未锁紧,请检查.";
                                heightLightColor = Color.red;
                            }
                            text += "\n一共应该有" + allBoltPmGameObjectList.Count + "个螺栓/丝";
                            text += "应该是" + Convert.ToInt32(Math.Round(targetGameObject.transform.localScale.x * 10)) + "号扳手";

                            foreach (GameObject gameObject in allBoltPmGameObjectList)
                            {
                                if (gameObject == targetGameObject)
                                {
                                    continue;
                                }
                                HeightLight(gameObject, heightLightColor);
                            }
                        }

                    }
                }
                GUI.Label(new Rect(Input.mousePosition.x, (-Input.mousePosition.y), Screen.width, Screen.height), text, mouseTipGuiStyle);
            }
            
        }

        public void HeightLight(GameObject gameObject, Color color){
            GameObject boltGameObject = GameObjectUtil.GetChildGameObjectLikeNameFirst(gameObject, "bolt");
            if (boltGameObject != null && Input.GetKey(KeyCode.LeftAlt))
            {

                GameObjectUtil.ChangeGameObjectMaterial(boltGameObject, activeBoltMaterial);
                GameObjectUtil.ChangeGameObjectColor(boltGameObject, color);
            }
            else
            {
                GameObjectUtil.ChangeGameObjectMaterial(boltGameObject, defaultBoltMaterial);
            }
        }

        public void WindowFunction(int windowsId)
        {
            scrollPoint = GUILayout.BeginScrollView(scrollPoint);
            if (GUILayout.Button("关闭"))
            {
                isShowWindow = false;
            }
            IsEnable = GUILayout.Toggle(IsEnable, "是否启用部件螺栓提示");
            GUILayout.Label("···应该没有人一直需要检查螺丝吧···");
            GUILayout.Label("···功能说明···");
            GUILayout.Label("1、鼠标移到螺丝上，能看到螺丝的扳手型号、部件下有几个螺丝");
            GUILayout.Label("2、鼠标移到螺丝上，按左边的ALT，能高亮标识出这个部件的其他螺丝");
            GUILayout.Label("3、鼠标移到到车上的任意位置（必须是车辆GameObject下面），能看到部件螺丝数量（什么部件？都是英文···我哪知道···）");
            GUILayout.Label("4、鼠标移到到车上的任意位置（必须是车辆GameObject下面），按下左边的ALT高亮显示部件下的螺丝");
            GUILayout.Label("5、我不能100%肯定该功能所有内容一定正确");
            GUILayout.Label("6、为了不影响太多帧数（应该影响不大），开着这个窗口，才能使用螺栓提示，把窗口拖到一个角落去···关了就没用了");
            
            if (GUILayout.Button("重置车辆中的所有螺栓/螺丝纹理"))
            {
                List<GameObject> boltGameObjectList = GameObjectUtil.FindChildGameObjectByLikeName(GlobalVariables.GetGlobalVariables().gameObjectSatsuma, "bolt");
                foreach (GameObject bolt in boltGameObjectList)
                {
                    GameObjectUtil.ChangeGameObjectMaterial(bolt, defaultBoltMaterial);
                }
            }

            GUILayout.Label("默认螺栓 : " + defaultBoltMaterial);
            GUILayout.Label("高亮螺栓 : " + activeBoltMaterial);

            GUILayout.EndScrollView();
            GUI.DragWindow();
        }

        
    }
   
}
