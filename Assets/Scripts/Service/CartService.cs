//참여
//2017016935_중국학과_진명인
//2017012488_컴퓨터학부_이현준

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CartService : MonoBehaviour
{
    public Transform cartSlotGroup;
    public GameObject cartSlotPrefab;
    public TextMeshProUGUI totalPriceTMPro;

    CartInterface cartInterface;
    CartData cartData;

    void Awake()
    {
        cartInterface = GetComponent<CartInterface>();
        cartData = GetComponent<CartData>();
    }

    public void AddCart(ItemData itemData)
    {
        CartSlotData cartSlotData = InstantiateCartSlot(itemData);
        cartData.cart.Add(cartSlotData);
        AddTotalPrice(cartSlotData);
    }

    public void AddCart(InfoData infoData)
    {
        CartSlotData cartSlotData = InstantiateCartSlot(infoData);
        cartData.cart.Add(cartSlotData);
        AddTotalPrice(cartSlotData);
    }

    public void RemoveCart(int index)
    {
        CartSlotData cartSlotData = cartData.cart[index];

        cartData.cart.RemoveAt(index);
        UpdateCartSlotIndex(index);
        SubTotalPrice(cartSlotData);

        foreach (CartSlotData optionSlot in cartSlotData.optionSlots)
            Destroy(optionSlot.gameObject);

        cartSlotData.optionSlots.Clear();
        Destroy(cartSlotData.gameObject);
    }

    CartSlotData InstantiateCartSlot(ItemData itemData, bool isSet = false, bool isOption = false)
    {
        GameObject cartSlot = Instantiate(cartSlotPrefab, cartSlotGroup);
        CartSlotData cartSlotData = cartSlot.GetComponent<CartSlotData>();

        cartSlotData.itemData = itemData;
        cartSlotData.isSet = isSet;
        cartSlotData.isOption = isOption;

        ShowCartSlotData(cartSlotData);

        return cartSlotData;
    }

    CartSlotData InstantiateCartSlot(InfoData infoData)
    {
        CartSlotData burgerSlotData = InstantiateCartSlot(infoData.burgerData, infoData.isSet, false);

        if (infoData.isSet)
        {
            CartSlotData sideSlotData = InstantiateCartSlot(infoData.sideData, false, true);
            CartSlotData drinkSlotData = InstantiateCartSlot(infoData.drinkData, false, true);

            burgerSlotData.optionSlots.Add(sideSlotData);
            burgerSlotData.optionSlots.Add(drinkSlotData);
        }

        return burgerSlotData;
    }

    void ShowCartSlotData(CartSlotData cartSlotData)
    {
        if (cartSlotData.isSet)
        {
            cartSlotData.menuNameTMPro.text = $"{cartSlotData.itemData.menuName} 세트";
            cartSlotData.priceTMPro.text = $"{cartSlotData.itemData.setPrice} 원";
        }
        else
        {
            cartSlotData.menuNameTMPro.text = cartSlotData.itemData.menuName;
            cartSlotData.priceTMPro.text = $"{cartSlotData.itemData.price} 원";
        }

        if (cartSlotData.isOption)
        {
            cartSlotData.menuNameTMPro.text = "└옵션 : " + cartSlotData.menuNameTMPro.text;
            cartSlotData.priceTMPro.text = "+" + cartSlotData.priceTMPro.text;
            cartSlotData.removeButton.gameObject.SetActive(false);
        }
        else
        {
            cartSlotData.index = cartData.cart.Count;
            cartSlotData.removeButton.onClick.AddListener(
                () => cartInterface.RemoveCart(cartSlotData.index));
        }
    }

    void UpdateCartSlotIndex(int index)
    {
        for (int i = index; i < cartData.cart.Count; i++)
            cartData.cart[i].index = i;
    }

    void AddTotalPrice(CartSlotData cartSlotData)
    {
        cartData.totalPrice += (cartSlotData.isSet ?
            cartSlotData.itemData.setPrice : cartSlotData.itemData.price);

        foreach (CartSlotData optionSlot in cartSlotData.optionSlots)
            cartData.totalPrice += optionSlot.itemData.price;

        UpdateTotalPrice();
    }

    void SubTotalPrice(CartSlotData cartSlotData)
    {
        cartData.totalPrice -= (cartSlotData.isSet ?
            cartSlotData.itemData.setPrice : cartSlotData.itemData.price);

        foreach (CartSlotData optionSlot in cartSlotData.optionSlots)
            cartData.totalPrice -= optionSlot.itemData.price;

        UpdateTotalPrice();
    }

    void UpdateTotalPrice()
    {
        totalPriceTMPro.text = $"{cartData.totalPrice} 원";
    }
}
