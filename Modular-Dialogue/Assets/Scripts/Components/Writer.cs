using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Writer : DialogueComponent
{
    private Text Label;
    private string Text;
    public float WritingSpeed;

    private float timeStamp;
    private int CurrentLetter;

    // Use this for initialization
    protected override void Start()
    {
        Label = GetComponent<Text>();
        Label.enabled = false;
        timeStamp = Time.time;
    }

    public override void StartComponent()
    {
        Text = Label.text;
        Label.text = "";
        Label.enabled = true;

        Active = true;
        StartCoroutine(_writing());
    }

    IEnumerator _writing()
    {
        while (Active)
        {
            InputCheck();
            if (!IsWriteDone())
            {
                Write();
            }

            yield return null;
        }

        yield return new WaitForEndOfFrame();
    }

    void InputCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(!IsWriteDone())
            {
                FinishWrite();

                return;
            }

            Active = false;
        }
    }

    //Checks the progress of the textwriting, returns true if finished
    public virtual bool IsWriteDone()
    {
        if (CurrentLetter == Text.Length + 1)
        {
            Active = false;
            return true;
        }

        return false;
    }

    //Adds a letter to the label, if the textspeed is reached.
    private void Write()
    {
        if (Time.time > timeStamp + WritingSpeed * Time.fixedDeltaTime)
        {
            Label.text = Text.Substring(0, CurrentLetter);
            CurrentLetter++;
            timeStamp = Time.time;
        }
    }

    //Finishes the sentence.
    public virtual void FinishWrite()
    {
        CurrentLetter = Text.Length;
    }

    public override void Reset()
    {
        Label.enabled = false;

        Label.text = Text;
        Text = "";
        CurrentLetter = 0;
    }
}