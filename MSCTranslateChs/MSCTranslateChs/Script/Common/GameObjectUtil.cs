using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace MSCTranslateChs.Script.Common
{
    class GameObjectUtil
    {
        public static Dictionary<string, Color> highlightRendererColorBak = new Dictionary<string, Color>();

        public static void addBoxCollider(GameObject gameObject)
        {
            if (gameObject != null && gameObject.GetComponent<BoxCollider>() == null)
            {
                gameObject.AddComponent<BoxCollider>();
            }
        }

        public static void HighligListConver(List<GameObject> targetList, List<GameObject> oldList)
        {
            RemoveHighlightList(oldList);
            HighlightList(targetList);
        }


        public static void RemoveHighlightList(List<GameObject> gameObjects)
        {
            foreach (GameObject gameObject in gameObjects)
            {
                RemoveHighlight(gameObject);
            }
        }

        public static void HighlightList(List<GameObject> gameObjects)
        {
            foreach (GameObject gameObject in gameObjects)
            {
                Highlight(gameObject);
            }
        }

        public static void Highlight(GameObject gameObject)
        {
            Highlight(gameObject, Color.red);
        }

        public static void Highlight(GameObject gameObject, Color highlightColor)
        {
            if (gameObject != null)
            {
                string fullName = getGameObjectPath(gameObject);
                Renderer renderer = gameObject.GetComponent<Renderer>();
                if (renderer != null)
                {
                    highlightRendererColorBak.Add(fullName, renderer.material.color);
                    renderer.material.color = highlightColor;
                }
            }
        }

        public static void RemoveHighlight(GameObject gameObject)
        {
            if (gameObject != null)
            {
                string fullName = getGameObjectPath(gameObject);
                if (fullName != null)
                {
                    Renderer renderer = gameObject.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        if (highlightRendererColorBak.ContainsKey(fullName))
                        {
                            renderer.material.color = highlightRendererColorBak[fullName];
                            highlightRendererColorBak.Remove(fullName);
                        }
                    }
                }
                
            }
        }

        public static string getGameObjectPath(GameObject gameObject)
        {
            if (gameObject != null)
            {
                string path = gameObject.name;
                if (gameObject.transform != null && gameObject.transform.parent != null && gameObject.transform.parent.gameObject != null)
                {
                    GameObject parentGameObject = gameObject.transform.parent.gameObject;
                    while (parentGameObject != null)
                    {
                        path = parentGameObject.name + "/" + path;
                        if (parentGameObject.transform != null && parentGameObject.transform.parent != null && parentGameObject.transform.parent.gameObject != null)
                        {
                            parentGameObject = parentGameObject.transform.parent.gameObject;
                        }
                        else
                        {
                            parentGameObject = null;
                        }
                    }
                }
                return path;
            }
            return null;
        }

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
                return getGameObjectText(gameObject, 0, isGetOtherTypeMembers, isGetComponentsText, isGetComponentTypeFields, isGetComponentTypeMembers, isGetComponentTypeMethods);
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
                text += (tabText + "gameObject name : " + gameObject.name + "\n");
                text += (tabText + "           path : " + getGameObjectPath(gameObject) + "\n");
                if (isGetOtherTypeMembers == true)
                {
                    text += tabText +"\t            tag : " + gameObject.tag + "\n";
                    text += tabText + "\t            hideFlags : " + gameObject.hideFlags + "\n";
                    text += tabText + "\t            isStatic : " + gameObject.isStatic + "\n";
                    text += tabText + "\t            layer : " + gameObject.layer + "\n";
                }
                if (isGetComponentsText == true)
                {
                    text += tabText + ("\t            ComponentsText : " + 
                        GetComponentsText(gameObject, tabText + "\t", 
                        isGetComponentTypeFields, isGetComponentTypeMembers, isGetComponentTypeMethods) + "\n");
                }
                if (gameObject.transform != null && gameObject.transform.childCount > 0)
                {
                    for (int i = 0; i < gameObject.transform.childCount; i++)
                    {
                        text += (getGameObjectText(gameObject.transform.GetChild(i).gameObject, level + 1, 
                            isGetOtherTypeMembers, isGetComponentsText, isGetComponentTypeFields, isGetComponentTypeMembers, isGetComponentTypeMethods));
                    }
                }
                return text;
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

        

        private static string GetComponentsText(GameObject gameObject, string levelText,
            bool isGetComponentTypeFields = false,
            bool isGetComponentTypeMembers = false,
            bool isGetComponentTypeMethods = false
            )
        {
            string text = "";
            if (gameObject != null)
            {
                Component[] Components = gameObject.GetComponents<Component>();
                text += levelText + "\t\t Component size -> " + Components.Count() + "\n";
                foreach (Component component in Components)
                {
                    text += levelText + "\t\t" + "component.GetType().FullName : \t" + component.GetType().FullName + "\n";
                    if (isGetComponentTypeFields == true)
                    {
                        text += levelText + "\t\t" + "component.GetType().GetFields : \t" + getFieldsString(component.GetType().GetFields(), levelText, component) + "\n";
                    }
                    if (isGetComponentTypeMembers == true)
                    {
                        text += levelText + "\t\t" + "component.GetType().GetMembers : \t" + getGetMembersString(component.GetType().GetMembers(), levelText, component) + "\n";
                    }
                    if (isGetComponentTypeMethods == true)
                    {
                        text += levelText + "\t\t" + "component.GetType().GetMethods : \t" + getGetMethodsString(component.GetType().GetMethods(), levelText, component) + "\n";
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
