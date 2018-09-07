using HutongGames.PlayMaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSCTranslateChs.Script.Common
{
    class FsmVariablesUtil
    {
        private static readonly LOGGER logger = new LOGGER(typeof(ExecutionTime));

        public static string GetAllFsmVariablesAndVaule(FsmVariables fsmVariables)
        {
            string text = "";
            text += GetAllBooleanFsmVariables(fsmVariables) + "\n\n\n\n\n";
            text += GetAllColorFsmVariables(fsmVariables) + "\n\n\n\n\n";
            text += GetAllFloatFsmVariables(fsmVariables) + "\n\n\n\n\n";
            text += GetAllGameObjectFsmVariables(fsmVariables) + "\n\n\n\n\n";
            text += GetAllIntFsmVariables(fsmVariables) + "\n\n\n\n\n";
            text += GetAllObjectFsmVariables(fsmVariables) + "\n\n\n\n\n";
            text += GetAllQuaternionFsmVariables(fsmVariables) + "\n\n\n\n\n";
            text += GetAllRectFsmVariables(fsmVariables) + "\n\n\n\n\n";
            text += GetAllStringFsmVariables(fsmVariables) + "\n\n\n\n\n";
            text += GetAllTextureFsmVariables(fsmVariables) + "\n\n\n\n\n";
            text += GetAllVector2FsmVariables(fsmVariables) + "\n\n\n\n\n";
            text += GetAllVector3FsmVariables(fsmVariables) + "\n\n\n\n\n";
            return text;
        }

        public static string GetAllFsmVariablesAndVaule()
        {
            string text = "";
            text += GetAllBooleanFsmVariables(FsmVariables.GlobalVariables) + "\n\n\n\n\n";
            text += GetAllColorFsmVariables(FsmVariables.GlobalVariables) + "\n\n\n\n\n";
            text += GetAllFloatFsmVariables(FsmVariables.GlobalVariables) + "\n\n\n\n\n";
            text += GetAllGameObjectFsmVariables(FsmVariables.GlobalVariables) + "\n\n\n\n\n";
            text += GetAllIntFsmVariables(FsmVariables.GlobalVariables) + "\n\n\n\n\n";
            text += GetAllObjectFsmVariables(FsmVariables.GlobalVariables) + "\n\n\n\n\n";
            text += GetAllQuaternionFsmVariables(FsmVariables.GlobalVariables) + "\n\n\n\n\n";
            text += GetAllRectFsmVariables(FsmVariables.GlobalVariables) + "\n\n\n\n\n";
            text += GetAllStringFsmVariables(FsmVariables.GlobalVariables) + "\n\n\n\n\n";
            text += GetAllTextureFsmVariables(FsmVariables.GlobalVariables) + "\n\n\n\n\n";
            text += GetAllVector2FsmVariables(FsmVariables.GlobalVariables) + "\n\n\n\n\n";
            text += GetAllVector3FsmVariables(FsmVariables.GlobalVariables) + "\n\n\n\n\n";
            return text;
        }


        public static string GetAllFsmVariablesGlobalVariablesNames(FsmVariables fsmVariables)
        {
            string text = "";
            foreach (NamedVariable namedVariable in fsmVariables.GetAllNamedVariables())
            {
                text += "namedVariable name: " + namedVariable.Name + "\n";
            }
            return text;
        }

        public static string GetAllBooleanFsmVariables(FsmVariables fsmVariables)
        {
            string text = "";
            foreach (FsmBool fsmBool in fsmVariables.BoolVariables)
            {
                text += "fsmBool name: " + fsmBool.Name + ":" + fsmBool.Value + "\n";
            }
            return text;
        }

        public static string GetAllColorFsmVariables(FsmVariables fsmVariables)
        {
            string text = "";
            foreach (FsmColor fsmColor in fsmVariables.ColorVariables)
            {
                text += "fsmColor name: " + fsmColor.Name + ":" + fsmColor.Value + "\n";
            }
            return text;
        }

        public static string GetAllFloatFsmVariables(FsmVariables fsmVariables)
        {
            string text = "";
            foreach (FsmFloat fsmFloat in fsmVariables.FloatVariables)
            {
                text += "fsmFloat name: " + fsmFloat.Name + ":" + fsmFloat.Value + "\n";
            }
            return text;
        }

        public static string GetAllGameObjectFsmVariables(FsmVariables fsmVariables)
        {
            string text = "";
            foreach (FsmGameObject fsmGameObject in fsmVariables.GameObjectVariables)
            {
                text += "fsmGameObject name: " + fsmGameObject.Name + ":" + GameObjectUtil.GetGameObjectPath(fsmGameObject.Value) + "\n";
            }
            return text;
        }

        public static string GetAllIntFsmVariables(FsmVariables fsmVariables)
        {
            string text = "";
            foreach (FsmInt fsmInt in fsmVariables.IntVariables)
            {
                text += "fsmInt name: " + fsmInt.Name + ":" + fsmInt.Value + "\n";
            }
            return text;
        }

        public static string GetAllMaterialFsmVariables(FsmVariables fsmVariables)
        {
            string text = "";
            foreach (FsmMaterial fsmMaterial in fsmVariables.MaterialVariables)
            {
                text += "fsmMaterial name: " + fsmMaterial.Name + ":" + fsmMaterial.Value + "\n";
            }
            return text;
        }

        public static string GetAllObjectFsmVariables(FsmVariables fsmVariables)
        {
            string text = "";
            foreach (FsmObject fsmObject in fsmVariables.ObjectVariables)
            {
                text += "fsmObject name: " + fsmObject.Name + ":" + fsmObject.Value + "\n";
            }
            return text;
        }

        public static string GetAllQuaternionFsmVariables(FsmVariables fsmVariables)
        {
            string text = "";
            foreach (FsmQuaternion fsmQuaternion in fsmVariables.QuaternionVariables)
            {
                text += "fsmQuaternion name: " + fsmQuaternion.Name + ":" + fsmQuaternion.Value + "\n";
            }
            return text;
        }

        public static string GetAllRectFsmVariables(FsmVariables fsmVariables)
        {
            string text = "";
            foreach (FsmRect fsmRect in fsmVariables.RectVariables)
            {
                text += "fsmRect name: " + fsmRect.Name + ":" + fsmRect.Value + "\n";
            }
            return text;
        }

        public static string GetAllStringFsmVariables(FsmVariables fsmVariables)
        {
            string text = "";
            foreach (FsmString fsmString in fsmVariables.StringVariables)
            {
                text += "fsmString name: " + fsmString.Name + ":" + fsmString.Value + "\n";
            }
            return text;
        }

        public static string GetAllTextureFsmVariables(FsmVariables fsmVariables)
        {
            string text = "";
            foreach (FsmTexture fsmTexture in fsmVariables.TextureVariables)
            {
                text += "fsmTexture name: " + fsmTexture.Name + ":" + fsmTexture.Value + "\n";
            }
            return text;
        }

        public static string GetAllVector2FsmVariables(FsmVariables fsmVariables)
        {
            string text = "";
            foreach (FsmVector2 fsmVector2 in fsmVariables.Vector2Variables)
            {
                text += "fsmVector2 name: " + fsmVector2.Name + ":" + fsmVector2.Value + "\n";
            }
            return text;
        }

        public static string GetAllVector3FsmVariables(FsmVariables fsmVariables)
        {
            string text = ""; 
            foreach (FsmVector3 fsmVector3 in fsmVariables.Vector3Variables)
            {
                text += "fsmVector3 name: " + fsmVector3.Name + ":" + fsmVector3.Value + "\n";
            }
            return text;
        }
    }
}
