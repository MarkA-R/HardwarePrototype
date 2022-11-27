using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onButtonClick : MonoBehaviour
{

    public InputField getText;
    public SerialController controller;

    public void onClick()
    {
        if (!getText.text.Contains("COM"))
        {
            return;
        }
        controller.portName = getText.text;
    }
}
