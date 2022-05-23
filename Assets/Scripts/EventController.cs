using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public int id;

    // Start is called before the first frame update
    private void Start()
    {
        // Subscribe to Event Trigger.
        GameEvents.instance.onEventTrigger += OnEventTrigger;
    }

    private void OnEventTrigger(int id)
    {
        if (id == this.id)
        {
            Debug.Log("Event Triggered");
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe to Event Trigger.
        GameEvents.instance.onEventTrigger -= OnEventTrigger;
    }
}
