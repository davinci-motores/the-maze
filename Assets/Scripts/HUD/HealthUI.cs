using Game.ScriptableObjects;
using UnityEngine;

namespace Game.HUD
{
    public class HealthUI : MonoBehaviour //TPFinal -  Matias Diaz
    {
        [SerializeField] private FloatSO _healthPlayer;
        [SerializeField] private FloatEventSO _healthEvent;
        [SerializeField] private RectTransform _rect;
        [SerializeField] private FloatSO _maxHealthPlayer;
        
        private void Start()
        {
            UpdateHealth(_healthPlayer.Value);
            _healthEvent.RegisterListener(UpdateHealth);
        }

        private void OnDestroy()
        {
            _healthEvent.UnregisterListener(UpdateHealth);
        }

        private void UpdateHealth(float a)
        {
            var diff = Mathf.Abs(_maxHealthPlayer.Value - _healthPlayer.Value);
           _rect.offsetMax = new Vector2(diff*-100,0);
        }
    }
}