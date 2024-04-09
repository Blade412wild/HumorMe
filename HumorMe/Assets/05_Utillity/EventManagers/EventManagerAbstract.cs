using UnityEngine;
using System;
using System.Collections.Generic;

public class EventManagerAbstract : MonoBehaviour
{
    // Dictionary to store event subscribers
    private Dictionary<Type, Delegate> eventDictionary;

    // Singleton instance
    private static EventManagerAbstract instance;

    // Singleton property
    public static EventManagerAbstract Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EventManagerAbstract>();
                if (instance == null)
                {
                    GameObject go = new GameObject("EventManager");
                    instance = go.AddComponent<EventManagerAbstract>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        eventDictionary = new Dictionary<Type, Delegate>();
    }

    // Subscribe to an event
    public void Subscribe<T>(Action<T> listener) where T : EventArgs
    {
        Type eventType = typeof(T);
        if (!eventDictionary.ContainsKey(eventType))
        {
            eventDictionary[eventType] = null;
        }
        eventDictionary[eventType] = (Action<T>)eventDictionary[eventType] + listener;
    }

    // Unsubscribe from an event
    public void Unsubscribe<T>(Action<T> listener) where T : EventArgs
    {
        Type eventType = typeof(T);
        if (eventDictionary.ContainsKey(eventType))
        {
            eventDictionary[eventType] = (Action<T>)eventDictionary[eventType] - listener;
        }
    }

    // Trigger an event
    public void TriggerEvent<T>(T eventArgs) where T : EventArgs
    {
        Type eventType = typeof(T);
        Delegate thisEvent = null;
        if (eventDictionary.TryGetValue(eventType, out thisEvent))
        {
            (thisEvent as Action<T>)?.Invoke(eventArgs);
        }
    }
}