using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : Counter
{
    void Start()
    {
        if(answer)
        {
            gameObject.GetComponent<Text>().text = "Совершенно верно!";
        }
        else
        {
            gameObject.GetComponent<Text>().text = "Неверно!";
        }
    }
}
