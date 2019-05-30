using UnityEngine;
using System.Collections;

namespace LeoDeg.Inputs
{
    [CreateAssetMenu (menuName = "LeoDeg/Inputs/InputButton")]
    public class InputButton : Actions.Action
    {
        public enum KeyState { onDown, onCurrent, onUp }

        [Header ("Properties")]
        public string buttonName;
        public bool isPressed;
        public KeyState keyState;

        [Header ("Scriptable Variable")]
        public bool updateVariable = true;
        public Scriptables.BoolScriptable scriptableVariable;

        [Header ("Debug")]
        public bool debugValueToConsole;

        public override void Execute ()
        {
            switch (keyState)
            {
                case KeyState.onDown:
                    isPressed = Input.GetButtonDown (buttonName);
                    break;

                case KeyState.onCurrent:
                    isPressed = Input.GetButton (buttonName);
                    break;

                case KeyState.onUp:
                    isPressed = Input.GetButtonUp (buttonName);
                    break;
            }

            if (updateVariable)
            {
                if (scriptableVariable != null)
                {
                    scriptableVariable.value = isPressed;
                }
                else
                {
                    Debug.LogWarning ("InputButton:Warning: Scriptable variable is not assign");
                }
            }

            if (debugValueToConsole)
            {
                Debug.Log ("AxisName: [" + buttonName + "], IsPressed: " + isPressed + "]");
            }
        }
    }
}