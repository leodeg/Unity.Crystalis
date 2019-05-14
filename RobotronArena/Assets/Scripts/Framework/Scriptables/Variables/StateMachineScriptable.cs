using System.Collections;
using UnityEngine;

namespace LeoDeg.Scriptables
{
	[CreateAssetMenu(menuName = "LeoDeg/Variables/StateMachineScriptable")]
	public class StateMachineScriptable : ScriptableObject
	{
		public LeoDeg.StateActions.StateMachine value;
	}
}