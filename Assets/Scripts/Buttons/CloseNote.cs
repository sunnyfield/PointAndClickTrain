using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseNote : EventTrigger
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        UIController.instance.CloseNote();
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = new Vector2(1.1f, 1.1f);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = Vector2.one;
    }
}
