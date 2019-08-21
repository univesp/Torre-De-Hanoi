using UnityEngine;
using UnityEngine.EventSystems;

public class PageTurner : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject[] pages;
    private int pageIndex;

    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject backButton;

    private void OnEnable()
    {
        pages[pageIndex].SetActive(false);
        pageIndex = 0;
        pages[pageIndex].SetActive(true);
        nextButton.SetActive(true);
        backButton.SetActive(false);
    }

    public void TurnPageForward()
    {
        if(pageIndex < pages.Length - 1)
        {
            if(!backButton.activeSelf)
            {
                backButton.SetActive(true);
            }

            pages[pageIndex].SetActive(false);
            pageIndex++;
            pages[pageIndex].SetActive(true);
            if(pageIndex == pages.Length - 1)
            {
                nextButton.SetActive(false);
            }
        }
    }

    public void TurnPageBackward()
    {        
        if(!nextButton.activeSelf)
        {
            nextButton.SetActive(true);
        }
        pages[pageIndex].SetActive(false);
        pageIndex--;
        pages[pageIndex].SetActive(true);
        if(pageIndex == 0)
        {
            backButton.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        TurnPageForward();
    }
}
