using HutongGames.PlayMaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSCTranslateChs.Script.Common
{
    class FsmVariablesUtil
    {

        public static string getAllFsmVariablesAndVaule(FsmVariables fsmVariables)
        {
            string text = "";
            text += getAllBooleanFsmVariables(fsmVariables) + "\n\n\n\n\n";
            text += getAllColorFsmVariables(fsmVariables) + "\n\n\n\n\n";
            text += getAllFloatFsmVariables(fsmVariables) + "\n\n\n\n\n";
            text += getAllGameObjectFsmVariables(fsmVariables) + "\n\n\n\n\n";
            text += getAllIntFsmVariables(fsmVariables) + "\n\n\n\n\n";
            text += getAllObjectFsmVariables(fsmVariables) + "\n\n\n\n\n";
            text += getAllQuaternionFsmVariables(fsmVariables) + "\n\n\n\n\n";
            text += getAllRectFsmVariables(fsmVariables) + "\n\n\n\n\n";
            text += getAllStringFsmVariables(fsmVariables) + "\n\n\n\n\n";
            text += getAllTextureFsmVariables(fsmVariables) + "\n\n\n\n\n";
            text += getAllVector2FsmVariables(fsmVariables) + "\n\n\n\n\n";
            text += getAllVector3FsmVariables(fsmVariables) + "\n\n\n\n\n";
            return text;
        }

        public static string getAllFsmVariablesAndVaule()
        {
            string text = "";
            text += getAllBooleanFsmVariables(FsmVariables.GlobalVariables) + "\n\n\n\n\n";
            text += getAllColorFsmVariables(FsmVariables.GlobalVariables) + "\n\n\n\n\n";
            text += getAllFloatFsmVariables(FsmVariables.GlobalVariables) + "\n\n\n\n\n";
            text += getAllGameObjectFsmVariables(FsmVariables.GlobalVariables) + "\n\n\n\n\n";
            text += getAllIntFsmVariables(FsmVariables.GlobalVariables) + "\n\n\n\n\n";
            text += getAllObjectFsmVariables(FsmVariables.GlobalVariables) + "\n\n\n\n\n";
            text += getAllQuaternionFsmVariables(FsmVariables.GlobalVariables) + "\n\n\n\n\n";
            text += getAllRectFsmVariables(FsmVariables.GlobalVariables) + "\n\n\n\n\n";
            text += getAllStringFsmVariables(FsmVariables.GlobalVariables) + "\n\n\n\n\n";
            text += getAllTextureFsmVariables(FsmVariables.GlobalVariables) + "\n\n\n\n\n";
            text += getAllVector2FsmVariables(FsmVariables.GlobalVariables) + "\n\n\n\n\n";
            text += getAllVector3FsmVariables(FsmVariables.GlobalVariables) + "\n\n\n\n\n";
            return text;
        }


        public static string getAllFsmVariablesGlobalVariablesNames(FsmVariables fsmVariables)
        {
            string text = "";
            foreach (NamedVariable namedVariable in fsmVariables.GetAllNamedVariables())
            {
                text += "namedVariable name: " + namedVariable.Name + "\n";
            }
            return text;
        }

        public static string getAllBooleanFsmVariables(FsmVariables fsmVariables)
        {
            string text = "";
            foreach (FsmBool fsmBool in fsmVariables.BoolVariables)
            {
                text += "fsmBool name: " + fsmBool.Name + ":" + fsmBool.Value + "\n";
            }
            return text;
        }

        public static string getAllColorFsmVariables(FsmVariables fsmVariables)
        {
            string text = "";
            foreach (FsmColor fsmColor in fsmVariables.ColorVariables)
            {
                text += "fsmColor name: " + fsmColor.Name + ":" + fsmColor.Value + "\n";
            }
            return text;
        }

        public static string getAllFloatFsmVariables(FsmVariables fsmVariables)
        {
            string text = "";
            foreach (FsmFloat fsmFloat in fsmVariables.FloatVariables)
            {
                text += "fsmFloat name: " + fsmFloat.Name + ":" + fsmFloat.Value + "\n";
            }
            return text;
        }

        public static string getAllGameObjectFsmVariables(FsmVariables fsmVariables)
        {
            string text = "";
            foreach (FsmGameObject fsmGameObject in fsmVariables.GameObjectVariables)
            {
                text += "fsmGameObject name: " + fsmGameObject.Name + ":" + GameObjectUtil.getGameObjectPath(fsmGameObject.Value) + "\n";
            }
            return text;
        }

        public static string getAllIntFsmVariables(FsmVariables fsmVariables)
        {
            string text = "";
            foreach (FsmInt fsmInt in fsmVariables.IntVariables)
            {
                text += "fsmInt name: " + fsmInt.Name + ":" + fsmInt.Value + "\n";
            }
            return text;
        }

        public static string getAllMaterialFsmVariables(FsmVariables fsmVariables)
        {
            string text = "";
            foreach (FsmMaterial fsmMaterial in fsmVariables.MaterialVariables)
            {
                text += "fsmMaterial name: " + fsmMaterial.Name + ":" + fsmMaterial.Value + "\n";
            }
            return text;
        }

        public static string getAllObjectFsmVariables(FsmVariables fsmVariables)
        {
            string text = "";
            foreach (FsmObject fsmObject in fsmVariables.ObjectVariables)
            {
                text += "fsmObject name: " + fsmObject.Name + ":" + fsmObject.Value + "\n";
            }
            return text;
        }

        public static string getAllQuaternionFsmVariables(FsmVariables fsmVariables)
        {
            string text = "";
            foreach (FsmQuaternion fsmQuaternion in fsmVariables.QuaternionVariables)
            {
                text += "fsmQuaternion name: " + fsmQuaternion.Name + ":" + fsmQuaternion.Value + "\n";
            }
            return text;
        }

        public static string getAllRectFsmVariables(FsmVariables fsmVariables)
        {
            string text = "";
            foreach (FsmRect fsmRect in fsmVariables.RectVariables)
            {
                text += "fsmRect name: " + fsmRect.Name + ":" + fsmRect.Value + "\n";
            }
            return text;
        }

        public static string getAllStringFsmVariables(FsmVariables fsmVariables)
        {
            string text = "";
            foreach (FsmString fsmString in fsmVariables.StringVariables)
            {
                text += "fsmString name: " + fsmString.Name + ":" + fsmString.Value + "\n";
            }
            return text;
        }

        public static string getAllTextureFsmVariables(FsmVariables fsmVariables)
        {
            string text = "";
            foreach (FsmTexture fsmTexture in fsmVariables.TextureVariables)
            {
                text += "fsmTexture name: " + fsmTexture.Name + ":" + fsmTexture.Value + "\n";
            }
            return text;
        }

        public static string getAllVector2FsmVariables(FsmVariables fsmVariables)
        {
            string text = "";
            foreach (FsmVector2 fsmVector2 in fsmVariables.Vector2Variables)
            {
                text += "fsmVector2 name: " + fsmVector2.Name + ":" + fsmVector2.Value + "\n";
            }
            return text;
        }

        public static string getAllVector3FsmVariables(FsmVariables fsmVariables)
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
