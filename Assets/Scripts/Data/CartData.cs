
//2017016935_중국학과_진명인
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartData : MonoBehaviour
{
    private static CartData instance;
    private List<ItemData.Burger> selectedMenuList;

    public Text cartText;
    public Text totalPriceText;

    private void Awake()
    {
        instance = this;
        selectedMenuList = new List<ItemData.Burger>();
    }

    public static CartData GetInstance()
    {
        return instance;
    }

    public void AddToCart(ItemData item)
    {
        ItemData.Burger burger = item.isSetMenu ? item.GetSetMenu() : new ItemData.Burger(item.itemName, item.itemPrice);
        selectedMenuList.Add(burger);
        ShowCart();
    }

    public void RemoveFromCart(int index)
    {
        selectedMenuList.RemoveAt(index);
        ShowCart();
    }

    public void ShowCart()
    {
        cartText.text = "";
        float totalPrice = 0;

        for (int i = 0; i < selectedMenuList.Count; i++)
        {
            cartText.text += selectedMenuList[i].name + " " + selectedMenuList[i].price + "\n";
            totalPrice += selectedMenuList[i].price;
        }

        totalPriceText.text = "Total: " + totalPrice;

        Debug.Log(cartText.text);
    }
}
