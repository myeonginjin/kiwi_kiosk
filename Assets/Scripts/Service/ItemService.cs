using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemService : MonoBehaviour
{
    public TextMeshProUGUI t;

    public void Show(string s)
    {
        t.text = s;
    }
}
