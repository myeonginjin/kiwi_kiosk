//참여
//2017016935_중국학과_진명인
//2017012488_컴퓨터학부_이현준

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemService : MonoBehaviour
{
    ItemData itemData;

    void Awake()
    {
        itemData = GetComponent<ItemData>();
    }

    public void UpdateIcon()
    {
        UpdateGameObjectName();
        UpdateImage();
    }

    void UpdateGameObjectName()
    {
        gameObject.name = itemData.menuName;
    }

    void UpdateImage()
    {
        if (itemData.itemSprite != null)
            GetComponent<Image>().sprite = itemData.itemSprite;
    }
}