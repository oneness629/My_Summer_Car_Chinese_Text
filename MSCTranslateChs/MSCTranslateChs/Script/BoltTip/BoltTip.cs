using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using MSCTranslateChs.Script.Develop;
using MSCLoader;
using MSCTranslateChs.Script.Common;

namespace MSCTranslateChs.Script.Teleport
{
    
    public class BoltTip
    {
        private static LOGGER logger = new LOGGER(typeof(BoltTip));

        public bool isShowWindow = false;
        public bool isEnable = true;
        public bool isInIt = false;
        Rect windowsRect;
        Vector2 scrollPoint;
        float windowsWidth = 800;
        float windowsHeight = 600;
        int windowsId = 6295;

        private GUIStyle mouseTipGuiStyle;

        public const String SATSUMA = "SATSUMA(557kg, 248)";
        public GameObject satsumaGameObject;


        public BoltTip()
        {
            windowsRect = new Rect(Screen.width / 2 - windowsWidth / 2, Screen.height / 2 - windowsHeight / 2, windowsWidth, windowsHeight);

            mouseTipGuiStyle = new GUIStyle();
            mouseTipGuiStyle.alignment = TextAnchor.LowerLeft;
            mouseTipGuiStyle.fontSize = (int)(14.0f * (float)(Screen.width) / 1000f);
            mouseTipGuiStyle.normal.textColor = new Color(255, 255, 255);
        }


        public void OnGUI()
        {

            if (isShowWindow)
            {
                windowsRect = GUI.Window(windowsId, windowsRect, WindowFunction, "螺栓提示");
            }
            RaySystemsGameObject();
        }

        
        private void RaySystemsGameObject()
        {
            if (!isInIt)
            {
                satsumaGameObject = GameObject.Find(SATSUMA);
                if (satsumaGameObject == null)
                {
                    return;
                }
                isInIt = true;
            }
            else
            {
                if (Camera.main == null)
                {
                    return;
                }
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit raycastHits;

                if (Physics.Raycast(ray, out raycastHits, 5f))
                {
                    if (raycastHits.collider != null && raycastHits.collider.gameObject != null)
                    {
                        string text = "";
                        GameObject targetGameObject = raycastHits.collider.gameObject;
                        if (SATSUMA.Equals(targetGameObject.transform.root.gameObject.name))
                        {
                            text += GameObjectUtil.getGameObjectPath(targetGameObject);
                            if (targetGameObject.name.ToLower().IndexOf("bolt") > -1)
                            {
                                GameObjectUtil.Highlight(targetGameObject);
                            }
                        }
                        GUI.Label(new Rect(Input.mousePosition.x, (-Input.mousePosition.y), Screen.width, Screen.height), text, mouseTipGuiStyle);
                    }
                }
            }
        }

        public void WindowFunction(int windowsId)
        {
            scrollPoint = GUILayout.BeginScrollView(scrollPoint);

            GUILayout.EndScrollView();
            GUI.DragWindow();
        }

    }
   
}
