using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    // Singleton pattern
    public static GameEvents instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance);
    }

    // Actions
    public event Action<int> onEventTrigger;

    public void EventTrigger(int id)
    {
        if (onEventTrigger != null)
        {
            onEventTrigger(id);
        }
    }

    // Function to see list of subscribed events.
    private Func<List<GameObject>> onRequestListOfEvents;
    public void SetOnRequestListOfEvents(Func<List<GameObject>> returnEvent)
    {
        onRequestListOfEvents = returnEvent;
    }

    public List<GameObject> RequestListOfEvents()
    {
        if (onRequestListOfEvents != null)
        {
            return onRequestListOfEvents();
        }
        return null;
    }
}
