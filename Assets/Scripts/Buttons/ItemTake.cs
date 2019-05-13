using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class ItemTake : EventTrigger
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (!UIController.instance.menuIsOpen)
            UIController.instance.Back();
    }
}
