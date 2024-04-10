using UnityEngine;
using System;
using System.Collections.Generic;

public class EventManagerEnum : MonoBehaviour
{
    // Enum to represent events
    public enum EventType
    {
        OnButtonClicked,
        OnTransition,
        // Add more events here as needed
    }

    // Dictionary to store event subscribers
    private Dictionary<EventType, Action> eventDictionary;

    // Singleton instance
    private static EventManagerEnum instance;

    // Singleton property
    public static EventManagerEnum Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EventManagerEnum>();
                if (instance == null)
                {
                    GameObject go = new GameObject("EventManager");
                    instance = go.AddComponent<EventManagerEnum>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        eventDictionary = new Dictionary<EventType, Action>();
    }

    // Subscribe to an event
    public void Subscribe(EventType eventType, Action listener)
    {
        Debug.Log(listener);
        if (!eventDictionary.ContainsKey(eventType))
        {
            eventDictionary[eventType] = null;
        }
        eventDictionary[eventType] += listener;
        Debug.Log(" added : " + listener + " to the dictionary");
    }

    // Unsubscribe from an event
    public void Unsubscribe(EventType eventType, Action listener)
    {
        if (eventDictionary.ContainsKey(eventType))
        {
            eventDictionary[eventType] -= listener;
        }
    }

    // Trigger an event
    public void TriggerEvent(EventType eventType)
    {
        Action thisEvent = null;
        if (eventDictionary.TryGetValue(eventType, out thisEvent))
        {
            thisEvent?.Invoke();
            Debug.Log(" triggerd event : " + thisEvent);
        }
    }
}