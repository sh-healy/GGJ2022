using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number : MonoBehaviour
{
    private int _value;
    public TextMesh ValueText;

    public int Value
    {
        get
        {
            return _value;
        }
        set
        {
            _value = value;
            ValueText.text = Value.ToString();
        }
    }

    void onAwake()
    {
        ValueText.text = Value.ToString();
    }

    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.Instance.ScoreManager.UpdateCurrentNumbers(_value);
            gameObject.SetActive(false);
        }
    }
}
