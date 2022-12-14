using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.ScriptableObjects
{
	[CreateAssetMenu(menuName = "ScriptableObjects/Float", fileName = "New FloatSO")]
	public class FloatSO : ScriptableObject
	{
		[SerializeField] private float _value;

		public float Value { get => _value; set => _value = value; }
	}

}
