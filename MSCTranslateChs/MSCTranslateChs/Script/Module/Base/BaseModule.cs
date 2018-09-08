using MSCTranslateChs.Script.Common;

namespace MSCTranslateChs.Script.Module.Base
{

    public abstract class BaseModule
    {
        private static readonly LOGGER logger = new LOGGER(typeof(BaseModule));

        public virtual string ModuleComment { get;  set; }

        public virtual bool IsEnable { get; set; }

        public abstract void Init();

        public abstract void OnGUI();

        public abstract void Update();

    }
   
}
