//참여
//2017016935_중국학과_진명인
//2017012488_컴퓨터학부_이현준

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInterface : MonoBehaviour
{
    ItemService itemService;

    void Awake()
    {
        itemService = GetComponent<ItemService>();
    }

    void Start()
    {
        UpdateIcon();
    }

    public void UpdateIcon()
    {
        itemService.UpdateIcon();
    }
}