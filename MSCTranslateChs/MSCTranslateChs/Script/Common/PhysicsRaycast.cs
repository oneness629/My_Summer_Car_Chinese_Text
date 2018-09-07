using MSCLoader;
using MSCTranslateChs.Script.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace MSCTranslateChs.Script.Common
{
    public class PhysicsRaycast
    {
        private static readonly LOGGER logger = new LOGGER(typeof(PhysicsRaycast));

        public bool isInit = false;

        public RaycastHit[] mainCameraRaycastHits;

        public RaycastHit mainCameraRaycastHit;


        public void Init()
        {
            this.isInit = true;
        }

        public void Update()
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
