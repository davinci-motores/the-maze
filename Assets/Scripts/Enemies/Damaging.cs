using Game.Player;
using UnityEngine;

namespace Game.Enemies
{
    //TPFinal - Gabriel Rodriguez
    public class Damaging : MonoBehaviour
    {
        [SerializeField] private float damage;

        private void OnTriggerEnter(Collider other)
        {
            other.GetComponent<IDamageable>()?.TakeDamage(damage);
        }
    }
}