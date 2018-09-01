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

        private static LOGGER logger = new LOGGER(typeof(Develop));

        public MSCTranslateChs mscTranslateChs;

        DevelopConfigWindows developConfigWindows;

        public GuiGameObjectExplorer guiGameObjectExplorer;

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
            guiGameObjectExplorer = new GuiGameObjectExplorer(this);


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

                if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.R))
                {
                    mscTranslateChs.translateText.ReadTranslateTextDict();
                }

                if (isRayGameObject)
                {
                    RayGameObject();
                }

                if (guiGameObjectExplorer.isShow)
                {
                    guiGameObjectExplorer.OnGUI();
                }

                if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.W))
                {
                    WriteGameObject("Systems");
                    logger.LOG("写入所有Systems路径下的GameObject到txt");
                }
                if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.F))
                {
                    string[] text = { FsmVariablesUtil.getAllFsmVariablesAndVaule() };
                    File.WriteAllLines(Path.Combine(ModLoader.GetModAssetsFolder(mscTranslateChs), "_FsmVariables.txt"), text);
                    logger.LOG("写入所有FsmVariables变量到FsmVariables.txt");
                }
            }
        }
        public string textCameraLog;

        private void RayGameObject()
        {
            textCameraLog = "";
            foreach (Camera c in Camera.allCameras)
            {
                if (c != null)
                {
                    textCameraLog += GameObjectUtil.getGameObjectPath(c.gameObject) + "\n";
                    textCameraLog += "\t farClipPlane :  " + c.farClipPlane + "\n";
                    textCameraLog += "\t nearClipPlane :  " + c.nearClipPlane + "\n";
                    textCameraLog += "\t orthographic :  " + c.orthographic + "\n";
                    textCameraLog += "\t pixelRect :  " + c.pixelRect + "\n";
                }
            }
            textCameraLog += "current : " + (Camera.current != null ? Camera.current.name : "null") + "\n";
            textCameraLog += "main : " + (Camera.main != null ? Camera.main.name : "null") + "\n" + "\n";

            // Camera camera = GameObject.Find("Systems/OptionsMenu/CAM").GetComponent<Camera>();
            // Camera camera = GameObject.Find("PLAYER/Pivot/Camera/FPSCamera/FPSCamera").GetComponent<Camera>();
            /*
            if (camera == null)
            {
                return;
            }
            */
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit[] raycastHits = Physics.RaycastAll(ray, Mathf.Infinity);
            if (raycastHits != null && raycastHits.Length > 0)
            {
                string text = "GameObject检测(LeftCtrl + M写入文件)->鼠标位置(" + Input.mousePosition + ")对应的Object（"+ raycastHits.Length+ "） : \n";
                foreach (RaycastHit hitInfo in raycastHits)
                {
                    if (hitInfo.collider != null)
                    {
                        GameObject gameObject = hitInfo.collider.gameObject;
                        if (gameObject != null)
                        {
                            text += GameObjectUtil.getGameObjectText(gameObject);
                            
                        }
                    }
                }
                GUI.Label(new Rect(Input.mousePosition.x, (-Input.mousePosition.y), Screen.width, Screen.height), text, guiStyle);
                if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.M))
                {
                    WriteText(text, "_mouse.txt");
                }

            }
        }

        private void WriteText(string text , string fileNmae)
        {
            File.WriteAllText(Path.Combine(ModLoader.GetModAssetsFolder(mscTranslateChs), fileNmae), text);
        }

        private void WriteGameObject(string path)
        {
            string text = GameObjectUtil.getGameObjectText(path, 0, true, true, false, false, false);
            File.WriteAllText(Path.Combine(ModLoader.GetModAssetsFolder(mscTranslateChs), "_pathGameObject.txt"), text);
        }

        private void WriteGameObject(GameObject gameObject)
        {
            string text = GameObjectUtil.getGameObjectText(gameObject,0, true, true);
            File.WriteAllText(Path.Combine(ModLoader.GetModAssetsFolder(mscTranslateChs), "_gameObject.txt"), text);
        }

        

       

        
    }

}
