using System;
using System.Collections.Generic;
using UnityEngine;
using MSCTranslateChs.Script.Common;
using MSCTranslateChs.Script.Module.Base;
using HutongGames.PlayMaker;

namespace MSCTranslateChs.Script.Module
{

    public class CarReport : BaseModule
    {
        private static readonly LOGGER logger = new LOGGER(typeof(CarReport));
        public override string ModuleComment { get => "车辆报告"; }

        public bool isShowWindow = false;

        Rect windowsRect;
        Vector2 scrollPoint;
        public float windowsWidth = 800;
        public float windowsHeight = 600;



        public override void Init()
        {
            windowsRect = new Rect(Screen.width / 2 - windowsWidth / 2, Screen.height / 2 - windowsHeight / 2, windowsWidth, windowsHeight);
        }

        public override void OnGUI()
        {
            if (isShowWindow)
            {
                windowsRect = GUI.Window(GlobalVariables.windowsIdByBoltTip, windowsRect, WindowFunction, "车辆报告");
            }
            if (IsEnable)
            {

            }
        }

        public override void Update()
        {
        }


        private void RayGameObject()
        {
            
            
        }


        public void WindowFunction(int windowsId)
        {
            scrollPoint = GUILayout.BeginScrollView(scrollPoint);
            if (GUILayout.Button("关闭"))
            {
                isShowWindow = false;
            }
            

            GUILayout.EndScrollView();
            GUI.DragWindow();
        }

       
    }
   
}
