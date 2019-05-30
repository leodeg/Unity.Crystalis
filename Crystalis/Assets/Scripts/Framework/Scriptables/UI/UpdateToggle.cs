using UnityEngine.UI;

namespace LeoDeg.UI
{
    public class UpdateToggle : UIPropertyUpdater
    {
        public Scriptables.BoolScriptable boolVariable;
        public Toggle targetToggle;

        /// <summary>
        /// Use this to set the state of a toggle based on a bool variable
        /// </summary>
        public override void Raise()
        {
            targetToggle.isOn = boolVariable.value;
        }
    }
}
