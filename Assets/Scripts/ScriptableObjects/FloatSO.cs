using System;
using UnityEngine;

namespace Game.ScriptableObjects
{
	[CreateAssetMenu(menuName = "ScriptableObjects/Float", fileName = "New FloatSO")]
	public class FloatSO : ScriptableObject
	{
		[SerializeField] private float _value;
		public event Action<float> OnChangeEvent;

		public float Value
		{
			get => _value;
			set
			{
				_value = value;
				OnChangeEvent?.Invoke(_value);
			}
		}
	}

}
