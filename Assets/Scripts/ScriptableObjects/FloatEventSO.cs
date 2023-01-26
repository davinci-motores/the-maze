using System;
using UnityEngine;

namespace Game.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New FloatEventSO", menuName = "ScriptableObjects/Float Event", order = 0)]
    public class FloatEventSO : ScriptableObject
    {
        [SerializeField] private FloatSO _floatSO;

        public void RegisterListener(Action<float> listener)
        {
            _floatSO.OnChangeEvent += listener;
        }

        public void UnregisterListener(Action<float> listener)
        {
            _floatSO.OnChangeEvent -= listener;
        }
    }
}