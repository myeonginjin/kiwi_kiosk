using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoBehaviour
{
    public string itemName;
    public float itemPrice;
    public bool isSetMenu;

    public static ItemData BulgogiBurger;
    public static ItemData CrispyChickenBurger;
    public static ItemData CheeseBurger;
    public static ItemData TeriyakiBurger;
    public static ItemData DoubleBurger;

    private void Awake()
    {
        // 객체 생성
        BulgogiBurger = new ItemData("불고기버거", 6000, false);
        CrispyChickenBurger = new ItemData("크리스피 치킨버거", 7000, false);
        CheeseBurger = new ItemData("치즈버거", 5500, false);
        TeriyakiBurger = new ItemData("데리버거", 6500, false);
        DoubleBurger = new ItemData("더블버거", 6500, false);
    }

    public ItemData(string name, float price, bool isSetMenu)
    {
        itemName = name;
        itemPrice = price;
        this.isSetMenu = isSetMenu;
    }

    // 세트 메뉴로 변경하는 메서드
    public Burger GetSetMenu()
    {
        float setPrice = 3.0f;
        return new Burger(itemName + " Set", itemPrice + setPrice);
    }

    // 아이템 객체 생성
    public class Burger
    {
        public string name;
        public float price;

        public Burger(string name, float price)
        {
            this.name = name;
            this.price = price;
        }
    }
}


//객체 접근법 
// ItemData.BulgogiBurger
// ItemData.CrispyChickenBurger
// ItemData.CheeseBurger
// ItemData.TeriyakiBurger
// ItemData.DoubleBurger