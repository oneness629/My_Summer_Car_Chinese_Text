using MSCLoader;
using MSCTranslateChs.Script.Common;
using MSCTranslateChs.Script.Common.Procurios.Public;
using MSCTranslateChs.Script.Common.Translate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using UnityEngine;

namespace MSCTranslateChs.Script.Model
{
    public class MSCTranslate
    {
        private static LOGGER logger = new LOGGER(typeof(MSCTranslate));

        public bool IsEnable = true;
        public bool IsTranslateSubtitles = true;
        public bool IsTranslatePartnames = true;
        public bool IsTranslateInteractions = true;
        public bool IsTranslateGameOverMessage = true;
        public bool IsTranslateUI = true;
        public bool IsTranslateEscInitUI = true;

        public TranslateText translateText;

        public TextMesh gameOverTextMesh;
        public TextMesh subtitlesTextMesh;
        public GUIStyle subtitlesGuiStyle;
        public Rect subtitlesRect;

        public TextMesh partnamesTextMesh;
        public GUIStyle partnamesGuiStyle;
        public Rect partnamesRect;

        public TextMesh interactionsTextMesh;
        public GUIStyle interactionsGuiStyle;
        public Rect interactionsRect;

        public GUIStyle mouseTipGuiStyle;

        public bool isInitUIRayGameObject = false;

        public void Init()
        {
            subtitlesGuiStyle = new GUIStyle();
            subtitlesGuiStyle.alignment = TextAnchor.MiddleCenter;
            subtitlesGuiStyle.fontSize = (int)(14.0f * (float)(Screen.width) / 1000f);
            subtitlesGuiStyle.normal.textColor = new Color(255, 165, 0);

            subtitlesRect = new Rect(0, (Screen.height) / 2.15f, Screen.width, Screen.height);

            partnamesGuiStyle = subtitlesGuiStyle;

            partnamesRect = new Rect(0, (Screen.height) / 2.4f, Screen.width, Screen.height);

            interactionsGuiStyle = new GUIStyle();
            interactionsGuiStyle.alignment = TextAnchor.MiddleCenter;
            interactionsGuiStyle.fontSize = (int)(14.0f * (float)(Screen.width) / 1000f);
            interactionsGuiStyle.normal.textColor = new Color(255, 255, 255);

            interactionsRect = new Rect(0, (Screen.height) / 12f, Screen.width, Screen.height);

            mouseTipGuiStyle = new GUIStyle();
            mouseTipGuiStyle.alignment = TextAnchor.LowerLeft;
            mouseTipGuiStyle.fontSize = (int)(14.0f * (float)(Screen.width) / 1000f);
            mouseTipGuiStyle.normal.textColor = new Color(255, 255, 255);

            translateText = new TranslateText();
        }


