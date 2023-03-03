using Game.ScriptableObjects;
using UnityEngine;

namespace Game.Player
{
	public class HealthComponent : MonoBehaviour, IDamageable //TPFinal -  Matias Diaz
	{
		[SerializeField] private FloatSO _health;

		public void TakeDamage(float damage)
		{
			_health.Value -= damage;
		}
	}
}
