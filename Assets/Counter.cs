using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private bool[] _answers;

    [SerializeField] private int _count;

    void Start()
    {
        _count = 0;
    }

    void Update()
    {
        
    }

    public void UpCount()
    {
        _count++;
    }
}
