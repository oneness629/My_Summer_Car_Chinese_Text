using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using MSCTranslateChs.Script.Develop;
using MSCTranslateChs.Script.Teleport;
using MSCTranslateChs.Script.Common;

namespace MSCTranslateChs.Script.Develop
{
    class DevelopConfigWindows
    {
        bool isShowDevelopConfigWindows = true;
        Rect developWindowsRect;
        Develop develop;
        int windowsId = 6291;
        

        public string targetGameObjectPath = "Systems";
        public GameObject targetGameObject = null;

        public DevelopConfigWindows(Develop develop)
        {
            developWindowsRect = new Rect(0, 0, 800, 600);
            this.develop = develop;
        }

        public void Update()
        {
            isShowDevelopConfigWindows = develop.isShowDevelopConfigWindows;
            if (develop != null && isShowDevelopConfigWindows)
            {
                developWindowsRect = GUI.Window(windowsId, developWindowsRect, DevelopConfigWindowsFunction, "欢迎使用我的夏季汽车中文翻译Mod 开发模式");
            }
        }


        private void DevelopConfigWindowsFunction(int windowsId)
        {

            //定义一个toggle控制窗体的显示和隐藏
            develop.isRayGameObject = GUILayout.Toggle(develop.isRayGameObject, "是否显示鼠标指向的GameObject信息");

            if (GUILayout.Button("远程传送窗口"))
            {
                develop.teleport.isShowWindow = true;
            }
            if (GUILayout.Button("Ray射线"))
            {
                develop.isRayGameObject = true;
            }

            if (GUILayout.Button("关闭")){
                develop.isShowDevelopConfigWindows = false;
            }

            GameObjectTransformUpdate();

            ShowAllExecutionTime();

            GUI.DragWindow(new Rect(0, 0, 99999, 99999));
        }

        private void ShowAllExecutionTime()
        {

            foreach (string key in develop.mscTranslateChs.allExecutionTime.Keys)
            {
                ExecutionTime executionTime = develop.mscTranslateChs.allExecutionTime[key];
                GUILayout.BeginHorizontal("box");
                GUILayout.Label(key + ":");
                GUILayout.EndHorizontal();
                
                foreach (string timeKey in executionTime.executionTimeDict.Keys)
                {
                    GUILayout.BeginHorizontal("box");
                    GUILayout.Label(timeKey + ":" + executionTime.executionTimeDict[timeKey]);
                    GUILayout.EndHorizontal();
                }
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
                GUILayout.Label("目标GameObject:" + targetGameObject.name);
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
