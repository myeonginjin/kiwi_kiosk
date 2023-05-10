using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoService : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] TextMeshProUGUI price;

    InfoInterface infoInterface;

    void Awake()
    {
        infoInterface = GetComponent<InfoInterface>();
        infoInterface.UpdateInfoEvent += UpdateImage;
        infoInterface.UpdateInfoEvent += UpdateDescription;
        infoInterface.UpdateInfoEvent += UpdatePrice;
    }

    void UpdateImage(ItemData itemData)
    {
        image.sprite = itemData.image;
    }

    void UpdateDescription(ItemData itemData)
    {
        description.text = itemData.description;
    }

    void UpdatePrice(ItemData itemData)
    {
        price.text = itemData.price.ToString();
    }
}
