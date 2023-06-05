//참여
//2017016935_중국학과_진명인
//2017012488_컴퓨터학부_이현준

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoService : MonoBehaviour
{
    public GameObject setPopup;
    public GameObject optionPopup;

    public GameObject sideToggleGroup;
    public GameObject drinkToggleGroup;

    Toggle[] sideToggles;
    Toggle[] drinkToggles;

    Image setImage;
    InfoData infoData;

    void Awake()
    {
        setImage = setPopup.GetComponent<Image>();
        infoData = GetComponent<InfoData>();
        sideToggles = sideToggleGroup.GetComponentsInChildren<Toggle>();
        drinkToggles = drinkToggleGroup.GetComponentsInChildren<Toggle>();
    }

    public void InitSetPopup(ItemData itemData)
    {
        setPopup.SetActive(true);
        optionPopup.SetActive(false);
        UpdateSetSprite(itemData);
        UpdateBurgerData(itemData);
        infoData.isSet = false;
    }

    void UpdateSetSprite(ItemData itemData)
    {
        setImage.sprite = itemData.setSprite;
    }

    void UpdateBurgerData(ItemData itemData)
    {
        infoData.burgerData = itemData;
    }

    public void InitOptionPopup()
    {
        setPopup.SetActive(false);
        optionPopup.SetActive(true);
        sideToggles[0].isOn = true;
        drinkToggles[0].isOn = true;
        infoData.isSet = true;
    }

    public void UpdateSideData()
    {
        foreach (Toggle t in sideToggles)
        {
            if (t.isOn)
            {
                infoData.sideData = t.gameObject.GetComponent<ItemData>();
                break;
            }
        }  
    }

    public void UpdateDrinkData()
    {
        foreach (Toggle t in drinkToggles)
        {
            if (t.isOn)
            {
                infoData.drinkData = t.gameObject.GetComponent<ItemData>();
                break;
            }
        }
    }
}