        public void OnGUI()
        {
            if (GlobalVariables.GetGlobalVariables().isInit)
            {
                GlobalVariables.GetGlobalVariables().executionTime.Start("字幕");
                if (IsTranslateSubtitles)
                {

                    // 字幕
                    string subtitlesText = subtitlesTextMesh.text.Trim();
                    if (subtitlesTextMesh.gameObject.activeSelf && !string.IsNullOrEmpty(subtitlesText))
                    {
                        GUI.Label(subtitlesRect, translateText.TranslateString(subtitlesText, TranslateText.DICT_SUBTITLE), subtitlesGuiStyle);
                    }
                }
                GlobalVariables.GetGlobalVariables().executionTime.End("字幕");
                GlobalVariables.GetGlobalVariables().executionTime.Start("物品名称");
                if (IsTranslatePartnames)
                {
                    // 部件/物品名称
                    string partnamesText = partnamesTextMesh.text.Trim();
                    if (partnamesTextMesh.gameObject.activeSelf && !string.IsNullOrEmpty(partnamesText))
                    {
                        GUI.Label(partnamesRect, translateText.TranslateString(partnamesText, TranslateText.DICT_PARTNAME), partnamesGuiStyle);
                    }
                }
                GlobalVariables.GetGlobalVariables().executionTime.End("物品名称");
                GlobalVariables.GetGlobalVariables().executionTime.Start("操作动作");
                if (IsTranslateInteractions)
                {
                    // 操作动作
                    string interactionsText = interactionsTextMesh.text.Trim();
                    if (interactionsTextMesh.gameObject.activeSelf && !string.IsNullOrEmpty(interactionsText))
                    {
                        GUI.Label(interactionsRect, translateText.TranslateString(interactionsText, TranslateText.DICT_INTERACTION), interactionsGuiStyle);
                    }
                }
                GlobalVariables.GetGlobalVariables().executionTime.End("操作动作");
                GlobalVariables.GetGlobalVariables().executionTime.Start("GameOver");
                if (IsTranslateGameOverMessage)
                {
                    // game over 提示
                    GameOverMessage();
                }
                GlobalVariables.GetGlobalVariables().executionTime.End("GameOver");
                GlobalVariables.GetGlobalVariables().executionTime.Start("UI");
                if (IsTranslateUI)
                {
                    // 额外的Systems UI菜单
                    TranslateUIRayGameObject();
                }
                GlobalVariables.GetGlobalVariables().executionTime.End("UI");
                GlobalVariables.GetGlobalVariables().executionTime.Start("Esc initUI");
                if (IsTranslateEscInitUI)
                {
                    if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.F1))
                    {
                        InitUIRayGameObject();
                    }
                }
                GlobalVariables.GetGlobalVariables().executionTime.End("Esc initUI");
            }
        }

        public void Update()
        {

        }

        private void InitUIRayGameObject()
        {
            GameObject systemsGameObject = GameObject.Find("Systems");
            if (systemsGameObject != null)
            {
                GameObjectUtil.addBoxColliderByChildByTextMesh(systemsGameObject);
            }
            GameObject hudGameObject = GameObject.Find("GUI/HUD");
            if (hudGameObject != null)
            {
                GameObjectUtil.addBoxColliderByChildByTextMesh(hudGameObject);
            }
        }

        private void TranslateUIRayGameObject()
        {
            if (!isInitUIRayGameObject)
            {
                InitUIRayGameObject();
                isInitUIRayGameObject = true;
            }
            else
            {

                RaycastHit[] raycastHits = GlobalVariables.GetGlobalVariables().physicsRaycast.mainCameraRaycastHits;
                if (raycastHits != null && raycastHits.Length > 0)
                {
                    string text = "";
                    foreach (RaycastHit hitInfo in raycastHits)
                    {
                        
                        if (hitInfo.collider != null)
                        {
                            GameObject gameObject = hitInfo.collider.gameObject;
                            if (gameObject != null && gameObject.layer == 14)
                            {
                                string textMeshString = GameObjectUtil.getGameObjectTextMeshString(gameObject);
                                if (textMeshString != null && textMeshString.Trim().Length > 0)
                                {
                                    text = translateText.TranslateString(textMeshString, TranslateText.DICT_UI);
                                }
                            }
                        }
                    }
                    GUI.Label(new Rect(Input.mousePosition.x, (-Input.mousePosition.y), Screen.width, Screen.height), text, mouseTipGuiStyle);
                }
            }
        }

        public GameObject gameObjectSystems;
        public GameObject gameObjectSystemsDeath;
        public GameObject gameObjectSystemsDeathGameOverScreen;
        public GameObject gameObjectSystemsDeathGameOverScreenPaper;
        public string gameOverMessage;
        public bool isGameOverScreen = false;

        private void GameOverMessageGUI()
        {
            if (gameOverMessage != null && isGameOverScreen)
            {
                GUI.Label(subtitlesRect, gameOverMessage, subtitlesGuiStyle);
            }
        }

        private void GameOverMessage()
        {
            // gameObjectGameOverScreenPaper = GameObject.Find("Systems/Death/GameOverScreen/Paper");
            if (gameObjectSystems == null)
            {
                gameObjectSystems = GameObject.Find("Systems");
            }
            if (gameObjectSystems == null)
            {
                return;
            }
            gameObjectSystemsDeath = GameObjectUtil.GetChildGameObject(gameObjectSystems, "Death");
            if (gameObjectSystemsDeath == null)
            {
                return;
            }
            gameObjectSystemsDeathGameOverScreen = GameObjectUtil.GetChildGameObject(gameObjectSystemsDeath, "GameOverScreen");
            if (gameObjectSystemsDeathGameOverScreen == null)
            {
                return;
            }
            gameObjectSystemsDeathGameOverScreenPaper = GameObjectUtil.GetChildGameObject(gameObjectSystemsDeathGameOverScreen, "Paper");
            if (gameObjectSystemsDeathGameOverScreenPaper == null)
            {
                return;
            }
            for (int i = 0; i < gameObjectSystemsDeathGameOverScreenPaper.transform.childCount; i++)
            {
                isGameOverScreen = false;
                GameObject childGameObject = gameObjectSystemsDeathGameOverScreenPaper.transform.GetChild(i).gameObject;
                if (childGameObject != null && (childGameObject.activeSelf || Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.G)))
                {
                    isGameOverScreen = true;
                    // string path = GameObjectUtil.getGameObjectPath(childGameObject);
                    // string pathTextEn = path + "/TextEN";
                    // GameObject textEnGameObject = GameObject.Find(pathTextEn);
                    GameObject textEnGameObject = GameObjectUtil.GetChildGameObject(childGameObject, "TextEN");
                    if (textEnGameObject != null)
                    {
                        gameOverTextMesh = GameObjectUtil.FindGameObjectTextMesh(textEnGameObject);
                        if (gameOverTextMesh != null)
                        {
                            string gameOverText = gameOverTextMesh.text.Trim();
                            string translateString = translateText.TranslateString(gameOverText, TranslateText.DICT_GAMEOVER);

                            GUI.Label(subtitlesRect, translateString, subtitlesGuiStyle);

                        }
                    }
                }
            }

        }
    }
}
