using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : DialogueComponent {

    Dialogue Parent;

    protected override void Start()
    {
        base.Start();
        Parent = transform.parent.GetComponent<Dialogue>();
    }

    public override void StartComponent()
    {
        Active = true;
        StartCoroutine(_wait());
    }

    IEnumerator _wait()
    {
        while (Active && Parent.Active)
        {
            yield return null;
        }
    }
}