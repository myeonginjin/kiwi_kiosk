//참여
//2017016935_중국학과_진명인
//2017012488_컴퓨터학부_이현준

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
