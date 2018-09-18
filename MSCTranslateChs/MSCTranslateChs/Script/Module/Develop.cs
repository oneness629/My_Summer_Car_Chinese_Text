using MSCLoader;
using MSCTranslateChs.Script.Common;
using MSCTranslateChs.Script.Module.Base;
using System.IO;
using UnityEngine;

namespace MSCTranslateChs.Script.Module
{
    public class Develop : BaseModule
    {

        private static LOGGER logger = new LOGGER(typeof(Develop));
        public override string ModuleComment { get => "开发测试模式"; }

        public GUIStyle guiStyle;

        public bool isRayGameObject = false;

        public override void Init()
        {
            guiStyle = new GUIStyle()
            {
                alignment = TextAnchor.LowerLeft,
                fontSize = (int)(8.0f * (float)(Screen.width) / 1000f)
            };
            guiStyle.normal.textColor = new Color(255, 255, 255);
        }

        public override void Update()
        {
            if (GlobalVariables.GetGlobalVariables().keyBindShowDevelopWindows.IsDown())
            {
                GlobalVariables.GetGlobalVariables().developWindows.IsEnable = true;
            }
            if (GlobalVariables.GetGlobalVariables().keyBindHideDevelopWindows.IsDown())
            {
                GlobalVariables.GetGlobalVariables().developWindows.IsEnable = false;
            }
            if (GlobalVariables.GetGlobalVariables().keyBindReadAllTxt.IsDown())
            {
                GlobalVariables.GetGlobalVariables().mscTranslate.translateText.ReadTranslateTextDict();
            }
            if (GlobalVariables.GetGlobalVariables().keyBindWriteGameObjectToTxt.IsDown())
            {
                WriteGameObject("Systems");
                logger.LOG("写入所有Systems路径下的GameObject到txt");
            }
            if (GlobalVariables.GetGlobalVariables().keyBindWriteFVToTxt.IsDown())
            {
                string[] text = { FsmVariablesUtil.GetAllFsmVariablesAndVaule() };
                File.WriteAllLines(Path.Combine(ModLoader.GetModAssetsFolder(GlobalVariables.GetGlobalVariables().mscTranslateChs), "_FsmVariables.txt"), text);
                logger.LOG("写入所有FsmVariables变量到FsmVariables.txt");
            }
            if (GlobalVariables.GetGlobalVariables().developWindows.isShowCameraData)
            {
                ReadCameraState();
            }
        }



        public override void OnGUI()
        {
            
            GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "MSCTranslateChs开发测试模式", guiStyle);

            if (isRayGameObject)
            {
                RayGameObject();
            }

            if (GlobalVariables.GetGlobalVariables().guiGameObjectExplorer.isShow)
            {
                GlobalVariables.GetGlobalVariables().guiGameObjectExplorer.OnGUI();
            }
               
        }
        public string cameraState;

        private void ReadCameraState()
        {
            cameraState = "";
            foreach (Camera c in Camera.allCameras)
            {
                if (c != null)
                {
                    cameraState += GameObjectUtil.GetGameObjectPath(c.gameObject) + "\n";
                    cameraState += "\t farClipPlane :  " + c.farClipPlane + "\n";
                    cameraState += "\t nearClipPlane :  " + c.nearClipPlane + "\n";
                    cameraState += "\t orthographic :  " + c.orthographic + "\n";
                    cameraState += "\t pixelRect :  " + c.pixelRect + "\n";
                }
            }
            cameraState += "current : " + (Camera.current != null ? Camera.current.name : "null") + "\n";
            cameraState += "main : " + (Camera.main != null ? Camera.main.name : "null") + "\n" + "\n";
        }

        private void RayGameObject()
        {
            if (GlobalVariables.GetGlobalVariables().physicsRaycast.mainCameraRaycastHits != null && GlobalVariables.GetGlobalVariables().physicsRaycast.mainCameraRaycastHits.Length > 0)
            {
                string text = "GameObject检测(LeftCtrl + M写入文件)->鼠标位置(" + Input.mousePosition + ")对应的Object（"+ GlobalVariables.GetGlobalVariables().physicsRaycast.mainCameraRaycastHits.Length+ "） : \n";
                foreach (RaycastHit hitInfo in GlobalVariables.GetGlobalVariables().physicsRaycast.mainCameraRaycastHits)
                {
                    if (hitInfo.collider != null)
                    {
                        GameObject gameObject = hitInfo.collider.gameObject;
                        if (gameObject != null)
                        {
                            text += gameObject.name + "->"  + GameObjectUtil.GetGameObjectPath(gameObject);
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
            File.WriteAllText(Path.Combine(ModLoader.GetModAssetsFolder(GlobalVariables.GetGlobalVariables().mscTranslateChs), fileNmae), text);
        }

        private void WriteGameObject(string path)
        {
            string text = GameObjectUtil.GetGameObjectText(path, 0, true, true, false, false, false);
            File.WriteAllText(Path.Combine(ModLoader.GetModAssetsFolder(GlobalVariables.GetGlobalVariables().mscTranslateChs), "_pathGameObject.txt"), text);
        }

        private void WriteGameObject(GameObject gameObject)
        {
            string text = GameObjectUtil.GetGameObjectText(gameObject,0, true, true);
            File.WriteAllText(Path.Combine(ModLoader.GetModAssetsFolder(GlobalVariables.GetGlobalVariables().mscTranslateChs), "_gameObject.txt"), text);
        }
        
    }

}
