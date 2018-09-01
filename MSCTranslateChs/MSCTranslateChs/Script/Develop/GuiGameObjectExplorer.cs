using MSCTranslateChs.Script.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class GuiGameObjectExplorer {

    public bool isShow = false;
    public int windowsId = 6293;
    public float windowsWidth = 800;
    public float windowsHeight = 600;
    public Rect windowsRect;
    public Vector2 scrollPosition;
    public Vector2 gameObjectListScrollPosition;
    public Vector2 viewScrollPosition;
    public string searchName = "";

    public GameObject parentGameObject;
    public List<GameObject> gameObjectList;
    public GameObject selectGameObject;
    public List<Component> selectGameObjectComponent;

    public GuiGameObjectExplorer()
    {
        windowsRect = new Rect(Screen.width / 2 - windowsWidth / 2, Screen.height / 2 - windowsHeight / 2, windowsWidth, windowsHeight);
    }

    public void OnGUI()
    {
        if (isShow)
        {
            windowsRect = GUI.Window(windowsId, windowsRect, GuiGameObjectExplorerWindows, "GameObject查看");
            // windowsRect = GUILayout.Window(windowsId, windowsRect, GuiGameObjectExplorerWindows, "GameObject查看");
        }
    }

    private void GuiGameObjectExplorerWindows(int windowsId)
    {

        if (GUILayout.Button("关闭 unity版本:" + Application.unityVersion))
        {
            isShow = false;
        }
        try
        {
            scrollPosition = GUILayout.BeginScrollView(scrollPosition);
        
            GUILayout.BeginArea(new Rect(0, 0, 300, 600));
        
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("读取根节点"))
            {
                parentGameObject = null;
                // gameObjectList = new List<GameObject>(Application. UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects());
                gameObjectList = GameObjectUtil.getRootGameObject();
            }
            
            if (parentGameObject != null)
            {
                if (GUILayout.Button("返回父节点"))
                {
                    if (parentGameObject.transform.parent == null)
                    {
                        parentGameObject = null;
                        gameObjectList = GameObjectUtil.getRootGameObject();
                        // gameObjectList = new List<GameObject>( UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects());
                    }
                    else
                    {
                        gameObjectList = GameObjectUtil.GetChildGameObjectList(parentGameObject.transform.parent.gameObject);
                        parentGameObject = parentGameObject.transform.parent.gameObject;
                    }
                }
            }
            GUILayout.EndHorizontal();
            searchName = GUILayout.TextField(searchName);
            
            gameObjectListScrollPosition = GUILayout.BeginScrollView(gameObjectListScrollPosition);
            if (gameObjectList != null)
            {
                foreach (GameObject gameObject in gameObjectList)
                {
                    if (searchName != null && !searchName.Equals(""))
                    {
                        if (gameObject.name.IndexOf(searchName) == -1)
                        {
                            continue;
                        }
                    }
                    GUILayout.BeginHorizontal();
                    if (GUILayout.Button(gameObject.name))
                    {
                        selectGameObject = gameObject;
                        selectGameObjectComponent = new List<Component>(gameObject.GetComponents<Component>());
                    }
                    if (GUILayout.Button("子节点"))
                    {
                        parentGameObject = gameObject;
                        gameObjectList = GameObjectUtil.GetChildGameObjectList(gameObject);
                    }
                    GUILayout.EndHorizontal();
                }
            }
            GUILayout.EndScrollView();
            
            GUILayout.EndArea();

            
            GUILayout.BeginArea(new Rect(300, 0, 500, 600));
            if (selectGameObject != null)
            {
                GUILayout.Label("选中GameObject:" + GameObjectUtil.getGameObjectPath(selectGameObject));
                viewScrollPosition = GUILayout.BeginScrollView(viewScrollPosition);
                foreach (Component component in selectGameObjectComponent)
                {
                    Type type = component.GetType();
                    GUILayout.Label(type.FullName);
                    GUILayout.BeginVertical("box");
                    foreach (FieldInfo fieldInfo in type.GetFields())
                    {
                        GUILayout.Label(fieldInfo.Name + " : " + fieldInfo.GetValue(component));
                    }
                
                    foreach (PropertyInfo propertyInfo in type.GetProperties())
                    {
                        try
                        {
                            GUILayout.Label("  " + propertyInfo.Name + " : \n" + propertyInfo.GetValue(component, null));
                        }
                        catch (Exception e)
                        {
                            GUILayout.Label("  " + propertyInfo.Name + " : \n Error " + e.Message);
                        }
                    
                    }
                    GUILayout.EndVertical();
                }
                GUILayout.EndScrollView();

            }
            GUILayout.EndArea();
            

            GUILayout.EndScrollView();
        }
        catch (Exception e)
        {
            GUILayout.Label("exception : " + e.Message);
        }
        GUI.DragWindow();
    }
}
