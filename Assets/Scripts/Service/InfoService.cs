using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoService : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI menuNameTMPro;
    public TextMeshProUGUI descriptionTMPro;
    public TextMeshProUGUI priceTMPro;

    InfoData infoData;

    void Awake()
    {
        infoData = GetComponent<InfoData>();
    }

    public void UpdateInfo(ItemData itemData)
    {
        UpdateInfoData(itemData);
        UpdateImage();
        UpdateMenuName();
        UpdateDescription();
        UpdatePrice();
    }

    void UpdateInfoData(ItemData itemData)
    {
        infoData.itemData = itemData;
    }

    void UpdateImage()
    {
        image.sprite = infoData.itemData.sprite;
    }

    void UpdateMenuName()
    {
        menuNameTMPro.text = infoData.itemData.menuName;
    }

    void UpdateDescription()
    {
        descriptionTMPro.text = infoData.itemData.description;
    }

    void UpdatePrice()
    {
        priceTMPro.text = infoData.itemData.price.ToString();
    }
}
