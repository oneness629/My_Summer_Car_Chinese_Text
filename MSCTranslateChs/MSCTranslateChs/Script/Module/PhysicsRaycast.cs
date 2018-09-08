using MSCTranslateChs.Script.Common;
using MSCTranslateChs.Script.Module.Base;
using UnityEngine;

namespace MSCTranslateChs.Script.Module
{
    public class PhysicsRaycast : BaseModule
    {
        private static readonly LOGGER logger = new LOGGER(typeof(PhysicsRaycast));
        public new string moduleComment = "基础射线";

        public bool isEnable = true;

        public RaycastHit[] mainCameraRaycastHits;

        public RaycastHit mainCameraRaycastHit;


        public override void Update()
        {
            if (GlobalVariables.GetGlobalVariables().isInit)
            {
                if (Camera.main == null)
                {
                    return;
                }
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                mainCameraRaycastHits = Physics.RaycastAll(ray);
                Physics.Raycast(ray, out mainCameraRaycastHit);
            }
        }
    }
}
