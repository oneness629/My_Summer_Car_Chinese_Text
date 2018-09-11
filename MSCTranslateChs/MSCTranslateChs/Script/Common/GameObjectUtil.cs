using HutongGames.PlayMaker;
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
        public static FsmGameObject GetPlayMakerFSMGameObject(GameObject targetGameObject, string fsmNameLower, string variablesName)
        {
            PlayMakerFSM[] playMakerFSMArray = targetGameObject.GetComponents<PlayMakerFSM>();

            foreach (PlayMakerFSM playMakerFSM in playMakerFSMArray)
            {
                if (playMakerFSM != null && playMakerFSM.FsmName != null && playMakerFSM.FsmName.ToLower().Equals(fsmNameLower))
                {
                    return playMakerFSM.FsmVariables.FindFsmGameObject(variablesName);
                }
            }
            return null;
        }


        public static List<GameObject> GetChildGameObjectList(GameObject gameObject)
        {
            List<GameObject> gameObjectList = new List<GameObject>();
            if (gameObject == null)
            {
                return gameObjectList;
            }
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                gameObjectList.Add(gameObject.transform.GetChild(i).gameObject);
            }
            return gameObjectList;
        }


        public static List<GameObject> FindChildGameObjectByName(GameObject gameObject, string childName)
        {
            List<GameObject> gameObjectList = new List<GameObject>();
            if (gameObject == null || childName == null || "".Equals(childName))
            {
                return gameObjectList;
            }
            Transform[] transforms = gameObject.GetComponentsInChildren<Transform>();

            foreach (Transform transform in transforms)
            {
                if (transform.gameObject.name.ToLower().Equals(childName.ToLower()))
                {
                    gameObjectList.Add(transform.gameObject);
                }
            }
            return gameObjectList;
        }

        public static List<GameObject> FindChildGameObjectByLikeName(GameObject gameObject, string childName)
        {
            List<GameObject> gameObjectList = new List<GameObject>();
            if (gameObject == null || childName == null || "".Equals(childName))
            {
                return gameObjectList;
            }
            Transform[] transforms = gameObject.GetComponentsInChildren<Transform>();

            foreach (Transform transform in transforms)
            {
                if (transform.gameObject.name.ToLower().IndexOf(childName.ToLower()) > -1)
                {
                    gameObjectList.Add(transform.gameObject);
                }
            }
            return gameObjectList;
        }

        public static List<GameObject> GetChildGameObjectLikeName(GameObject gameObject, string childName)
        {
            List<GameObject> gameObjectList = new List<GameObject>();
            if (gameObject == null || childName == null || "".Equals(childName))
            {
                return gameObjectList;
            }
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                if (gameObject.transform.GetChild(i).name.ToLower().IndexOf(childName.ToLower()) > -1)
                {
                    gameObjectList.Add(gameObject.transform.GetChild(i).gameObject);
                }
            }
            return gameObjectList;
        }


        public static GameObject GetChildGameObjectLikeNameFirst(GameObject gameObject, string childName)
        {
            if (gameObject == null || childName == null || "".Equals(childName))
            {
                return null;
            }
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                if (gameObject.transform.GetChild(i).name.ToLower().IndexOf(childName.ToLower()) > -1)
                {
                    return gameObject.transform.GetChild(i).gameObject;
                }
            }
            return null;
        }

        public static GameObject GetChildGameObject(GameObject gameObject, string childName)
        {
            if (gameObject == null || childName == null || "".Equals(childName))
            {
                return null;
            }
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                if (childName.Equals(gameObject.transform.GetChild(i).name))
                {
                    return gameObject.transform.GetChild(i).gameObject;
                }
            }
            return null;
        }

        public static TextMesh FindGameObjectTextMesh(GameObject gameObject)
        {
            if (gameObject != null)
            {
                TextMesh textMesh = gameObject.GetComponent<TextMesh>();
                if (textMesh != null)
                {
                    return textMesh;
                }
            }
            throw new Exception("无法找到GameObject对应的TextMesh gameObject ->" + gameObject);
        }

        public static TextMesh FindGameObjectTextMesh(string path)
        {
            GameObject gameObject = GameObject.Find(path);
            if (gameObject != null)
            {
                TextMesh textMesh = gameObject.GetComponent<TextMesh>();
                if (textMesh != null)
                {
                    return textMesh;
                }
            }
            throw new Exception("无法找到GameObject对应的TextMesh 路径->" + path);
        }

        public static void AddBoxColliderByChildByTextMesh(GameObject gameObject)
        {
            if (gameObject != null && gameObject.transform != null && gameObject.transform.childCount > 0)
            {
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    GameObject childGameObject = gameObject.transform.GetChild(i).gameObject;
                    if (childGameObject != null)
                    {
                        if (childGameObject.GetComponent<TextMesh>() != null)
                        {
                            AddBoxCollider(childGameObject);
                        }
                        AddBoxColliderByChildByTextMesh(childGameObject);
                    }
                }
            }
        }


        public static void AddBoxColliderByChild(GameObject gameObject, string childText)
        {
            if (gameObject != null && gameObject.transform != null && gameObject.transform.childCount > 0)
            {
                for (int i = 0; i < gameObject.transform.childCount; i++)
                {
                    GameObject childGameObject = gameObject.transform.GetChild(i).gameObject;
                    if (childGameObject != null)
                    {
                        if (childGameObject.GetComponent<TextMesh>() != null)
                        {
                            AddBoxCollider(childGameObject);
                        }
                        AddBoxColliderByChild(childGameObject, childText);
                    }
                }
            }
        }

        public static void AddBoxCollider(GameObject gameObject)
        {
            if (gameObject != null)
            {

                if (gameObject.GetComponent<BoxCollider>() != null)
                {
                    GameObject.Destroy(gameObject.GetComponent<BoxCollider>());
                }
                gameObject.AddComponent<BoxCollider>();
            }
        }

        public static void ChangeGameObjectMaterial(GameObject gameObject, Material material)
        {
            if (gameObject != null && material != null)
            {
                Renderer renderer = gameObject.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material = material;
                }
            }
        }

        public static void ChangeGameObjectColor(GameObject gameObject, Color color)
        {
            if (gameObject != null)
            {
                Renderer renderer = gameObject.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = color;
                }
            }
        }

        public static void ChangeGameObjectColor(GameObject gameObject, Color color, string rendererNameLike)
        {
            if (gameObject != null && rendererNameLike != null)
            {
                Renderer renderer = gameObject.GetComponent<Renderer>();
                if (renderer != null && renderer.name.ToLower().IndexOf(rendererNameLike.ToLower()) > -1)
                {
                    renderer.material.color = color;
                }
            }
        }

        public static string GetGameObjectPath(GameObject gameObject)
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

        public static string GetGameObjectText(string path,
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
                return GetGameObjectText(gameObject, 0, isGetOtherTypeMembers, isGetComponentsText, isGetComponentTypeFields, isGetComponentTypeMembers, isGetComponentTypeMethods);
            }
            return null;
        }

        public static string GetGameObjectTextMeshString(GameObject gameObject)
        {
            if (gameObject != null && gameObject.GetComponent<TextMesh>() != null && gameObject.GetComponent<TextMesh>().text != null)
            {
                return gameObject.GetComponent<TextMesh>().text.Trim();
            }
            return "";
        }

        public static string GetGameObjectText(GameObject gameObject,
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
                string tabText = GetLevelText(level);
                text += (tabText + "gameObject name : " + gameObject.name + "\n");
                text += (tabText + "           path : " + GetGameObjectPath(gameObject) + "\n");
                if (isGetOtherTypeMembers == true)
                {
                    text += tabText + "\t            tag : " + gameObject.tag + "\n";
                    text += tabText + "\t            activeSelf : " + gameObject.activeSelf + "\n";
                    text += tabText + "\t            hideFlags : " + gameObject.hideFlags + "\n";
                    text += tabText + "\t            isStatic : " + gameObject.isStatic + "\n";
                    text += tabText + "\t            layer : " + gameObject.layer + "\n";
                    text += tabText + "\t            position : " + gameObject.transform.position + "\n";
                    text += tabText + "\t            rotation : " + gameObject.transform.rotation + "\n";
                    text += tabText + "\t            localScale : " + gameObject.transform.localScale + "\n";
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
                        text += (GetGameObjectText(gameObject.transform.GetChild(i).gameObject, level + 1,
                            isGetOtherTypeMembers, isGetComponentsText, isGetComponentTypeFields, isGetComponentTypeMembers, isGetComponentTypeMethods));
                    }
                }
                return text;
            }
            return null;
        }


        public static List<GameObject> GetRootGameObject()
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

        public static List<GameObject> GetAllGameObject()
        {
            GameObject[] allGameObjects = Resources.FindObjectsOfTypeAll<GameObject>();
            return new List<GameObject>(allGameObjects); ;
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
                        text += levelText + "\t\t" + "component.GetType().GetFields : \t" + GetFieldsString(component.GetType().GetFields(), levelText, component) + "\n";
                    }
                    if (isGetComponentTypeMembers == true)
                    {
                        text += levelText + "\t\t" + "component.GetType().GetMembers : \t" + GetMembersString(component.GetType().GetMembers(), levelText, component) + "\n";
                    }
                    if (isGetComponentTypeMethods == true)
                    {
                        text += levelText + "\t\t" + "component.GetType().GetMethods : \t" + GetMethodsString(component.GetType().GetMethods(), levelText, component) + "\n";
                    }
                    if (isGetComponentTypeMethods == true)
                    {
                        text += levelText + "\t\t" + "component.GetType().GetProperties : \t" + GetPropertyInfosString(component.GetType().GetProperties(), levelText, component) + "\n";
                    }
                    text += "\n";

                    if (component.GetType().Name.Equals("PlayMakerFSM"))
                    {
                        PlayMakerFSM playMakerFSM = component as PlayMakerFSM;
                        text += levelText + "\t\t" + "Component is PlayMakerFSM : \n" + FsmVariablesUtil.GetAllFsmVariablesAndVaule(playMakerFSM.FsmVariables);
                    }
                    text += "\n";
                }
            }
            return text;
        }

        private static string GetMethodsString(MethodInfo[] methodInfos, string levelText, object obj)
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

        private static string GetMembersString(MemberInfo[] memberInfos, string levelText, object obj)
        {
            string text = levelText + "\t getGetMembersString";
            levelText += "\t";
            foreach (MemberInfo memberInfo in memberInfos)
            {
                text += (levelText + "\t" + memberInfo.MemberType + " " + memberInfo.Name + "\n");
            }
            return text;
        }

        private static string GetFieldsString(FieldInfo[] fieldInfos, string levelText, object obj)
        {
            string text = levelText + "\t getFieldsString";
            levelText += "\t";
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                text += (levelText + "\t" + fieldInfo.Name + " = " + Convert.ToString(fieldInfo.GetValue(obj)) + "\n");
            }
            return text;
        }

        private static string GetPropertyInfosString(PropertyInfo[] propertyInfos, string levelText, object obj)
        {
            string text = levelText + "\t getFieldsString";
            levelText += "\t";
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                try
                {
                    text += (levelText + "\t" + propertyInfo.Name + " = " + Convert.ToString(propertyInfo.GetValue(obj, null)) + "\n");
                }
                catch (Exception e)
                {
                    text += (levelText + "\t" + propertyInfo.Name + " = " + e.Message + "\n");
                }
            }
            return text;
        }

        private static string GetLevelText(int level)
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
