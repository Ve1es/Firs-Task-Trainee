using UnityEngine;
using TMPro;
using DG.Tweening;
using System.Collections;

public class DotweenTextAnim : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float appearDuration = 0.5f;
    public float shrinkDuration = 0.5f;

    void OnEnable()
    {
        textMeshPro.transform.localScale = Vector3.zero;

        textMeshPro.transform.DOScale(1.2f, appearDuration)
           .OnComplete(() =>
            {
                textMeshPro.transform.DOScale(0.9f, shrinkDuration)
                    .SetEase(Ease.InBack).OnComplete(() =>
                    {
                        textMeshPro.transform.DOScale(1.1f, appearDuration)
                            .OnComplete(() =>
                            {
                                textMeshPro.transform.DOScale(1f, shrinkDuration)
                                .SetEase(Ease.InBack);

                            });
                    });
            });
    }
}


