using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SongSelect : MonoBehaviour
{
    //public Transform buttonScale;
    //Vector3 defaultScale;
    public BTNType currentType;
    public CanvasGroup songGroup;
    public CanvasGroup playGroup;
    public void OnBtnClick()
    {
        switch (currentType)
        {
            
            case BTNType.Songback:
                CanvasGroupOn(songGroup);
                CanvasGroupoff(playGroup);
                Debug.Log("���â");
                break;
            case BTNType.Select:
                CanvasGroupOn(playGroup);
                CanvasGroupoff(songGroup);
                Debug.Log("���");
                break;

        }

    }
    public void CanvasGroupOn(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }
    public void CanvasGroupoff(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }
    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    buttonScale.localScale = defaultScale * 1.2f;
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    buttonScale.localScale = defaultScale;
    //}
}
