//참여
//2017012488_컴퓨터학부_이현준
//2019040255_김민종

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadService : MonoBehaviour
{
    public float fadeDuration = 2;
    public Color fadeColor;
    Renderer rend;

    void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    public void LoadScene(int sceneNum)
    {
        StartCoroutine(FadeRoutine(0, 1, () => { SceneManager.LoadScene(sceneNum); }));
    }

    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    // 실제 Fading을 수행하는 Coroutine
    // 시간 경과에 따른 Fade 지속시간이 지남에 따라 Fade Color의 alpha값을 업데이트 
    IEnumerator FadeRoutine(float alphaIn, float alphaOut, Action fadeAction = null)
    {
        float timer = 0;
        while (timer <= fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);

            rend.material.SetColor("_Color", newColor);

            timer += Time.deltaTime;
            yield return null;
        }

        Color newColor2 = fadeColor;
        newColor2.a = alphaOut;
        rend.material.SetColor("_Color", newColor2);

        if (fadeAction != null)
            fadeAction.Invoke();
    }
}
