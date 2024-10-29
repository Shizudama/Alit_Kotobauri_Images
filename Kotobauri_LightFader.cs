using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFader : MonoBehaviour
{
    public Light targetLight;           // フェード対象のライト
    public float fadeDuration = 2f;     // フェードにかける時間
    public float maxIntensity = 1f;     // ライトの最大強度

    private float initialIntensity;     // ライトの初期強度
    private bool isFadingIn = false;
    private bool isFadingOut = false;
    private float fadeTimer = 0f;

    void Start()
    {
        // 初期強度を保存
        initialIntensity = targetLight.intensity;
    }

    void Update()
    {
        // フェードイン処理
        if (isFadingIn)
        {
            fadeTimer += Time.deltaTime;
            targetLight.intensity = Mathf.Lerp(0, maxIntensity, fadeTimer / fadeDuration);

            if (fadeTimer >= fadeDuration)
            {
                targetLight.intensity = maxIntensity;
                isFadingIn = false;
                fadeTimer = 0f;
            }
        }
        // フェードアウト処理
        else if (isFadingOut)
        {
            fadeTimer += Time.deltaTime;
            targetLight.intensity = Mathf.Lerp(maxIntensity, 0, fadeTimer / fadeDuration);

            if (fadeTimer >= fadeDuration)
            {
                targetLight.intensity = 0;
                isFadingOut = false;
                fadeTimer = 0f;
            }
        }
    }

    public void StartFadeIn()
    {
        isFadingIn = true;
        isFadingOut = false;
        fadeTimer = 0f;
    }

    public void StartFadeOut()
    {
        isFadingOut = true;
        isFadingIn = false;
        fadeTimer = 0f;
    }
}

