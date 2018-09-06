using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using MSCTranslateChs.Script.Develop;
using MSCLoader;
using MSCTranslateChs.Script.Common;
using HutongGames.PlayMaker;

namespace MSCTranslateChs.Script.Model
{
    
    public class Money
    {
        private static LOGGER logger = new LOGGER(typeof(Money));

        public bool isShowWindow = false;
        Rect windowsRect;
        // Vector2 scrollPoint;
        float windowsWidth = 260;
        float windowsHeight = 50;
        int windowsId = 6294;

        float money;
        String moneyKey = "PlayerMoney";
        FsmFloat moneyFsmFloat;

        public Money()
        {
            moneyFsmFloat = FsmVariables.GlobalVariables.FindFsmFloat(moneyKey);
            if (moneyFsmFloat != null)
            {
                money = moneyFsmFloat.Value;
            }
            
            windowsRect = new Rect(0, 0, windowsWidth, windowsHeight);

        }

        public void OnGUI()
        {
            if (isShowWindow)
            {
                windowsRect = GUI.Window(windowsId, windowsRect, MoneyWindowFunction, "金钱调整");
            }
        }

        public void MoneyWindowFunction(int windowsId)
        {
            // scrollPoint = GUILayout.BeginScrollView(scrollPoint);
            string moneyStr = money.ToString();
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("修改金钱：");
            moneyStr = GUILayout.TextField(moneyStr);
            try
            {
                money = float.Parse(moneyStr);
            }
            catch (Exception e)
            {
                logger.LOG("金钱值转换异常:" + e.Message);
                moneyStr = money.ToString();
            }
            if (GUILayout.Button("修改"))
            {
                moneyFsmFloat.Value = money;
            }
            if (GUILayout.Button("关闭"))
            {
                isShowWindow = false;
            }
            GUILayout.EndHorizontal();
            // GUILayout.EndScrollView();
            GUI.DragWindow();
        }
    }

   
}
