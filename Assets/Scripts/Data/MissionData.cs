using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionData : MonoBehaviour
{
    public class Mission
    {
        public int item_1;
        public int item_2;
        public int item_3;
    }

    public Mission mission_1 = new Mission() { item_1 = 1, item_2 = 10, item_3 = 20 };
}
