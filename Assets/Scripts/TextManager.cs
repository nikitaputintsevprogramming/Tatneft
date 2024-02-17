using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [SerializeField] private Counter _Counter;
    
    public void SetTextCount()
    {
        gameObject.GetComponent<Text>().text = "Поздравляем, вы набрали " + _Counter._count + " из 10 правильных ответов!";
    }
}
