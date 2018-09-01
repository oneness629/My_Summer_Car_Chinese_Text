using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MSCTranslateChs.Script
{
    class WelcomeWindows
    {
        bool isShowWelcomeWindows = true;
        Rect welcomeWindowsRect;
        float windowsWidth = 800;
        float windowsHeight = 600;
        MSCTranslateChs mscTranslateChs;
        Vector2 scrollPoint;
        int windowsId = 629;

        public WelcomeWindows(MSCTranslateChs mscTranslateChs)
        {
            welcomeWindowsRect = new Rect(Screen.width / 2 - windowsWidth / 2, Screen.height / 2 - windowsHeight / 2, windowsWidth, windowsHeight);
            this.mscTranslateChs = mscTranslateChs;
        }


        public void Update()
        {
            isShowWelcomeWindows = mscTranslateChs.isShowWelcomeWindows;
            if (mscTranslateChs != null && isShowWelcomeWindows)
            {
                welcomeWindowsRect = GUI.Window(windowsId, welcomeWindowsRect, WelcomeWindowsFunction, "欢迎使用我的夏季汽车中文翻译Mod");
            }
        }


        private void WelcomeWindowsFunction(int windowsId)
        {
            scrollPoint = GUILayout.BeginScrollView(scrollPoint);
            GUILayout.Label("  欢迎使用我的夏季汽车中文翻译Mod");
            GUILayout.Label("  当前翻译内容：状态UI、商品动作、配件、字幕(需要打开英文字幕),中英文对照显示，不会覆盖原有英文内容。");
            GUILayout.Label("      状态UI、商品动作、配件、字幕(需要打开英文字幕),中英文对照显示，不会覆盖原有英文内容。");
            GUILayout.Label("      详细使用教程请参考steam中文模组指南(界面比较乱，以后慢慢改~)");
            GUILayout.Label("      显示/隐藏本窗口（左边ALT+W）/（右边ALT+W）");
            GUILayout.Label("      启用GameOver提示后，玩家Over后报纸内容显示出Over原因时按下左边ALT+G，一次性读取全部原因到gameover.txt");

            mscTranslateChs.IsEnable = GUILayout.Toggle(mscTranslateChs.IsEnable, "是否启用翻译Mod（取消，会加载文本到内存，但不会进行任何OnGUI交互）");
            mscTranslateChs.IsTranslateGameOverMessage = GUILayout.Toggle(mscTranslateChs.IsTranslateGameOverMessage, "是否启用GameOver提示文本（报刊上的GameOver原因）");
            mscTranslateChs.IsTranslateInteractions = GUILayout.Toggle(mscTranslateChs.IsTranslateInteractions, "是否启用操作动作和界面元素翻译（动作~有~但是，界面元素？那个没用的）");
            mscTranslateChs.IsTranslatePartnames = GUILayout.Toggle(mscTranslateChs.IsTranslatePartnames, "是否启用部件名称翻译");
            mscTranslateChs.IsTranslateSubtitles = GUILayout.Toggle(mscTranslateChs.IsTranslateSubtitles, "是否启用字幕翻译");
            mscTranslateChs.IsTranslateUI = GUILayout.Toggle(mscTranslateChs.IsTranslateUI, "是否启用UI翻译(鼠标移到菜单上，鼠标边上会显示翻译文字)");
            mscTranslateChs.IsTranslateEscInitUI = GUILayout.Toggle(mscTranslateChs.IsTranslateEscInitUI, "是否在按下Esc（按F1不会初始化）的时候初始化UI碰撞体（如果不需要菜单翻译可以去掉上面和这个勾）");
            mscTranslateChs.isEnableTeleport = GUILayout.Toggle(mscTranslateChs.isEnableTeleport, "是否启用传送功能");
            
            mscTranslateChs.IsDevelop = GUILayout.Toggle(mscTranslateChs.IsDevelop, "是否启用开发模式（左边Alt+T（显示）和右边Alt+T（隐藏））");

            isShowWelcomeWindows = GUILayout.Toggle(isShowWelcomeWindows, "下次启动是否再次显示窗口（这个没用的···我还没写完···慢慢来···）");
            if (GUILayout.Button("关闭 或 按XXX按键关闭")){
                mscTranslateChs.isShowWelcomeWindows = false;
            }
            if (GUILayout.Button("访问MOD指南页面(按ESC能够使用鼠标)"))
            {
                Application.OpenURL("https://steamcommunity.com/sharedfiles/filedetails/?id=1384837781");
            }
            GUILayout.BeginHorizontal("box");
            if (GUILayout.Button("远程传送窗口"))
            {
                mscTranslateChs.teleport.isShowWindow = true;
            }
            if (GUILayout.Button("金钱调整"))
            {
                mscTranslateChs.money.isShowWindow = true;
            }
            if (GUILayout.Button("螺栓提示"))
            {
                mscTranslateChs.boltTip.isShowWindow = true;
            }
            GUILayout.EndHorizontal();
            GUILayout.EndScrollView();
            GUI.DragWindow();
        }
    }
}
