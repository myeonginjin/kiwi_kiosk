//참여
//2017012488_컴퓨터학부_이현준
//2019040255_김민종

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionInterface : MonoBehaviour
{
    MissionService missionService;

    void Awake()
    {
        missionService = GetComponent<MissionService>();
    }

    public void CheckMission(PayData payData)
    {
        missionService.CheckMission(payData);
    }

    public void PrintResult()
    {
        missionService.PrintResult();
    }
}
