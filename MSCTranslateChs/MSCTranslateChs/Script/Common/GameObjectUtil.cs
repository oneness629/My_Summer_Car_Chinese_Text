﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace MSCTranslateChs.Script.Common
{
    class GameObjectUtil
    {
        public static string getGameObjectText(string path,
            int level = 0,
            bool isGetOtherTypeMembers = false,
            bool isGetComponentsText = false, 
            bool isGetComponentTypeFields = false, 
            bool isGetComponentTypeMembers = false, 
            bool isGetComponentTypeMethods = false)
        {
            GameObject gameObject = GameObject.Find(path);
            if (gameObject != null)
            {
                return getGameObjectText(gameObject, 0);
            }
            return null;
        }

        public static string getGameObjectText(GameObject gameObject,
            int level = 0,
            bool isGetOtherTypeMembers = false,
            bool isGetComponentsText = false,
            bool isGetComponentTypeFields = false,
            bool isGetComponentTypeMembers = false,
            bool isGetComponentTypeMethods = false)
        {
            
            if (gameObject != null)
            {
                string text = "";
                string tabText = getLevelText(level);
                text += (tabText + "gameObject.name : " + gameObject.name + "\n");
                if (isGetOtherTypeMembers)
                {
                    tabText += "\t gameObject.tag : " + gameObject.tag + "\n";
                    tabText += "\t gameObject.hideFlags : " + gameObject.hideFlags + "\n";
                    tabText += "\t gameObject.isStatic : " + gameObject.isStatic + "\n";
                    tabText += "\t gameObject.layer : " + gameObject.layer + "\n";
                }
                if (isGetComponentsText)
                {
                    tabText += "\t GetComponentsText : " + GetComponentsText(gameObject, tabText + "\t") + "\n";
                }
                if (gameObject.transform != null && gameObject.transform.childCount > 0)
                {
                    for (int i = 0; i < gameObject.transform.childCount; i++)
                    {
                        text += (getGameObjectText(gameObject.transform.GetChild(i).gameObject, level + 1));
                    }
                }
            }
            return null;
        }


        public static List<GameObject> getTopGameObject()
        {
            GameObject[] allGameObjects = Resources.FindObjectsOfTypeAll<GameObject>();
            List<GameObject> topGameObjectList = new List<GameObject>();
            foreach (GameObject gameObject in allGameObjects)
            {
                if (gameObject != null && gameObject.transform != null && gameObject.transform.parent == null)
                {
                    topGameObjectList.Add(gameObject);
                }
            }
            return topGameObjectList;
        }

        

        private static string GetComponentsNameText(GameObject gameObject)
        {
            string text = "\n";
            if (gameObject != null)
            {
                Component[] Components = gameObject.GetComponents<Component>();
                foreach (Component component in Components)
                {
                    text += ("\t" + "component.GetType().FullName : \t" + component.GetType().FullName + "\n");
                }
            }
            return text;
        }

        private static string GetComponentsText(GameObject gameObject, string levelText,
            bool isGetComponentTypeFields = false,
            bool isGetComponentTypeMembers = false,
            bool isGetComponentTypeMethods = false
            )
        {
            string text = "\n";
            if (gameObject != null)
            {
                Component[] Components = gameObject.GetComponents<Component>();
                foreach (Component component in Components)
                {
                    text += levelText + "\t" + "component.GetType().FullName : \t" + component.GetType().FullName + "\n";
                    if (isGetComponentTypeFields)
                    {
                        levelText += "\t" + "component.GetType().GetFields : \t" + getFieldsString(component.GetType().GetFields(), levelText, component) + "\n";
                    }
                    if (isGetComponentTypeMembers)
                    {
                        levelText += "\t" + "component.GetType().GetMembers : \t" + getGetMembersString(component.GetType().GetMembers(), levelText, component) + "\n";
                    }
                    if (isGetComponentTypeMethods)
                    {
                        levelText += "\t" + "component.GetType().GetMethods : \t" + getGetMethodsString(component.GetType().GetMethods(), levelText, component) + "\n";
                    }
                    text += "\n";
                }
            }
            return text;
        }

        private static string getGetMethodsString(MethodInfo[] methodInfos, string levelText, object obj)
        {
            string text = levelText + "\t getGetMethodsString";
            levelText += "\t";
            foreach (MethodInfo methodInfo in methodInfos)
            {
                text += (
                    levelText + "\t" +
                    "methodInfo -> " + methodInfo.Name + "\t memberInfo.ReturnType: \t" + methodInfo.ReturnType +
                    "\n"
                    );
            }
            return text;
        }

        private static string getGetMembersString(MemberInfo[] memberInfos, string levelText, object obj)
        {
            string text = levelText + "\t getGetMembersString";
            levelText += "\t";
            foreach (MemberInfo memberInfo in memberInfos)
            {
                text += (levelText + "\t" + memberInfo.MemberType + " " + memberInfo.Name + "\n");
            }
            return text;
        }

        private static string getFieldsString(FieldInfo[] fieldInfos, string levelText, object obj)
        {
            string text = levelText + "\t getFieldsString";
            levelText += "\t";
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                text += (levelText + "\t" + fieldInfo.Name + " = " + Convert.ToString(fieldInfo.GetValue(obj)) + "\n");
            }
            return text;
        }

        private static string getLevelText(int level)
        {
            string text = "";
            for (int i = 0; i < level; i++)
            {
                text += "\t";
            }
            return text;
        }


    }
}