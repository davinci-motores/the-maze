using Game.ScriptableObjects;
using System;
using System.Collections;
using UnityEngine;

namespace Game.Objects.Interactables
{
    public class PowerUnit : MonoBehaviour, IInteractable //TPFinal -  Matias Diaz 
    {
        [SerializeField] private GameObject _ligth;
        private bool isOn;
        [SerializeField] private PowerUnit _otherPU;
        [SerializeField] private EventSO _deathEvent;
        private Coroutine _coroutine;
        const int _waitSeconds = 10;
        public event Action OnTurnOff;

        public bool IsOn
        {
            get => isOn;
        }

        private void Awake()
        {
            _otherPU.OnTurnOff += StopWait;
            isOn = true;
        }

        private void OnDestroy()
        {
            _otherPU.OnTurnOff -= StopWait;
        }

        private void StopWait()
        {
            if (_coroutine == null) return;
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        [ContextMenu("Interact")]
        public void Interact()
        {
            _ligth.SetActive(false);
            isOn = false;
            if (!_otherPU.IsOn)
            {
                OnTurnOff?.Invoke();

                _deathEvent.Raise();
            }
            else
            {
                if (_coroutine != null)
                {
                    StopCoroutine(_coroutine);
                }

                _coroutine = StartCoroutine(CO_WaitToTurnOn());
                Debug.Log("Falta uno");
            }
        }

        private IEnumerator CO_WaitToTurnOn()
        {
            yield return new WaitForSeconds(_waitSeconds);
            isOn = true;
            _ligth.SetActive(true);
            Debug.Log("IsOn");
        }
    }
}