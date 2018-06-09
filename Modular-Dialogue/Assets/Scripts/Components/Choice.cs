using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : DialogueComponent {

    public List<Dialogue> Dialogues;
    List<GameObject> Buttons;
    Dialogue Current;

    // Use this for initialization
    protected override void Start ()
    {
        base.Start();
        Dialogue d = GetComponentInParent<Dialogue>();
        if (d)
        {
            Current = d;
        }

        Buttons = new List<GameObject>();
        foreach (Transform child in transform)
        {
            Buttons.Add(child.gameObject);
            Reset();
        }
    }

    public void NextDialogue(int i)
    {
        Active = false;
        Dialogues[i].Interact(Current.Conversation);
        Reset();
    }

    public override void StartComponent()
    {
        Active = true;
        foreach(GameObject g in Buttons)
        {
            g.SetActive(true);
        }

        StartCoroutine(_wait());
    }

    IEnumerator _wait()
    {
        while (Active)
        {
            yield return null;
        }
    }

    public override void Reset()
    {
        foreach (GameObject g in Buttons)
        {
            g.SetActive(false);
        }
    }
}