using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class ItemTake : EventTrigger
{
    public override void OnPointerEnter(PointerEventData data)
    {
        UIController.instance.SetCursorTake();
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        UIController.instance.SetCursorMain();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        UIController.instance.Back();
    }
}
