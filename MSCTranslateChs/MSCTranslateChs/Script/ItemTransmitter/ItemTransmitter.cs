using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using MSCTranslateChs.Script.Develop;
using MSCLoader;
using MSCTranslateChs.Script.Common;
using MSCTranslateChs.Script.Translate;
using HutongGames.PlayMaker;

namespace MSCTranslateChs.Script.Teleport
{

    public class ItemTransmitter
    {
        private static LOGGER logger = new LOGGER(typeof(ItemTransmitter));

        MSCTranslateChs mscTranslateChs;

        public bool isShowWindow = false;
        public bool isEnable = true;
        public bool isInIt = false;
        Rect windowsRect;
        Vector2 scrollPoint;
        float windowsWidth = 200;
        float windowsHeight = Screen.height;
        int windowsId = 6296;

        public string landfillSpawnGameObjectName = "LandfillSpawn";
        public GameObject landfillSpawnGameObject;
        public Dictionary<string, GameObject> itemDict = new Dictionary<string, GameObject>();
        

        public ItemTransmitter(MSCTranslateChs mscTranslateChs)
        {
            this.mscTranslateChs = mscTranslateChs;
            windowsRect = new Rect(Screen.width - windowsWidth , 0, windowsWidth, windowsHeight);
        }


        public void OnGUI()
        {

            if (isShowWindow)
            {
                windowsRect = GUI.Window(windowsId, windowsRect, WindowFunction, "物品传送（背包）");
            }
            if (isEnable)
            {
                ItemProcessor();
            }
        }


        private void ItemProcessor()
        {
            if (!isInIt)
            {
                landfillSpawnGameObject = GameObject.Find(landfillSpawnGameObjectName);
                if (landfillSpawnGameObject == null)
                {
                    return;
                }
                isInIt = true;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {

                    if (Camera.main == null)
                    {
                        return;
                    }

                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit[] raycastHits = Physics.RaycastAll(ray, Mathf.Infinity);
                    if (raycastHits != null && raycastHits.Length > 0)
                    {
                        foreach (RaycastHit hitInfo in raycastHits)
                        {
                            GameObject targetGameObject = hitInfo.collider.gameObject;
                            if (targetGameObject != null && CanPickUp(targetGameObject))
                            {
                                string partName = targetGameObject.name.Replace("(Clone)", "").Replace("(itemx)", "").Replace("(xxxxx)", "");
                                string text = partName + "(" + mscTranslateChs.translateText.TranslateString(partName, TranslateText.DICT_PARTNAME) + ")" + "|" + targetGameObject.GetInstanceID();
                                if (!itemDict.ContainsKey(text))
                                {
                                    itemDict.Add(text, targetGameObject);
                                }
                                else
                                {
                                    logger.LOG(targetGameObject + "已经在背包,不允许拾取");
                                }
                                

                                targetGameObject.transform.parent = null;
                                TeleportTo(targetGameObject, landfillSpawnGameObject);
                            }
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
            GUILayout.Label("是否初始化 : " + isInIt);
            // GUILayout.Label("传送目标GameObject : " + landfillSpawnGameObject !=);

            foreach (string key in itemDict.Keys)
            {
                string view = key.Split('|')[0];
                if (GUILayout.Button(view))
                {
                    TeleportTo(itemDict[key]);
                    itemDict.Remove(key);
                }
            }
            GUILayout.EndScrollView();
            GUI.DragWindow();
        }

        public void TeleportTo(GameObject teleportObject, GameObject targetGameObject)
        {
            logger.LOG("物品传送 " + teleportObject + " 到 " + targetGameObject);
            if (targetGameObject == null || teleportObject == null)
            {
                logger.LOG("传送物品或目标为空");
                return;
            }
            Vector3 position = new Vector3(targetGameObject.transform.position.x + 0.5f, targetGameObject.transform.position.y, targetGameObject.transform.position.z);
            teleportObject.transform.position = position;
        }

        public void TeleportTo(GameObject teleportObject)
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
