using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartInterface : MonoBehaviour
{
    CartService cartService;

    void Awake()
    {
        cartService = GetComponent<CartService>();
    }

    public void AddCart(InfoData infoData)
    {
        cartService.AddCart(infoData);
    }

    public void RemoveCart(int index)
    {
        cartService.RemoveCart(index);
    }
}
