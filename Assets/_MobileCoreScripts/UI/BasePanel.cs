using UnityEngine;
using DG.Tweening;

public abstract class BasePanel : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    
    protected float fadeDuration = 0.5f; 

    protected virtual void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
        canvasGroup.blocksRaycasts = true; 
        canvasGroup.alpha = 0f;
        canvasGroup.DOFade(1, fadeDuration);
    }

    public virtual void Hide()
    {
        canvasGroup.blocksRaycasts = false; 
        canvasGroup.DOFade(0, fadeDuration).OnComplete(() => gameObject.SetActive(false));
    }
}