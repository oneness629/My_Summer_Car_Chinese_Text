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
        public MSCTranslateChs mscTranslateChs;

        DevelopConfigWindows developConfigWindows;

        public Teleport.Teleport teleport;

        public GUIStyle guiStyle;

        bool isDevelop = false;

        public bool isShowDevelopConfigWindows = false;

        public bool isRayGameObject = false;

        public bool isInitSystemsGameObject = false;

        public bool isRaySystemsGameObject = false;

        public Develop(MSCTranslateChs mscTranslateChs)
        {
            guiStyle = new GUIStyle();
            guiStyle.alignment = TextAnchor.LowerLeft;
            guiStyle.fontSize = (int)(14.0f * (float)(Screen.width) / 1000f);
            guiStyle.normal.textColor = new Color(255, 255, 255);

            this.mscTranslateChs = mscTranslateChs;
            developConfigWindows = new DevelopConfigWindows(this);
            teleport = new Teleport.Teleport();
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
            
            if (isDevelop)
            {
                GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "MSCTranslateChs开发模式", guiStyle);

                if (isRayGameObject)
                {
                    RayGameObject();
                }

                if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.W))
                {
                    WriteGameObject("Systems");
                    ModConsole.Print("write systems(UI) gameobject ");
                }

                teleport.Update();
            }
        }

        private void RayGameObject()
        {
            string textCamera = "";
            foreach (Camera c in Camera.allCameras)
            {

                textCamera += GameObjectUtil.getGameObjectPath(c.gameObject) + "\n";
                textCamera += "\t farClipPlane :  " + c.farClipPlane + "\n";
                textCamera += "\t nearClipPlane :  " + c.nearClipPlane + "\n";
                textCamera += "\t orthographic :  " + c.orthographic + "\n";
                textCamera += "\t pixelRect :  " + c.pixelRect + "\n";
                /*
                if (c.nearClipPlane < 100)
                {
                    c.nearClipPlane = 100;
                }
                */
                
            }
            textCamera += "current : " + Camera.current.name + "\n";
            textCamera += "main : " + Camera.main.name + "\n" + "\n";

            GUI.Label(new Rect(0, 0, Screen.width, Screen.height),textCamera, guiStyle);
            Camera camera = GameObject.Find("Systems/OptionsMenu/CAM").GetComponent<Camera>();
            // Camera camera = GameObject.Find("PLAYER/Pivot/Camera/FPSCamera/FPSCamera").GetComponent<Camera>();
            if (camera == null)
            {
                return;
            }
            // Ray ray = Camera.current.ScreenPointToRay(Input.mousePosition);
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            

            RaycastHit[] raycastHits = Physics.RaycastAll(ray, Mathf.Infinity, 1 << 14);
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


        private void WriteGameObject(string path)
        {
            string text = GameObjectUtil.getGameObjectText(path, 0, true, true, false, false, false);
            File.WriteAllText(Path.Combine(ModLoader.GetModAssetsFolder(mscTranslateChs), "singleGameObject.txt"), text);
        }

        private void WriteGameObject(GameObject gameObject)
        {
            string text = GameObjectUtil.getGameObjectText(gameObject,0, true, true);
            File.WriteAllText(Path.Combine(ModLoader.GetModAssetsFolder(mscTranslateChs), "singleGameObject.txt"), text);
        }

        

       

        
    }

}
