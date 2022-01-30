using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _lFinalNumber;
    private int _rFinalNumber;

    private int _lCurrNumber;
    private int _rCurrNumber;

    // Start is called before the first frame update
    void Awake()
    {
        GetFinalNumbers();
        GameManager.Instance.HUDController.SetFinalNumbers(_lFinalNumber.ToString(), _rFinalNumber.ToString());
        GameManager.Instance.HUDController.UpdateCurrentNumbers("0", "0");
    }

    public void UpdateCurrentNumbers(int num)
    {
        _lCurrNumber += num;
        _rCurrNumber += num;
        GameManager.Instance.HUDController.UpdateCurrentNumbers(_lCurrNumber.ToString(), _rCurrNumber.ToString());
    }

    private void GetFinalNumbers()
    {
        System.Random rnd = new System.Random();
        _lFinalNumber  = rnd.Next(1, 101);  // creates a number between 1 and 12
        _rFinalNumber = _lFinalNumber * -1;
    }
}
