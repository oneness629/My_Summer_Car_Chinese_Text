using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using MSCTranslateChs.Script.Develop;
using MSCLoader;
using MSCTranslateChs.Script.Common;

namespace MSCTranslateChs.Script.Model
{

    public class BoltTip
    {
        private static LOGGER logger = new LOGGER(typeof(BoltTip));

        public bool isShowWindow = false;
        public bool isEnable = true;
        public bool isInIt = false;
        Rect windowsRect;
        Vector2 scrollPoint;
        float windowsWidth = 500;
        float windowsHeight = 550;
        int windowsId = 6295;

        private GUIStyle mouseTipGuiStyle;

        public const String SATSUMA = "SATSUMA(557kg, 248)";
        public GameObject satsumaGameObject;

        public string defaultBoltMaterialName = "BOLTS";
        public string activeBoltMaterialName = "activebolt";
        public Material defaultBoltMaterial;
        public Material activeBoltMaterial;


        public BoltTip()
        {
            windowsRect = new Rect(Screen.width / 2 - windowsWidth / 2, Screen.height / 2 - windowsHeight / 2, windowsWidth, windowsHeight);

            mouseTipGuiStyle = new GUIStyle();
            mouseTipGuiStyle.alignment = TextAnchor.LowerLeft;
            mouseTipGuiStyle.fontSize = (int)(8.0f * (float)(Screen.width) / 1000f);
            mouseTipGuiStyle.normal.textColor = new Color(255, 255, 255);
        }


        public void OnGUI()
        {

            if (isShowWindow)
            {
                windowsRect = GUI.Window(windowsId, windowsRect, WindowFunction, "螺栓提示");
            }
            if (isEnable)
            {
                RayGameObject();
            }
        }


        private void RayGameObject()
        {
            if (!isInIt)
            {
                satsumaGameObject = GameObject.Find(SATSUMA);
                if (satsumaGameObject == null)
                {
                    return;
                }
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
                isInIt = true;
            }
            else
            {
                if (Camera.main == null)
                {
                    return;
                }

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit[] raycastHits = Physics.RaycastAll(ray, Mathf.Infinity);
                if (raycastHits != null && raycastHits.Length > 0)
                {
                    string text = "";
                    foreach (RaycastHit hitInfo in raycastHits)
                    {
                        GameObject targetGameObject = hitInfo.collider.gameObject;
                        if (SATSUMA.Equals(targetGameObject.transform.root.gameObject.name))
                        {
                            
                            if (targetGameObject.name.ToLower().IndexOf("boltpm") > -1)
                            {
                                text += "\n" + GameObjectUtil.getGameObjectPath(targetGameObject) + "\n";
                                // Color changeColor = Color.yellow;
                                // string boltState = "未完全锁紧";
                                text += "应该是" + Convert.ToInt32(Math.Round(targetGameObject.transform.localScale.x * 10)) + "号扳手" + targetGameObject.transform.localRotation.ToString();
                                /*
                                PlayMakerFSM[] playMakerFSMArray =targetGameObject.GetComponents<PlayMakerFSM>();
                                foreach (PlayMakerFSM playMakerFSM in playMakerFSMArray)
                                {
                                    text += "\n" + playMakerFSM.name + playMakerFSM.FsmVariables
                                }
                                */
                                /*
                                if (
                                    /*
                                    targetGameObject.transform.localRotation.x.Equals(0f) &&
                                    targetGameObject.transform.localRotation.y.Equals(-0.7f) &&
                                    targetGameObject.transform.localRotation.z.Equals(0f) &&
                                    targetGameObject.transform.localRotation.w.Equals(-0.7f))
                                    * /
                                    targetGameObject.transform.localRotation.ToString().Equals("(0.0, -0.7, 0.0, -0.7)") )
                                {
                                    boltState = "已经锁紧";
                                    changeColor = Color.blue;
                                }
                                else if(
                                    /*
                                    targetGameObject.transform.localRotation.x.Equals(0f) &&
                                    targetGameObject.transform.localRotation.y.Equals(0.7f) &&
                                    targetGameObject.transform.localRotation.z.Equals(0f) &&
                                    targetGameObject.transform.localRotation.w.Equals(0.7f))
                                    * /
                                    targetGameObject.transform.localRotation.ToString().Equals("(0.0, 0.7, 0.0, 0.7)") )
                                {
                                    boltState = "完全松开";
                                    changeColor = Color.red;
                                }
                                text += boltState;
                                */
                                GameObject parentGameObject = targetGameObject.transform.parent.gameObject;
                                if (parentGameObject != null)
                                {
                                    List<GameObject> allBoltPmGameObjectList = GameObjectUtil.GetChildGameObjectLikeName(parentGameObject, "boltpm");
                                    text += "\n该部件一共应该有" + allBoltPmGameObjectList.Count + "个螺栓/丝";
                                    foreach (GameObject gameObject in allBoltPmGameObjectList)
                                    {
                                        if (gameObject == targetGameObject)
                                        {
                                            continue;
                                        }
                                        HeightLight(gameObject);
                                    }
                                }

                            }
                            else
                            {
                                List<GameObject> boltPmGameObjectList = GameObjectUtil.FindChildGameObjectByName(targetGameObject, "boltPM");
                                if (boltPmGameObjectList.Count > 0)
                                {
                                    text += "\n" + GameObjectUtil.getGameObjectPath(targetGameObject) + "\n";
                                    text += " 这个部件下面应该有" + boltPmGameObjectList.Count + "个螺栓/螺丝";
                                    foreach (GameObject boltPmGameObjec in boltPmGameObjectList)
                                    {
                                        HeightLight(boltPmGameObjec);
                                    }
                                }
                            }
                        }
                    }
                    GUI.Label(new Rect(Input.mousePosition.x, (-Input.mousePosition.y), Screen.width, Screen.height), text, mouseTipGuiStyle);
                }
            }
        }

        public void HeightLight(GameObject gameObject){
            GameObject boltGameObject = GameObjectUtil.GetChildGameObjectLikeNameFirst(gameObject, "bolt");
            if (boltGameObject != null && Input.GetKey(KeyCode.LeftAlt))
            {

                GameObjectUtil.ChangeGameObjectMaterial(boltGameObject, activeBoltMaterial);
                GameObjectUtil.ChangeGameObjectColor(boltGameObject, Color.yellow);
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
            isEnable = GUILayout.Toggle(isEnable, "是否启用部件螺栓提示");
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
                List<GameObject> boltGameObjectList = GameObjectUtil.FindChildGameObjectByLikeName(satsumaGameObject, "bolt");
                foreach (GameObject bolt in boltGameObjectList)
                {
                    GameObjectUtil.ChangeGameObjectMaterial(bolt, defaultBoltMaterial);
                }
            }

            GUILayout.Label("是否初始化 : " + isInIt);
            GUILayout.Label("车辆GameObject : " + satsumaGameObject);
            GUILayout.Label("默认螺栓 : " + defaultBoltMaterial);
            GUILayout.Label("高亮螺栓 : " + activeBoltMaterial);

            GUILayout.EndScrollView();
            GUI.DragWindow();
        }

    }
   
}
