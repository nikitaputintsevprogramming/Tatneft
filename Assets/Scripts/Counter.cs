using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public int _count;

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
}