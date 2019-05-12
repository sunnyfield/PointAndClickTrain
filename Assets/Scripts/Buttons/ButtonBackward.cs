using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonBackward : EventTrigger
{
    public override void OnPointerEnter(PointerEventData data)
    {
        UIController.instance.SetCursorBackward();
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        UIController.instance.SetCursorMain();
    }
}
