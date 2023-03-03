using UnityEngine;

namespace Game.Objects.PowerUps
{
    public sealed class PowerUp : MonoBehaviour //TPFinal - * Federico Krug *.
    {
        [SerializeField] GameObject _powerUpEffect;
        private void Desactive()
        {
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                AddEffect(other.transform);
                Desactive();
            }
        }

        private void AddEffect(Transform other)
        {
            Instantiate(_powerUpEffect, other);
        }
    }
}