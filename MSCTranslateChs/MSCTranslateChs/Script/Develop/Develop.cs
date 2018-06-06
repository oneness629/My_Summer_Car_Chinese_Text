using HutongGames.PlayMaker;
using MSCLoader;
using MSCTranslateChs.Script.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MSCTranslateChs.Script.Develop
{
    public class Develop
    {
        MSCTranslateChs mscTranslateChs;

        DevelopConfigWindows developConfigWindows;

        GUIStyle guiStyle;

        bool isDevelop = false;

        public bool isShowDevelopConfigWindows = false;

        public bool isRayGameObject = false;

        public bool isRayUIGameObject = false;

        public Develop(MSCTranslateChs mscTranslateChs)
        {
            guiStyle = new GUIStyle();
            guiStyle.alignment = TextAnchor.LowerLeft;
            guiStyle.fontSize = (int)(14.0f * (float)(Screen.width) / 1000f);
            guiStyle.normal.textColor = new Color(255, 255, 255);

            this.mscTranslateChs = mscTranslateChs;
            developConfigWindows = new DevelopConfigWindows(this);
        }

        public void Update()
        {
            if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.T))
            {
                isDevelop = true;
                isShowDevelopConfigWindows = true;
            }
            if (Input.GetKey(KeyCode.RightAlt) && Input.GetKey(KeyCode.T))
            {
                isDevelop = false;
                isShowDevelopConfigWindows = false;
            }
            if (isShowDevelopConfigWindows)
            {
                developConfigWindows.Update();
            }
            if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.W))
            {
                WriteGameObject("Systems");
                ModConsole.Print("write systems object ");
            }

            if (isDevelop)
            {
                GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "MSCTranslateChs开发模式 ", guiStyle);

                if (isRayGameObject)
                {
                    RayGameObject();
                }
                if (isRayUIGameObject)
                {
                    // 没用，游戏应该没用到UGUI组件
                    RayUIGameObject();
                }
            }
        }

        private void RayGameObject()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit[] raycastHits = Physics.RaycastAll(ray);
            if (raycastHits != null && raycastHits.Length > 0)
            {
                string text = "GameObject检测->鼠标位置(" + Input.mousePosition + ")对应的Object（"+ raycastHits.Length+ "） : \n";
                foreach (RaycastHit hitInfo in raycastHits)
                {
                    GameObject gameObject = hitInfo.collider.gameObject;
                    text += GameObjectUtil.getGameObjectText(gameObject);
                    if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.F))
                    {
                        WriteGameObject(gameObject);
                    }
                }
                
                GUI.Label(new Rect(Input.mousePosition.x, (-Input.mousePosition.y), Screen.width, Screen.height), text, guiStyle);
            }
        }


        private void RayUIGameObject()
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                string text = "UI GameObject检测->鼠标位置(" + Input.mousePosition + ") 触摸到UI组件 : \n";

                GUI.Label(new Rect(Input.mousePosition.x, (-Input.mousePosition.y), Screen.width, Screen.height), text, guiStyle);

                text = "UI GameObject检测->鼠标位置(" + Input.mousePosition + ")对应的Object : \n";

                PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
                eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                List<RaycastResult> results = new List<RaycastResult>();
                EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

                if (results != null && results.Count > 0)
                {
                    foreach (RaycastResult raycastResult in results)
                    {
                        text += "\t name : " + raycastResult.gameObject.name + "\n";
                    }
                }
                GUI.Label(new Rect(Input.mousePosition.x, (-Input.mousePosition.y), Screen.width, Screen.height), text, guiStyle);
            }
        }



        private void WriteGameObject(string path)
        {
            string text = GameObjectUtil.getGameObjectText(path, 0, false, true, false, false, false);
            File.WriteAllText(Path.Combine(ModLoader.GetModAssetsFolder(mscTranslateChs), "singleGameObject.txt"), text);
        }

        private void WriteGameObject(GameObject gameObject)
        {
            string text = GameObjectUtil.getGameObjectText(gameObject,0,false,true);
            File.WriteAllText(Path.Combine(ModLoader.GetModAssetsFolder(mscTranslateChs), "singleGameObject.txt"), text);
        }

        

       

        
    }

}
