using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonLeft : EventTrigger
{
    public override void OnPointerEnter(PointerEventData data)
    {
        UIController.instance.SetCursorLeft();
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        UIController.instance.SetCursorMain();
    }
}
