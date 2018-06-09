using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : DialogueComponent
{
    Image Box;

	// Use this for initialization
	protected override void Start ()
    {
        Box = GetComponent<Image>();
        Reset();
	}

    public override void StartComponent()
    {
        Box.enabled = true;
    }

    public override void Reset()
    {
        Box.enabled = false;
    }
}
