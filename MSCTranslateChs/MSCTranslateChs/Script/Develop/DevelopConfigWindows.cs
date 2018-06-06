using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MSCTranslateChs.Script.Develop
{
    class DevelopConfigWindows
    {
        bool isShowDevelopConfigWindows = true;
        Rect developWindowsRect = new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.8f, Screen.height * 0.8f);
        Develop develop;

        public DevelopConfigWindows(Develop develop)
        {
            this.develop = develop;
        }

        public void Update()
        {
            isShowDevelopConfigWindows = develop.isShowDevelopConfigWindows;
            if (develop != null && isShowDevelopConfigWindows)
            {
                developWindowsRect = GUI.Window(1, developWindowsRect, DevelopConfigWindowsFunction, "欢迎使用我的夏季汽车中文翻译Mod 开发模式");
            }
        }


        private void DevelopConfigWindowsFunction(int windowsId)
        {

            //定义一个toggle控制窗体的显示和隐藏
            develop.isRayGameObject = GUILayout.Toggle(develop.isRayGameObject, "是否显示鼠标指向的GameObject信息");

            if (GUILayout.Button("初始化UI"))
            {
                develop.initUIRay();
            }

            if (GUILayout.Button("关闭")){
                develop.isShowDevelopConfigWindows = false;
            }

            GUI.DragWindow(new Rect(0, 0, Screen.width, Screen.height));
        }
    }
}
