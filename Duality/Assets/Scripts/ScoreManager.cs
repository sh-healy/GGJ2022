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

    public int MinNum = 20;
    public int MaxNum = 100;

    // Start is called before the first frame update
    public int SetUpScore()
    {
        GetFinalNumbers();
        GameManager.Instance.HUDController.SetFinalNumbers(_lFinalNumber.ToString(), _rFinalNumber.ToString());
        GameManager.Instance.HUDController.UpdateCurrentNumbers("0", "0");

        return _lFinalNumber;
    }

    public void UpdateCurrentNumbers(int num)
    {
        if(num > 0) //Left side num
        {
            _lCurrNumber += num;
        }
        else //Right side num
        {
            _rCurrNumber += num;
        }

        bool lMatch = false;
        bool rMatch = false;
        if(_lCurrNumber == _lFinalNumber)
        {
            lMatch = true;
        }
        if(_rCurrNumber == _rFinalNumber)
        {
            rMatch = true;
        }

        GameManager.Instance.HUDController.UpdateCurrentNumbers(_lCurrNumber.ToString(), lMatch, _rCurrNumber.ToString(), rMatch);
    }

    private void GetFinalNumbers()
    {
        System.Random rnd = new System.Random();
        _lFinalNumber  = rnd.Next(MinNum, MaxNum);  // creates a number between 1 and 12
        _rFinalNumber = _lFinalNumber * -1;
    }
}
