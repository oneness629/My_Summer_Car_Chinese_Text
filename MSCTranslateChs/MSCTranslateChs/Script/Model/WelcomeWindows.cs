using HutongGames.PlayMaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MSCTranslateChs.Script.Model
{
    public class WelcomeWindows
    {
        public bool isEnable = true;
        Rect welcomeWindowsRect;
        readonly float windowsWidth = 800;
        readonly float windowsHeight = 600;
        Vector2 scrollPoint;

        FsmFloat timeRotationMinute;
        FsmFloat timeRotationHour;

        public WelcomeWindows()
        {
            welcomeWindowsRect = new Rect(Screen.width / 2 - windowsWidth / 2, Screen.height / 2 - windowsHeight / 2, windowsWidth, windowsHeight);
            
            timeRotationHour = FsmVariables.GlobalVariables.FindFsmFloat("TimeRotationHour");
            timeRotationMinute = FsmVariables.GlobalVariables.FindFsmFloat("TimeRotationMinute");
        }


        public void OnGUI()
        {
            if (isEnable)
            {
                welcomeWindowsRect = GUI.Window(GlobalVariables.windowsIdByWelcomeWindows, welcomeWindowsRect, WelcomeWindowsFunction, "欢迎使用我的夏季汽车中文翻译Mod");
            }
        }

        public void Update()
        {
            if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.W))
            {
                GlobalVariables.GetGlobalVariables().welcomeWindows.isEnable = true;
            }
            if (Input.GetKey(KeyCode.RightAlt) && Input.GetKey(KeyCode.W))
            {
                GlobalVariables.GetGlobalVariables().welcomeWindows.isEnable = false;
            }
        }

        private void WelcomeWindowsFunction(int windowsId)
        {
            scrollPoint = GUILayout.BeginScrollView(scrollPoint);
            GUILayout.Label("  欢迎使用我的夏季汽车中文翻译Mod");
            int viewHour = 1 - Mathf.FloorToInt(timeRotationHour.Value / (360 / 12)) + 12;
            int viewMinutes = 60 - Mathf.FloorToInt(timeRotationMinute.Value / (360 / 60));
            GUILayout.Label("      游戏内时间:" + viewHour.ToString("D2") + ":" + viewMinutes.ToString("D2"));
            GUILayout.Label("  当前翻译内容：状态UI、商品动作、配件、字幕(需要打开英文字幕),中英文对照显示，不会覆盖原有英文内容。");
            GUILayout.Label("      状态UI、商品动作、配件、字幕(需要打开英文字幕),中英文对照显示，不会覆盖原有英文内容。");
            GUILayout.Label("      详细使用教程请参考steam中文模组指南(界面比较乱，以后慢慢改~)");
            GUILayout.Label("      显示/隐藏本窗口（左边ALT+W）/（右边ALT+W）");
            GUILayout.Label("      启用GameOver提示后，玩家Over后报纸内容显示出Over原因时按下左边ALT+G，一次性读取全部原因到gameover.txt");


            GlobalVariables.GetGlobalVariables().mscTranslateChs.IsEnable = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().mscTranslateChs.IsEnable, "是否启用翻译Mod（取消，会加载文本到内存，但不会进行任何OnGUI交互）");
            GlobalVariables.GetGlobalVariables().mscTranslate.IsTranslateGameOverMessage = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().mscTranslate.IsTranslateGameOverMessage, "是否启用GameOver提示文本（报刊上的GameOver原因）");
            GlobalVariables.GetGlobalVariables().mscTranslate.IsTranslateInteractions = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().mscTranslate.IsTranslateInteractions, "是否启用操作动作和界面元素翻译（动作~有~但是，界面元素？那个没用的）");
            GlobalVariables.GetGlobalVariables().mscTranslate.IsTranslatePartnames = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().mscTranslate.IsTranslatePartnames, "是否启用部件名称翻译");
            GlobalVariables.GetGlobalVariables().mscTranslate.IsTranslateSubtitles = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().mscTranslate.IsTranslateSubtitles, "是否启用字幕翻译");
            GlobalVariables.GetGlobalVariables().mscTranslate.IsTranslateUI = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().mscTranslate.IsTranslateUI, "是否启用UI翻译(鼠标移到菜单上，鼠标边上会显示翻译文字)");
            GlobalVariables.GetGlobalVariables().mscTranslate.IsTranslateEscInitUI = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().mscTranslate.IsTranslateEscInitUI, "是否在按下Esc（按F1不会初始化）的时候初始化UI碰撞体（如果不需要菜单翻译可以去掉上面和这个勾）");
            GlobalVariables.GetGlobalVariables().teleport.isEnable = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().teleport.isEnable, "是否启用传送功能");

            GlobalVariables.GetGlobalVariables().develop.isEnable = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().develop.isEnable, "是否启用开发模式（左边Alt+T（显示）和右边Alt+T（隐藏））");

            if (GUILayout.Button("关闭 或 按XXX按键关闭")){
                isEnable = false;
            }
            if (GUILayout.Button("访问MOD指南页面(按ESC能够使用鼠标)"))
            {
                Application.OpenURL("https://steamcommunity.com/sharedfiles/filedetails/?id=1384837781");
            }
            GUILayout.BeginHorizontal("box");
            if (GUILayout.Button("远程传送窗口"))
            {
                GlobalVariables.GetGlobalVariables().teleport.isShowWindow = true;
            }
            if (GUILayout.Button("金钱调整"))
            {
                GlobalVariables.GetGlobalVariables().money.isEnable = true;
                GlobalVariables.GetGlobalVariables().money.isShowWindow = true;
            }
            if (GUILayout.Button("螺栓提示"))
            {
                GlobalVariables.GetGlobalVariables().boltTip.isShowWindow = true;
            }
            if (GUILayout.Button("物品传送(背包)"))
            {
                GlobalVariables.GetGlobalVariables().itemTransmitter.isShowWindow = true;
            }
            GUILayout.EndHorizontal();
            GUILayout.EndScrollView();
            GUI.DragWindow();
        }
    }
}
