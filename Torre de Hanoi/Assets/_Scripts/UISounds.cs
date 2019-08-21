using UnityEngine;
using UnityEngine.EventSystems;

public class UISounds : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField] private AudioClip UIEnter;
    [SerializeField] private AudioClip UIClick;

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioPlayer.instance.PlaySFX(UIEnter);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AudioPlayer.instance.PlaySFX(UIClick);
    }    
}
