using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CartItemData
{
    public string menuName;
    public int price;

    public CartItemData(InfoData infoData)
    {
        menuName = infoData.itemData.menuName;
        price = infoData.itemData.price;
    }
}

public class CartData : MonoBehaviour
{
    public List<CartItemData> cart = new List<CartItemData>();
    public int totalPrice = 0;
}