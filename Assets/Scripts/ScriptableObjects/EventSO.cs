using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "ScriptableObjects/Event")]
public class EventSO : ScriptableObject
{
	private event Action _listeners;

	public void Raise()
	{
		_listeners.Invoke();
	}

	public void RegisterListener(Action listener)
	{
		_listeners += listener; 
	}

	public void UnregisterListener(Action listener)
	{
		_listeners -= listener;
	}


}
