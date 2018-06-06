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
        Rect welcomeWindowsRect = new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.8f, Screen.height * 0.8f);
        MSCTranslateChs mscTranslateChs;

        public WelcomeWindows(MSCTranslateChs mscTranslateChs)
        {
            this.mscTranslateChs = mscTranslateChs;
        }


        public void Update()
        {
            isShowWelcomeWindows = mscTranslateChs.isShowWelcomeWindows;
            if (mscTranslateChs != null && isShowWelcomeWindows)
            {
                welcomeWindowsRect = GUI.Window(1, welcomeWindowsRect, WelcomeWindowsFunction, "欢迎使用我的夏季汽车中文翻译Mod");
            }
        }


        private void WelcomeWindowsFunction(int windowsId)
        {
            GUILayout.Label("  欢迎使用我的夏季汽车中文翻译Mod");
            GUILayout.Label("  当前翻译内容：商品动作、配件、字幕(需要打开英文字幕),中英文对照显示，不会覆盖原有英文内容。");
            GUILayout.Label("      商品动作、配件、字幕(需要打开英文字幕),中英文对照显示，不会覆盖原有英文内容。");
            GUILayout.Label("  如果遇到未翻译内容，支持自动调用百度翻译API(需要自行申请APIkey和Appid)，并保存到Mod目录下的\\Assets\\MSCTranslateChs下的文本文件中");
            GUILayout.Label("  \\Assets\\MSCTranslateChs 文件说明");
            GUILayout.Label("    config.txt 配置文件");
            GUILayout.Label("        配置百度翻译API内容和是否启用百度API（如果未启用，遇到未翻译文本将显示未翻译字样，如果启用后，未翻译文本会显示[自动翻译中...]，打开Mod Loader控制台能看到发送的http请求地址等信息，并会自动将翻译好的以=号右边[自动翻译]打头的文本写入到对应txt中以便下次校对）");
            GUILayout.Label("    interactions.txt 操作动作对照文本文件（部分用不到）");
            GUILayout.Label("    partnames.txt 配件对照文本文件");
            GUILayout.Label("    subtitles.txt 字幕对照文本文件");

            isShowWelcomeWindows = GUILayout.Toggle(isShowWelcomeWindows, "下次启动是否再次显示窗口（没用的···我还没写完···）");
            if(GUILayout.Button("关闭 或 按XXX按键关闭")){
                mscTranslateChs.isShowWelcomeWindows = false;
            }
            if (GUILayout.Button("访问MOD指南页面(按ESC能够使用鼠标)"))
            {
                Application.OpenURL("https://steamcommunity.com/sharedfiles/filedetails/?id=1384837781");
            }
            GUI.DragWindow(new Rect(0, 0, Screen.width, Screen.height));
        }
    }
}
