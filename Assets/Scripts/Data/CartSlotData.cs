//참여
//2017016935_중국학과_진명인
//2017012488_컴퓨터학부_이현준

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CartSlotData : MonoBehaviour
{
    public List<CartSlotData> optionSlots = new List<CartSlotData>();

    public TextMeshProUGUI menuNameTMPro;
    public TextMeshProUGUI priceTMPro;
    public Button removeButton;

    public int index;
    public bool isSet;
    public bool isOption;
    public ItemData itemData;
}
