using MSCTranslateChs.Script.Common;
using MSCTranslateChs.Script.Common.Translate;
using MSCTranslateChs.Script.Module.Base;
using UnityEngine;

namespace MSCTranslateChs.Script.Module
{
    public class MSCTranslate : BaseModule
    {
        private static readonly LOGGER logger = new LOGGER(typeof(MSCTranslate));
        public override string ModuleComment { get => "文本翻译"; }

        public bool isTranslateSubtitles = true;
        public bool isTranslatePartnames = true;
        public bool isTranslateInteractions = true;
        public bool isTranslateGameOverMessage = true;
        public bool isTranslateUI = true;
        public bool isTranslateEscInitUI = true;

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

        public GameObject gameObjectSystemsDeath;
        public GameObject gameObjectSystemsDeathGameOverScreen;
        public GameObject gameObjectSystemsDeathGameOverScreenPaper;

        public bool isInitUIRayGameObject = false;

        public override void Init()
        {
            subtitlesGuiStyle = new GUIStyle()
            {
                alignment = TextAnchor.MiddleCenter,
                fontSize = (int)(14.0f * (float)(Screen.width) / 1000f)
            };
            subtitlesGuiStyle.normal.textColor = new Color(255, 165, 0);

            subtitlesRect = new Rect(0, (Screen.height) / 2.15f, Screen.width, Screen.height);

            partnamesGuiStyle = subtitlesGuiStyle;

            partnamesRect = new Rect(0, (Screen.height) / 2.4f, Screen.width, Screen.height);

            interactionsGuiStyle = new GUIStyle()
            {
                alignment = TextAnchor.MiddleCenter,
                fontSize = (int)(14.0f * (float)(Screen.width) / 1000f)
            };
            interactionsGuiStyle.normal.textColor = new Color(255, 255, 255);

            interactionsRect = new Rect(0, (Screen.height) / 12f, Screen.width, Screen.height);

            mouseTipGuiStyle = new GUIStyle()
            {
                alignment = TextAnchor.LowerLeft,
                fontSize = (int)(14.0f * (float)(Screen.width) / 1000f)
            };
            mouseTipGuiStyle.normal.textColor = new Color(255, 255, 255);

            subtitlesTextMesh = GameObjectUtil.FindGameObjectTextMesh("GUI/Indicators/Subtitles");
            partnamesTextMesh = GameObjectUtil.FindGameObjectTextMesh("GUI/Indicators/Partname");
            interactionsTextMesh = GameObjectUtil.FindGameObjectTextMesh("GUI/Indicators/Interaction");

            translateText = new TranslateText();
        }


        public override void OnGUI()
        {
            if (GlobalVariables.GetGlobalVariables().isInit)
            {
                GlobalVariables.GetGlobalVariables().executionTime.Start(ModuleComment + " 字幕 OnGUI");
                if (isTranslateSubtitles)
                {
                    // 字幕
                    string subtitlesText = subtitlesTextMesh.text.Trim();
                    if (subtitlesTextMesh.gameObject.activeSelf && !string.IsNullOrEmpty(subtitlesText))
                    {
                        GUI.Label(subtitlesRect, translateText.TranslateString(subtitlesText, TranslateText.DICT_SUBTITLE), subtitlesGuiStyle);
                    }
                }
                GlobalVariables.GetGlobalVariables().executionTime.End(ModuleComment + " 字幕 OnGUI");
                GlobalVariables.GetGlobalVariables().executionTime.Start(ModuleComment + " 部件/物品名称 OnGUI");
                if (isTranslatePartnames)
                {
                    // 部件/物品名称
                    string partnamesText = partnamesTextMesh.text.Trim();
                    if (partnamesTextMesh.gameObject.activeSelf && !string.IsNullOrEmpty(partnamesText))
                    {
                        GUI.Label(partnamesRect, translateText.TranslateString(partnamesText, TranslateText.DICT_PARTNAME), partnamesGuiStyle);
                    }
                }
                GlobalVariables.GetGlobalVariables().executionTime.End(ModuleComment + " 部件/物品名称 OnGUI");
                GlobalVariables.GetGlobalVariables().executionTime.Start(ModuleComment + " 操作动作 OnGUI");
                if (isTranslateInteractions)
                {
                    // 操作动作
                    string interactionsText = interactionsTextMesh.text.Trim();
                    if (interactionsTextMesh.gameObject.activeSelf && !string.IsNullOrEmpty(interactionsText))
                    {
                        GUI.Label(interactionsRect, translateText.TranslateString(interactionsText, TranslateText.DICT_INTERACTION), interactionsGuiStyle);
                    }
                }
                GlobalVariables.GetGlobalVariables().executionTime.End(ModuleComment + " 操作动作 OnGUI");
                GlobalVariables.GetGlobalVariables().executionTime.Start(ModuleComment + " GameOver OnGUI");
                if (isTranslateGameOverMessage)
                {
                    // game over 提示
                    GameOverMessage();
                }
                GlobalVariables.GetGlobalVariables().executionTime.End(ModuleComment + " GameOver OnGUI");
                GlobalVariables.GetGlobalVariables().executionTime.Start(ModuleComment + " UI OnGUI");
                if (isTranslateUI)
                {
                    // 额外的Systems UI菜单
                    TranslateUIRayGameObject();
                }
                GlobalVariables.GetGlobalVariables().executionTime.End(ModuleComment + " UI OnGUI");
                
            }
        }

        public override void Update()
        {
            GlobalVariables.GetGlobalVariables().executionTime.Start(ModuleComment + " ESC 初始化UI Update");
            if (isTranslateEscInitUI)
            {
                if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.F1))
                {
                    InitUIRayGameObject();
                }
            }
            GlobalVariables.GetGlobalVariables().executionTime.End(ModuleComment + " ESC 初始化UI Update");
        }

        private void InitUIRayGameObject()
        {
            if (GlobalVariables.GetGlobalVariables().gameObjectSystems != null)
            {
                GameObjectUtil.AddBoxColliderByChildByTextMesh(GlobalVariables.GetGlobalVariables().gameObjectSystems);
            }
            if (GlobalVariables.GetGlobalVariables().gameObjectGuiHud != null)
            {
                GameObjectUtil.AddBoxColliderByChildByTextMesh(GlobalVariables.GetGlobalVariables().gameObjectGuiHud);
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
                                string textMeshString = GameObjectUtil.GetGameObjectTextMeshString(gameObject);
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

        

        private void GameOverMessage()
        {
            // gameObjectGameOverScreenPaper = GameObject.Find("Systems/Death/GameOverScreen/Paper");
            if (GlobalVariables.GetGlobalVariables().gameObjectSystems == null)
            {
                return;
            }
            gameObjectSystemsDeath = GameObjectUtil.GetChildGameObject(GlobalVariables.GetGlobalVariables().gameObjectSystems, "Death");
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
                GameObject childGameObject = gameObjectSystemsDeathGameOverScreenPaper.transform.GetChild(i).gameObject;
                if (childGameObject != null && (childGameObject.activeSelf || Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.G)))
                {
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
