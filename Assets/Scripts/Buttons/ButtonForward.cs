using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonForward : EventTrigger
{

    public override void OnPointerEnter(PointerEventData data)
    {
        UIController.instance.SetCursorForward();
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        UIController.instance.SetCursorMain();
    }
}
