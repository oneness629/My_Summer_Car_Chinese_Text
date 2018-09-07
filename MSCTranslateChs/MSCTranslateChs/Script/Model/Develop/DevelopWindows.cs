using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using MSCTranslateChs.Script.Common;
using System.IO;
using MSCLoader;

namespace MSCTranslateChs.Script.Model.Develop
{
    public class DevelopWindows
    {
        public bool isEnable = true;
        Rect developWindowsRect;
        Vector2 scrollPosition;
        readonly float windowsWidth = 800;
        readonly float windowsHeight = 600;
        

        public string targetGameObjectPath = "Systems";
        public GameObject targetGameObject = null;

        public DevelopWindows(Develop develop)
        {
            developWindowsRect = new Rect(Screen.width - windowsWidth , 0 , windowsWidth, windowsHeight);
        }

        public void Update()
        {
            if (GlobalVariables.GetGlobalVariables().develop != null && isEnable)
            {
                developWindowsRect = GUI.Window(GlobalVariables.windowsIdByDevelopWindows, developWindowsRect, DevelopConfigWindowsFunction, "欢迎使用我的夏季汽车中文翻译Mod 开发模式");
            }
        }


        private void DevelopConfigWindowsFunction(int windowsId)
        {
            scrollPosition = GUILayout.BeginScrollView(scrollPosition);
            GUILayout.Label("左Ctrl+R,重新读取所有txt文本");
            GUILayout.Label("左Ctrl+W,写入Systems下的GameObject到txt");
            GUILayout.Label("左Ctrl+F,写入所有FsmVariables变量到FsmVariables.txt");
            GlobalVariables.GetGlobalVariables().develop.isRayGameObject = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().develop.isRayGameObject, "是否显示鼠标指向的GameObject信息");

            
            if (GUILayout.Button("GUI GameObject 查看"))
            {
                GlobalVariables.GetGlobalVariables().guiGameObjectExplorer.isShow = true;
            }

            if (GUILayout.Button("读取所有Renderer"))
            {
                Renderer[] renderers = Resources.FindObjectsOfTypeAll<Renderer>();
                string text = "";
                foreach (Renderer renderer in renderers)
                {
                    text += renderer.name + "\n";
                    text += "  " + GameObjectUtil.GetGameObjectPath(renderer.gameObject) + "\n";

                }
                File.WriteAllLines(Path.Combine(ModLoader.GetModAssetsFolder(GlobalVariables.GetGlobalVariables().mscTranslateChs), "_renderers.txt"), new string[] { text });
            }

            if (GUILayout.Button("读取所有Material"))
            {
                Material[] materials = Resources.FindObjectsOfTypeAll<Material>();
                string text = "";
                foreach (Material material in materials)
                {
                    text += material.name + "\n";

                }
                File.WriteAllLines(Path.Combine(ModLoader.GetModAssetsFolder(GlobalVariables.GetGlobalVariables().mscTranslateChs), "_materials.txt"), new string[] { text });
            }

            if (GUILayout.Button("关闭")){
                GlobalVariables.GetGlobalVariables().develop.isShowDevelopConfigWindows = false;
            }

            ShowAllExecutionTime();

            ShowCameraData();

            GameOverGameObjectCheck();

            GameObjectTransformUpdate();

            ViewFsmAllVariablesAndVaule();


            GUILayout.EndScrollView();
            GUI.DragWindow();
        }

        private void ViewFsmAllVariablesAndVaule()
        {
            GUILayout.Label("全局变量查看:");
            GUILayout.Label(FsmVariablesUtil.GetAllFsmVariablesAndVaule());
        }

