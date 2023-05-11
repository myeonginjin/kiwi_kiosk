using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics;

public class CartService : MonoBehaviour
{
    public TextMeshProUGUI cartTMPro;
    public TextMeshProUGUI totalPriceTMPro;
    StringBuilder stringBuilder = new StringBuilder();

    CartData cartData;

    void Awake()
    {
        cartData = GetComponent<CartData>();
    }

    public void AddCart(InfoData infoData)
    {
        cartData.cart.Add(new CartItemData
        {
            menuName = infoData.itemData.menuName,
            price = infoData.itemData.price
        });

        UpdateCart();
    }

    public void RemoveCart(int index)
    {
        cartData.cart.RemoveAt(index);
        UpdateCart();
    }

    void UpdateCart()
    {
        stringBuilder.Clear();
        cartData.totalPrice = 0;

        foreach (CartItemData cartItemData in cartData.cart)
        {
            stringBuilder.Append(
                $"{cartItemData.menuName} : {cartItemData.price}¿ø\n");
            cartData.totalPrice += cartItemData.price;
        }

        cartTMPro.text = stringBuilder.ToString();
        totalPriceTMPro.text = $"{cartData.totalPrice}¿ø";
    }
}
