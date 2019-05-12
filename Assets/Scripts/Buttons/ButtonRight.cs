using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonRight : EventTrigger
{
    public override void OnPointerEnter(PointerEventData data)
    {
        UIController.instance.SetCursorRight();
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        UIController.instance.SetCursorMain();
    }
}
