using System.Collections;
using UnityEngine;

namespace LeoDeg.Scriptables
{
	[CreateAssetMenu(menuName = "LeoDeg/Variables/IHittableScriptable")]
	public class IHittableScriptable : ScriptableObject
	{
		public LeoDeg.Properties.IHittable value;
	}
}