using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDCanvasController : MonoBehaviour
{
    public Text LeftFinalNumber;
    public Text RightFinalNumber;

    public Text LeftCurrentNumber;
    public Text RightCurrentNumber;

    public void SetFinalNumbers(string left, string right)
    {
        LeftFinalNumber.text = left;
        RightFinalNumber.text = right;
    }

    public void UpdateCurrentNumbers(string left, bool lMatch, string right, bool rMatch)
    {
        if(!String.IsNullOrEmpty(left))
        {
            LeftCurrentNumber.text = left;
            SetTextAndColor(LeftCurrentNumber, left, lMatch);
        }

        if(!String.IsNullOrEmpty(right))
        {
            SetTextAndColor(RightCurrentNumber, right, rMatch);
        }
    }

    private void SetTextAndColor(Text text, string newNum, bool match)
    {
        text.text = newNum;
        if(match)
        {
            text.color = Color.green;
        }
        else
        {
            text.color = Color.black;
        }
    }

    public void UpdateCurrentNumbers(string left, string right)
    {
        if(!String.IsNullOrEmpty(left))
        {
            LeftCurrentNumber.text = left;
        }

        if(!String.IsNullOrEmpty(right))
        {
            RightCurrentNumber.text = right;
        }
    }

}
