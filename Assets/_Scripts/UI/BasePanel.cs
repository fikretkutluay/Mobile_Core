using UnityEngine;
using DG.Tweening;

public abstract class BasePanel : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    
    protected float fadeDuration = 0.5f; 

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
        canvasGroup.blocksRaycasts = true; 
        canvasGroup.alpha = 0;
        canvasGroup.DOFade(1, fadeDuration);
    }

    public virtual void Hide()
    {
        canvasGroup.blocksRaycasts = false; 
        canvasGroup.DOFade(0, fadeDuration).OnComplete(() => gameObject.SetActive(false));
    }
}