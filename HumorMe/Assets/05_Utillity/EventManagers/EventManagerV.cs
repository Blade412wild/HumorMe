using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum EventType
{
    OnButtonClicked
}

public static class EventManagerV<T>
{
    private static Dictionary<EventType, Action> eventDictionary = new Dictionary<EventType, Action>();

    public static void AddListener(EventType type, Action function)
    {
        if (!eventDictionary.ContainsKey(type))
        {
            eventDictionary.Add(type, null);
        }

        eventDictionary[type] += function;
    }

    public static void RemoveListener(EventType type, Action function)
    {
        if (eventDictionary.ContainsKey(type) && eventDictionary[type] != null)
        {
            eventDictionary[type] -= function;
        }
    }

    public static void InvokeEvent(EventType type)
    {
        eventDictionary[type]?.Invoke();
    }

}
