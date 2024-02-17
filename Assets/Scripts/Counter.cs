using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private bool[] _answers;

    [SerializeField] private int _count;
    public bool answer;
    public int numberQuestion;

    void Start()
    {
        ResetCount();
    }

    public void UpCount()
    {
        _count++;
    }

    public void ResetCount()
    {
        _count = 0;
    }

    public void SetTrue()
    {
        answer = true;
    }

    public void SetFalse()
    {
        answer = false;
    }
}