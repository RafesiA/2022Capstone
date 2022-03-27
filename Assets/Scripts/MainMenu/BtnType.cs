using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnType : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BTNType currentType;
    public Transform buttonScale;
    Vector3 defaultScale;
    public CanvasGroup mainGroup;
    public CanvasGroup optionGroup;
    public CanvasGroup songGroup;
    public CanvasGroup playGroup;

    private void Start()
    {
        defaultScale = buttonScale.localScale;
    }
    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTNType.New:
                Debug.Log("������");
                CanvasGroupOn(songGroup);
                CanvasGroupoff(mainGroup);
                break;
            case BTNType.Option:
                CanvasGroupOn(optionGroup);
                CanvasGroupoff(mainGroup);
                Debug.Log("�ɼ�");
                break;
            case BTNType.Back:
                CanvasGroupOn(mainGroup);
                CanvasGroupoff(optionGroup);
                Debug.Log("���ư���");
                break;
            case BTNType.Quit:
                Application.Quit();
                Debug.Log("������");
                break;
            case BTNType.Mainback:
                CanvasGroupOn(mainGroup);
                CanvasGroupoff(songGroup);
                Debug.Log("����ȭ�����ΰ���");
                break;
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
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }
}
