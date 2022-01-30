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
        LeftFinalNumber.text = right;
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
