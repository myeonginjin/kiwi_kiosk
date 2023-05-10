using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemData : MonoBehaviour
{
    public Sprite image;
    public string menu;
    public string description;
    public int price;

    void Awake()
    {
        gameObject.name = menu;
        GetComponentInChildren<TextMeshProUGUI>().text = menu;
        GetComponent<Image>().sprite = image;
    }
}