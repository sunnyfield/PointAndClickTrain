using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : EventTrigger
{
    public override void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = new Vector2(1.2f, 1.2f);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = Vector2.one;
    }
}
