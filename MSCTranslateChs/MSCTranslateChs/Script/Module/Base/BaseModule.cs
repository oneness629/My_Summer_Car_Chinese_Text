using MSCTranslateChs.Script.Common;

namespace MSCTranslateChs.Script.Module.Base
{

    public class BaseModule
    {
        private static readonly LOGGER logger = new LOGGER(typeof(BaseModule));

        public string moduleComment = "基础模块";

        public virtual void Init()
        {

        }

        public virtual void OnGUI()
        {
        }

        public virtual void Update()
        {
        }

    }
   
}
