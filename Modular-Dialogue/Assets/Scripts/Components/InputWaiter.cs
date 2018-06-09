using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputWaiter : DialogueComponent {

    public override void StartComponent()
    {
        StartCoroutine(_waitForInput());
    }

    public override void Reset() {}

    IEnumerator _waitForInput()
    {
        Active = true;
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }

        yield return new WaitForEndOfFrame();

        Active = false;
    }
}