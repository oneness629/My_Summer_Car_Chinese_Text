using System.Collections.Generic;
using UnityEngine;
using MSCTranslateChs.Script.Common;
using HutongGames.PlayMaker;
using MSCTranslateChs.Script.Common.Translate;
using MSCTranslateChs.Script.Module.Base;

namespace MSCTranslateChs.Script.Module
{

    public class ItemTransmitter : BaseModule
    {
        private static LOGGER logger = new LOGGER(typeof(ItemTransmitter));
        public new string moduleComment = "物品传送";

        public bool isShowWindow = false;
        public bool isEnable = true;
        Rect windowsRect;
        Vector2 scrollPoint;
        readonly float windowsWidth = 200;
        readonly float windowsHeight = Screen.height;

       
        public Dictionary<string, GameObject> itemDict = new Dictionary<string, GameObject>();
        public int selectItemKeyIndex = 0;
        public string selectItemKey;

        public override void Init()
        {
            windowsRect = new Rect(Screen.width - windowsWidth , 0, windowsWidth, windowsHeight);
        }


        public override void OnGUI()
        {
            if (isShowWindow)
            {
                windowsRect = GUI.Window(GlobalVariables.windowsIdByItemTransmitter, windowsRect, WindowFunction, "物品传送（背包）");
            }
        }


        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                GlobalVariables.GetGlobalVariables().itemTransmitter.isShowWindow = !GlobalVariables.GetGlobalVariables().itemTransmitter.isShowWindow;
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (GlobalVariables.GetGlobalVariables().physicsRaycast.mainCameraRaycastHits != null && GlobalVariables.GetGlobalVariables().physicsRaycast.mainCameraRaycastHits.Length > 0)
                {
                    foreach (RaycastHit hitInfo in GlobalVariables.GetGlobalVariables().physicsRaycast.mainCameraRaycastHits)
                    {
                        GameObject targetGameObject = hitInfo.collider.gameObject;
                        if (targetGameObject != null && CanPickUp(targetGameObject))
                        {
                            string partName = targetGameObject.name.Replace("(Clone)", "").Replace("(itemx)", "").Replace("(xxxxx)", "");
                            string text = partName + "(" + GlobalVariables.GetGlobalVariables().mscTranslate.translateText.TranslateString(partName, TranslateText.DICT_PARTNAME) + ")" + "|" + targetGameObject.GetInstanceID();
                            if (!itemDict.ContainsKey(text))
                            {
                                itemDict.Add(text, targetGameObject);
                            }
                            else
                            {
                                logger.LOG(targetGameObject + "已经在背包,不允许拾取(再次传送到垃圾堆)");
                            }
                            targetGameObject.transform.parent = null;
                            GlobalVariables.GetGlobalVariables().teleport.TeleportTo(targetGameObject, GlobalVariables.GetGlobalVariables().gameObjectLandfillSpawn);
                        }
                    }
                }
                

                float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
                int scrollWheelInt = 0;
                if (scrollWheel > 0)
                {
                    scrollWheelInt = -1;
                }
                else if(scrollWheel < 0)
                {
                    scrollWheelInt = 1;
                }
                selectItemKeyIndex += scrollWheelInt;
                if (itemDict.Keys.Count <= selectItemKeyIndex || selectItemKeyIndex < 0)
                {
                    selectItemKeyIndex = itemDict.Keys.Count - 1;
                }

                if (Input.GetKeyDown(KeyCode.R))
                {
                    if (itemDict.Count > 0 && selectItemKey != null && !"".Equals(selectItemKey))
                    {
                        logger.LOG("是否在菜单:" + GlobalVariables.GetGlobalVariables().fsmBoolPlayerInMenu.Value);
                        if (GlobalVariables.GetGlobalVariables().fsmBoolPlayerInMenu.Value)
                        {
                            GlobalVariables.GetGlobalVariables().teleport.TeleportTo(itemDict[selectItemKey], GlobalVariables.GetGlobalVariables().gameObjectPalyer);
                        }
                        else
                        {
                            TeleportToCamera(itemDict[selectItemKey]);
                        }
                        
                        itemDict.Remove(selectItemKey);
                        selectItemKey = null;
                        selectItemKeyIndex--;
                        if (selectItemKeyIndex < 0)
                        {
                            selectItemKeyIndex = 0;
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
            isEnable = GUILayout.Toggle(isEnable, "是否启用");
            GUILayout.Label("捡起/丢出物品:E/R");
            GUILayout.Label("切换选中 鼠标滚轮");
            int index = 0;
            foreach (string key in itemDict.Keys)
            {
                string view = key.Split('|')[0];
                if (index == selectItemKeyIndex)
                {
                    view = ("[" + view + "]");
                    this.selectItemKey = key;
                }
                if (GUILayout.Button(view))
                {
                    logger.LOG("是否在菜单:" + GlobalVariables.GetGlobalVariables().fsmBoolPlayerInMenu.Value);
                    GlobalVariables.GetGlobalVariables().teleport.TeleportTo(itemDict[key], GlobalVariables.GetGlobalVariables().gameObjectPalyer);
                    itemDict.Remove(key);
                }
                index++;
            }
            if (this.selectItemKey == null)
            {
                this.selectItemKeyIndex = 0;
            }
            GUILayout.EndScrollView();
            GUI.DragWindow();
        }

        public void TeleportToCamera(GameObject teleportObject)
        {
            logger.LOG("物品传送 " + teleportObject + " 到当前位置");
            if (teleportObject == null)
            {
                logger.LOG("传送物品或目标为空");
                return;
            }
            Vector3 position = Camera.main.transform.position + Camera.main.transform.forward * 1f;
            teleportObject.transform.position = position;
        }

        public bool CanPickUp(GameObject gameObject)
        {
            if (gameObject.layer != 16 && gameObject.layer != 19)
            {
                logger.LOG(gameObject + "在" + gameObject.layer + "层,不允许拾取");
                return false;
            }
            if (gameObject.GetComponent<Rigidbody>() == null)
            {
                logger.LOG(gameObject + "没有刚体,不允许拾取");
                return false;
            }
            PlayMakerFSM[] components = gameObject.GetComponents<PlayMakerFSM>();
            foreach (PlayMakerFSM playMakerFSM in components)
            {
                if (playMakerFSM.FsmName == "Data" || playMakerFSM.FsmName == "Use")
                {
                    FsmBool fsmBool = playMakerFSM.FsmVariables.FindFsmBool("Installed");
                    if (fsmBool != null && fsmBool.Value)
                    {
                        logger.LOG(gameObject + "物品已经安装");
                        return false;
                    }
                }
                if (playMakerFSM.FsmName == "BoltCheck")
                {
                    FsmFloat fsmFloat = playMakerFSM.FsmVariables.FindFsmFloat("Tightness");
                    if (fsmFloat != null && fsmFloat.Value > 0f)
                    {
                        logger.LOG(gameObject + "Tightness属性大于0");
                        return false;
                    }
                }
            }
            return true;
        }


    }

}
