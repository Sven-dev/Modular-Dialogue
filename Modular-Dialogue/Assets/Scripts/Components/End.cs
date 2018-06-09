using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : DialogueComponent {

    Dialogue Current;

    protected override void Start()
    {
        base.Start();
        Dialogue d = GetComponentInParent<Dialogue>();
        if (d)
        {
            Current = d;
        }
    }

    public override void StartComponent()
    {
        Current.Conversation.Active = false;
    }
}