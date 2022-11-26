using UnityEngine;

namespace Game.Objects.PowerUps
{
    public sealed class PowerUp : MonoBehaviour
    {
        [SerializeField] GameObject _powerUp;
        private void Desactive()
        {
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                var instantiate = Instantiate(_powerUp, other.transform);
                Debug.Log(instantiate);
                Desactive(); 
            }
        }
    }
}