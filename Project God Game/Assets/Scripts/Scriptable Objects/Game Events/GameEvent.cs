using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    private List<GameEventListeners> listeners = new List<GameEventListeners>();

    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListeners listener)
    {
        listeners.Add(listener);
    }

    public void UnRegisterListener(GameEventListeners listener)
    {
        listeners.Remove(listener);
    }
}