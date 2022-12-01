using System.Collections;
using System.Collections.Generic;
using Game.ScriptableObjects;
using UnityEngine;

namespace Game.Player
{
	public class HealthComponent : MonoBehaviour, IDamageable
	{
		[SerializeField] private FloatSO _health;

		public void TakeDamage(float damage)
		{
			_health.Value -= damage;
			
		}

		void Awake()
		{

		}


		void Update()
		{

		}
	}

}
