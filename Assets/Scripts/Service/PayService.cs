//참여
//2017012488_컴퓨터학부_이현준

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PayService : MonoBehaviour
{
    public Transform paySlotGroup;
    public GameObject paySlotPrefab;
    public TextMeshProUGUI totalPriceTMPro;
    public TextMeshProUGUI orderNumberTMPro;
    public Button payButton;
    public AudioSource payAudioSource;
    public UnityEvent payEvent;

    PayData payData;

    void Awake()
    {
        payData = GetComponent<PayData>();
    }

    public void ShowPayList(CartData cartData)
    {
        if (cartData.cart.Count == 0)
        {
            totalPriceTMPro.text = $"장바구니가 비어 있습니다.";
            payButton.interactable = false;
            return;
        }

        payButton.interactable = true;
        payData.totalPrice = cartData.totalPrice;

        foreach (CartSlotData cartSlotData in cartData.cart)
        {
            PaySlotData paySlotData = InstantiatePaySlot(cartSlotData);
            payData.slotList.Add(paySlotData);

            foreach (CartSlotData optionSlot in cartSlotData.optionSlots)
            {
                PaySlotData payOptionSlotData = InstantiatePaySlot(optionSlot);
                payData.slotList.Add(payOptionSlotData);
            }
        }

        UpdateTotalPrice();
        totalPriceTMPro.text = $"{payData.totalPrice} 원을 결제합니다.";
    }

    public void ClearPayList()
    {
        foreach (PaySlotData paySlotData in payData.slotList)
            Destroy(paySlotData.gameObject);

        payData.slotList.Clear();
    }

    public void UpdateTakeOut(bool isOn)
    {
        payData.isTakeOut = isOn;
    }

    public void ShowOrderNumber()
    {
        System.Random rand = new System.Random();
        payData.orderNumber = rand.Next(1, 200);
        orderNumberTMPro.text = payData.orderNumber.ToString();
    }

    PaySlotData InstantiatePaySlot(CartSlotData cartSlotData)
    {
        GameObject paySlot = Instantiate(paySlotPrefab, paySlotGroup);
        PaySlotData paySlotData = paySlot.GetComponent<PaySlotData>();

        paySlotData.isSet = cartSlotData.isSet;
        paySlotData.isOption = cartSlotData.isOption;
        paySlotData.itemData = cartSlotData.itemData;

        ShowPaySlotData(paySlotData);

        return paySlotData;
    }

    void ShowPaySlotData(PaySlotData paySlotData)
    {
        paySlotData.itemImage.sprite = paySlotData.itemData.itemSprite;

        if (paySlotData.isSet)
        {
            paySlotData.menuNameTMPro.text = $"{paySlotData.itemData.menuName} 세트";
            paySlotData.priceTMPro.text = $"{paySlotData.itemData.setPrice} 원";
        }
        else
        {
            paySlotData.menuNameTMPro.text = paySlotData.itemData.menuName;
            paySlotData.priceTMPro.text = $"{paySlotData.itemData.price} 원";
        }

        if (paySlotData.isOption)
            paySlotData.menuNameTMPro.text = "(옵션) " + paySlotData.menuNameTMPro.text;
    }

    void UpdateTotalPrice()
    {
        payData.totalPrice = 0;

        foreach (PaySlotData paySlotData in payData.slotList)
        {
            payData.totalPrice += (paySlotData.isSet ?
                paySlotData.itemData.setPrice : paySlotData.itemData.price);
        }
    }
}
