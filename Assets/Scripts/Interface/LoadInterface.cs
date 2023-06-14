//참여
//2017012488_컴퓨터학부_이현준
//2019040255_김민종

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadInterface : MonoBehaviour
{
    public bool fadeOnStart;
    LoadService loadService;

    void Awake()
    {
        loadService = GetComponent<LoadService>();
    }

    // 첫 번째 프레임 업데이트를 하기 전 Start를 호출
    // Scene 시작 시 FadeIn 해 scene 표시
    void Start()
    {
        if (fadeOnStart)
            FadeIn();
    }

    public void LoadScene(int sceneNum)
    {
        loadService.LoadScene(sceneNum);
    }

    // 불투명에서 투명으로 FadeIn 전환
    public void FadeIn()
    {
        loadService.Fade(1, 0);
    }

    // 투명에서 불투명으로 FadeOut 전환
    public void FadeOut()
    {
        loadService.Fade(0, 1);
    }
}
