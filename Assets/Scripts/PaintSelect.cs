using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintSelect : MonoBehaviour
{
    public GameObject preview;
    public GameObject msgTxt;

    public string fact;
    Color color;

    private void Start()
    {
        color = gameObject.GetComponent<Image>().color;
    }

    public void SetMsg()
    {
        msgTxt.GetComponent<Text>().text = fact;
    }

    public void SetColor()
    {
        preview.GetComponent<Image>().color = color;
        // Saves the color in player prefs
        PlayerPrefs.SetFloat("r", color.r);
        PlayerPrefs.SetFloat("g", color.g);
        PlayerPrefs.SetFloat("b", color.b);
    }
}
