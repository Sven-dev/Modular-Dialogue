using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [HideInInspector]
    public Conversation Conversation;

    [HideInInspector]
    public bool Active;

    DialogueComponent[] Components;

    private void Start()
    {
        Components = GetComponentsInChildren<DialogueComponent>();
    }

    public void Interact(Conversation conversation)
    {
        Conversation = conversation;
        StartCoroutine(_interaction());
    }

    IEnumerator _interaction()
    {
        Active = true;
        foreach (DialogueComponent c in Components)
        {
            c.StartComponent();

            while(c.Active)
            {
                yield return null;
            }
        }

        Active = false;
        Reset();
    }

    //Resets all components of the Dialogue
    public void Reset()
    {
        foreach (DialogueComponent c in Components)
        {
            c.Reset();
        }
    }
}