        private void GameOverGameObjectCheck()
        {
            /*
            GUILayout.Label("GameOver GameObject 检查:");
            GUILayout.Label("gameObjectSystems:" + develop.mscTranslateChs.gameObjectSystems);
            GUILayout.Label("gameObjectSystemsDeath:" + develop.mscTranslateChs.gameObjectSystemsDeath);
            GUILayout.Label("gameObjectSystemsDeathGameOverScreen:" + develop.mscTranslateChs.gameObjectSystemsDeathGameOverScreen);
            GUILayout.Label("gameObjectSystemsDeathGameOverScreenPaper:" + develop.mscTranslateChs.gameObjectSystemsDeathGameOverScreenPaper);
            if (GUILayout.Button("重置GameOver Object"))
            {
                GlobalVariables.GetGlobalVariables().develop.mscTranslateChs.gameObjectSystems = null;
                GlobalVariables.GetGlobalVariables().develop.mscTranslateChs.gameObjectSystemsDeath = null;
                GlobalVariables.GetGlobalVariables().develop.mscTranslateChs.gameObjectSystemsDeathGameOverScreen = null;
                GlobalVariables.GetGlobalVariables().develop.mscTranslateChs.gameObjectSystemsDeathGameOverScreenPaper = null;
            }
            */
        }

        private void ShowCameraData()
        {
            GUILayout.Label(GlobalVariables.GetGlobalVariables().develop.textCameraLog);
        }

