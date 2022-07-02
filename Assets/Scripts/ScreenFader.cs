using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MaskableGraphic))]
public class ScreenFader : MonoBehaviour
{
    public float solidAlpha = 1f;
    public float clearAlpha = 0f;
    public float delay = 0f;
    public float timeToFade = 2f;

    private MaskableGraphic m_graphic;

    // Start is called before the first frame update
    void Start()
    {
        m_graphic = GetComponent<MaskableGraphic>();
    }

    private IEnumerator FadeRoutine(float alpha)
    {
        yield return new WaitForSeconds(delay);
        m_graphic.CrossFadeAlpha(alpha, timeToFade, true);
    }

    public void FadeOn()
    {
        StartCoroutine(FadeRoutine(solidAlpha));
    }

    public void FadeOff()
    {
        StartCoroutine(FadeRoutine(clearAlpha));
    }

}
