using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.ScriptableObjects
{
	[CreateAssetMenu(fileName = "New Event", menuName = "ScriptableObjects/Event")]
	public class EventSO : ScriptableObject
	{
		public Dictionary<int, Action> _listeners2 = new Dictionary<int, Action>();
		private event Action _listeners;

		public void Raise()
		{
			_listeners.Invoke();
			foreach (var keyValuePair in _listeners2)
			{
				keyValuePair.Value?.Invoke();
			}
		}

		public void RegisterListener(Action listener)
		{
			_listeners += listener;
			_listeners2.Add(_listeners2.Count, listener);
		}

		public void UnregisterListener(Action listener)
		{
			_listeners -= listener;
			foreach (var keyValuePair in _listeners2)
			{
				if (keyValuePair.Value == listener)
				{
					_listeners2.Remove(keyValuePair.Key);
					break;
				}
			}
		}


	}

}
