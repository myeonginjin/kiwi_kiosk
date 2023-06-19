//참여
//2017012488_컴퓨터학부_이현준
//2019040255_김민종

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionService : MonoBehaviour
{
    public TextMeshProUGUI missionTMPro;
    public TextMeshProUGUI[] resultTMPro = new TextMeshProUGUI[3];
    public TextMeshProUGUI resultCountTMPro;
    public Vector3 popupPosition;
    public Vector3 customerPosition;

    MissionData missionData;

    void Awake()
    {
        missionData = GetComponent<MissionData>();
    }

    void Start()
    {
        InitMission();
        PrintMission();
        StartCoroutine(MovePopup());
    }

    void InitMission()
    {
        ItemData[] itemDataList = FindObjectsOfType<ItemData>(true);
        missionData.missions[0] = itemDataList[Random.Range(0, itemDataList.Length)];

        do
        {
            missionData.missions[1] = itemDataList[Random.Range(0, itemDataList.Length)];

        } while (missionData.missions[0].menuName == missionData.missions[1].menuName);

        do
        {
            missionData.missions[2] = itemDataList[Random.Range(0, itemDataList.Length)];

        } while (missionData.missions[0].menuName == missionData.missions[2].menuName ||
                missionData.missions[1].menuName == missionData.missions[2].menuName);
    }

    void PrintMission()
    {
        missionTMPro.text = 
@$"{missionData.missions[0].menuName}
{missionData.missions[1].menuName}
{missionData.missions[2].menuName}";
    }

    IEnumerator MovePopup()
    {
        yield return new WaitForSeconds(2);

        float moveRate = 0f;
        Vector3 startPosition = transform.position;

        while (moveRate < 1f)
        {
            moveRate += Time.deltaTime * 0.7f;
            transform.position = Vector3.Lerp(
                startPosition, popupPosition, moveRate);

            transform.LookAt(customerPosition);

            yield return new WaitForEndOfFrame();
        }
    }

    public void CheckMission(PayData payData)
    {
        foreach (var slotData in payData.slotList)
        {
            for (int i = 0; i < 3; i++)
            {
                if (!missionData.isSuccess[i] && (missionData.missions[i].menuName == slotData.itemData.menuName))
                    missionData.isSuccess[i] = true;
            }
        }
    }

    public void PrintResult()
    {
        int count = 0;

        for (int i = 0; i < 3; i++)
        {
            if (missionData.isSuccess[i])
            {
                resultTMPro[i].text = $"{missionData.missions[i].menuName} 성공";
                resultTMPro[i].color = Color.green;
                count++;
            }
            else
            {
                resultTMPro[i].text = $"{missionData.missions[i].menuName} 실패";
                resultTMPro[i].color = Color.red;
            }
        }

        resultCountTMPro.text = $"{count}개 정답입니다!";
    }
}