        private void ShowAllExecutionTime()
        {
            GUILayout.Label("Mod执行效率检查:单位（毫秒）,基本为0即可，偶尔跳动对fps有细微影响，应应应该该该影响不大···");
            
            foreach (string timeKey in GlobalVariables.GetGlobalVariables().executionTime.executionTimeDict.Keys)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label(timeKey + ":" + GlobalVariables.GetGlobalVariables().executionTime.executionTimeDict[timeKey]);
                GUILayout.EndHorizontal();
            }
            
            
        }

        private void GameObjectTransformUpdate()
        {

            GUILayout.BeginHorizontal("box");
            GUILayout.Label("GameObject Path:");
            targetGameObjectPath = GUILayout.TextField(targetGameObjectPath);
            if (GUILayout.Button("获取目标"))
            {
                targetGameObject = GameObject.Find(targetGameObjectPath);
            }
            if (targetGameObject != null)
            {
                GUILayout.Label("目标GameObject:" + GameObjectUtil.GetGameObjectPath(targetGameObject));
            }
            GUILayout.EndHorizontal();

            if (targetGameObject != null)
            {
                GUILayout.BeginHorizontal("box");
                GUILayout.Label("目标GameObject位置微调");
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal("box");
                GUILayout.Label("position");
                string positionXStr = Convert.ToString(targetGameObject.transform.position.x);
                string positionYStr = Convert.ToString(targetGameObject.transform.position.y);
                string positionZStr = Convert.ToString(targetGameObject.transform.position.z);
                if (GUILayout.Button("<"))
                {
                    targetGameObject.transform.position = new Vector3(float.Parse(positionXStr) - 1f, float.Parse(positionYStr), float.Parse(positionZStr));
                }
                if (GUILayout.Button("<<"))
                {
                    targetGameObject.transform.position = new Vector3(float.Parse(positionXStr) - 0.1f, float.Parse(positionYStr), float.Parse(positionZStr));
                }
                positionXStr = GUILayout.TextField(Convert.ToString(targetGameObject.transform.position.x));
                if (GUILayout.Button(">>"))
                {
                    targetGameObject.transform.position = new Vector3(float.Parse(positionXStr) + 0.1f, float.Parse(positionYStr), float.Parse(positionZStr));
                }
                if (GUILayout.Button(">"))
                {
                    targetGameObject.transform.position = new Vector3(float.Parse(positionXStr) + 1f, float.Parse(positionYStr), float.Parse(positionZStr));
                }
                if (GUILayout.Button("<"))
                {
                    targetGameObject.transform.position = new Vector3(float.Parse(positionXStr), float.Parse(positionYStr) - 1f, float.Parse(positionZStr));
                }
                if (GUILayout.Button("<<"))
                {
                    targetGameObject.transform.position = new Vector3(float.Parse(positionXStr), float.Parse(positionYStr) - 0.1f, float.Parse(positionZStr));
                }
                positionYStr = GUILayout.TextField(Convert.ToString(targetGameObject.transform.position.y));
                if (GUILayout.Button(">>"))
                {
                    targetGameObject.transform.position = new Vector3(float.Parse(positionXStr), float.Parse(positionYStr) + 0.1f, float.Parse(positionZStr));
                }
                if (GUILayout.Button(">"))
                {
                    targetGameObject.transform.position = new Vector3(float.Parse(positionXStr), float.Parse(positionYStr) + 1f, float.Parse(positionZStr));
                }
                if (GUILayout.Button("<"))
                {
                    targetGameObject.transform.position = new Vector3(float.Parse(positionXStr), float.Parse(positionYStr), float.Parse(positionZStr) - 1f);
                }
                if (GUILayout.Button("<<"))
                {
                    targetGameObject.transform.position = new Vector3(float.Parse(positionXStr), float.Parse(positionYStr), float.Parse(positionZStr) - 0.1f);
                }
                positionZStr = GUILayout.TextField(Convert.ToString(targetGameObject.transform.position.z));
                if (GUILayout.Button(">>"))
                {
                    targetGameObject.transform.position = new Vector3(float.Parse(positionXStr), float.Parse(positionYStr), float.Parse(positionZStr) + 0.1f);
                }
                if (GUILayout.Button(">"))
                {
                    targetGameObject.transform.position = new Vector3(float.Parse(positionXStr), float.Parse(positionYStr), float.Parse(positionZStr) + 1f);
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal("box");
                GUILayout.Label("position");
                string rotationXStr = Convert.ToString(targetGameObject.transform.rotation.x);
                string rotationYStr = Convert.ToString(targetGameObject.transform.rotation.y);
                string rotationZStr = Convert.ToString(targetGameObject.transform.rotation.z);
                string rotationWStr = Convert.ToString(targetGameObject.transform.rotation.w);
                if (GUILayout.Button("<"))
                {
                    targetGameObject.transform.rotation = new Quaternion(float.Parse(rotationXStr) - 1f, float.Parse(rotationYStr), float.Parse(rotationZStr), float.Parse(rotationWStr));
                }
                if (GUILayout.Button("<<"))
                {
                    targetGameObject.transform.rotation = new Quaternion(float.Parse(rotationXStr) - 0.1f, float.Parse(rotationYStr), float.Parse(rotationZStr), float.Parse(rotationWStr));
                }
                positionXStr = GUILayout.TextField(Convert.ToString(targetGameObject.transform.rotation.x));
                if (GUILayout.Button(">>"))
                {
                    targetGameObject.transform.rotation = new Quaternion(float.Parse(rotationXStr) + 0.1f, float.Parse(rotationYStr), float.Parse(rotationZStr), float.Parse(rotationWStr));
                }
                if (GUILayout.Button(">"))
                {
                    targetGameObject.transform.rotation = new Quaternion(float.Parse(rotationXStr) + 1f, float.Parse(rotationYStr), float.Parse(rotationZStr), float.Parse(rotationWStr));
                }
                if (GUILayout.Button("<"))
                {
                    targetGameObject.transform.rotation = new Quaternion(float.Parse(rotationXStr), float.Parse(rotationYStr) - 1f, float.Parse(rotationZStr), float.Parse(rotationWStr));
                }
                if (GUILayout.Button("<<"))
                {
                    targetGameObject.transform.rotation = new Quaternion(float.Parse(rotationXStr), float.Parse(rotationYStr) - 0.1f, float.Parse(rotationZStr), float.Parse(rotationWStr));
                }
                positionYStr = GUILayout.TextField(Convert.ToString(targetGameObject.transform.rotation.y));
                if (GUILayout.Button(">>"))
                {
                    targetGameObject.transform.rotation = new Quaternion(float.Parse(rotationXStr), float.Parse(rotationYStr) + 0.1f, float.Parse(rotationZStr), float.Parse(rotationWStr));
                }
                if (GUILayout.Button(">"))
                {
                    targetGameObject.transform.rotation = new Quaternion(float.Parse(rotationXStr), float.Parse(rotationYStr) + 1f, float.Parse(rotationZStr), float.Parse(rotationWStr));
                }
                if (GUILayout.Button("<"))
                {
                    targetGameObject.transform.rotation = new Quaternion(float.Parse(rotationXStr), float.Parse(rotationYStr), float.Parse(rotationZStr) - 1f, float.Parse(rotationWStr));
                }
                if (GUILayout.Button("<<"))
                {
                    targetGameObject.transform.rotation = new Quaternion(float.Parse(rotationXStr), float.Parse(rotationYStr), float.Parse(rotationZStr) - 0.1f, float.Parse(rotationWStr));
                }
                positionZStr = GUILayout.TextField(Convert.ToString(targetGameObject.transform.rotation.z));
                if (GUILayout.Button(">>"))
                {
                    targetGameObject.transform.rotation = new Quaternion(float.Parse(rotationXStr), float.Parse(rotationYStr), float.Parse(rotationZStr) + 0.1f, float.Parse(rotationWStr));
                }
                if (GUILayout.Button(">"))
                {
                    targetGameObject.transform.rotation = new Quaternion(float.Parse(rotationXStr), float.Parse(rotationYStr), float.Parse(rotationZStr) + 1f, float.Parse(rotationWStr));
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal("box");
                GUILayout.Label("position");
                string localScaleXStr = Convert.ToString(targetGameObject.transform.localScale.x);
                string localScaleYStr = Convert.ToString(targetGameObject.transform.localScale.y);
                string localScaleZStr = Convert.ToString(targetGameObject.transform.localScale.z);
                if (GUILayout.Button("<"))
                {
                    targetGameObject.transform.localScale = new Vector3(float.Parse(localScaleXStr) - 1f, float.Parse(localScaleYStr), float.Parse(localScaleZStr));
                }
                if (GUILayout.Button("<<"))
                {
                    targetGameObject.transform.localScale = new Vector3(float.Parse(localScaleXStr) - 0.1f, float.Parse(localScaleYStr), float.Parse(localScaleZStr));
                }
                positionXStr = GUILayout.TextField(Convert.ToString(targetGameObject.transform.localScale.x));
                if (GUILayout.Button(">>"))
                {
                    targetGameObject.transform.localScale = new Vector3(float.Parse(localScaleXStr) + 0.1f, float.Parse(localScaleYStr), float.Parse(localScaleZStr));
                }
                if (GUILayout.Button(">"))
                {
                    targetGameObject.transform.localScale = new Vector3(float.Parse(localScaleXStr) + 1f, float.Parse(localScaleYStr), float.Parse(localScaleZStr));
                }
                if (GUILayout.Button("<"))
                {
                    targetGameObject.transform.localScale = new Vector3(float.Parse(localScaleXStr), float.Parse(localScaleYStr) - 1f, float.Parse(localScaleZStr));
                }
                if (GUILayout.Button("<<"))
                {
                    targetGameObject.transform.localScale = new Vector3(float.Parse(localScaleXStr), float.Parse(localScaleYStr) - 0.1f, float.Parse(localScaleZStr));
                }
                positionYStr = GUILayout.TextField(Convert.ToString(targetGameObject.transform.localScale.y));
                if (GUILayout.Button(">>"))
                {
                    targetGameObject.transform.localScale = new Vector3(float.Parse(localScaleXStr), float.Parse(localScaleYStr) + 0.1f, float.Parse(localScaleZStr));
                }
                if (GUILayout.Button(">"))
                {
                    targetGameObject.transform.localScale = new Vector3(float.Parse(localScaleXStr), float.Parse(localScaleYStr) + 1f, float.Parse(localScaleZStr));
                }
                if (GUILayout.Button("<"))
                {
                    targetGameObject.transform.localScale = new Vector3(float.Parse(localScaleXStr), float.Parse(localScaleYStr), float.Parse(localScaleZStr) - 1f);
                }
                if (GUILayout.Button("<<"))
                {
                    targetGameObject.transform.localScale = new Vector3(float.Parse(localScaleXStr), float.Parse(localScaleYStr), float.Parse(localScaleZStr) - 0.1f);
                }
                positionZStr = GUILayout.TextField(Convert.ToString(targetGameObject.transform.localScale.z));
                if (GUILayout.Button(">>"))
                {
                    targetGameObject.transform.localScale = new Vector3(float.Parse(localScaleXStr), float.Parse(localScaleYStr), float.Parse(localScaleZStr) + 0.1f);
                }
                if (GUILayout.Button(">"))
                {
                    targetGameObject.transform.localScale = new Vector3(float.Parse(localScaleXStr), float.Parse(localScaleYStr), float.Parse(localScaleZStr) + 1f);
                }
                GUILayout.EndHorizontal();
            }
        }
        
    }
}
