using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoInterface : MonoBehaviour
{
    public event Action<ItemData> UpdateInfoEvent;

    public void UpdateInfo(ItemData itemData)
    {
        UpdateInfoEvent(itemData);
    }
}
