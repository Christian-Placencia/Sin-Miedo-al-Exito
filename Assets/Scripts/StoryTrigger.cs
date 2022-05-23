using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoryTrigger : MonoBehaviour
{
    public string title;
    public Sprite image;
    public string message;
    public string button1Tag;
    public string button2Tag;
    public string button3Tag;
    public string inputTag;
    public bool triggerOnEnable;

    public UnityEvent onButton1Event;
    public UnityEvent onButton2Event;
    public UnityEvent onButton3Event;
    //public class StoryEvent : UnityEvent { }

    //// Event delegates triggered on click.
    //[SerializeField] private StoryEvent onButton1Event = new StoryEvent();
    //[SerializeField] private StoryEvent onButton2Event = new StoryEvent();
    //[SerializeField] private StoryEvent onButton3Event = new StoryEvent();

    public void OnEnable()
    {
        if (!triggerOnEnable) { return; }

        Action button1Callback = null;
        Action button2Callback = null;
        Action button3Callback = null;

        if (onButton1Event.GetPersistentEventCount() > 0)
        {
            button1Callback = onButton1Event.Invoke;
        }

        if (onButton2Event.GetPersistentEventCount() > 0)
        {
            button2Callback = onButton2Event.Invoke;
        }

        if (onButton3Event.GetPersistentEventCount() > 0)
        {
            button3Callback = onButton3Event.Invoke;
        }

        UIController.instance.storyWindow.StoryEvent(title, image, message, button1Tag, button1Callback, button2Tag, button2Callback, button3Tag, button3Callback, inputTag);
    }
}
