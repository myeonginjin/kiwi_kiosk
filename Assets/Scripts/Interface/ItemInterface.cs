using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInterface : MonoBehaviour
{
    ItemService itemService;

    void Awake()
    {
        itemService = GetComponent<ItemService>();
        UpdateIcon();
    }

    public void UpdateIcon()
    {
        itemService.UpdateIcon();
    }
}