using System.Collections;
using UnityEngine;

namespace LeoDeg.Scriptables
{
	[CreateAssetMenu(menuName = "LeoDeg/Variables/StateScriptable")]
	public class StateScriptable : ScriptableObject
	{
		public LeoDeg.StateActions.State value;
	}
}