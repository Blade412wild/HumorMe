using UnityEngine;
using System;
using System.Collections.Generic;

public class EventManager : MonoBehaviour
{
    // Dictionary to store event subscribers
    private Dictionary<string, Action> eventDictionary;

    // Singleton instance
    private static EventManager instance;

    // Singleton property
    public static EventManager Instance
    {
        get
        {
            // If the instance is null, find it in the scene
            if (instance == null)
            {
                instance = FindObjectOfType<EventManager>();

                // If it's still null, create a new GameObject with the EventManager attached
                if (instance == null)
                {
                    GameObject eventManager= new GameObject("EventManager");
                    instance = eventManager.AddComponent<EventManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        // Initialize the dictionary
        eventDictionary = new Dictionary<string, Action>();
    }

    // Subscribe to an event
    public void Subscribe(string eventName, Action listener)
    {
        if (!eventDictionary.ContainsKey(eventName))
        {
            eventDictionary[eventName] = null;
        }
        eventDictionary[eventName] += listener;
    }

    // Unsubscribe from an event
    public void Unsubscribe(string eventName, Action listener)
    {
        if (eventDictionary.ContainsKey(eventName))
        {
            eventDictionary[eventName] -= listener;
        }
    }

    // Trigger an event
    public void TriggerEvent(string eventName)
    {
        Action thisEvent = null;
        if (eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent?.Invoke();
        }
    }
}