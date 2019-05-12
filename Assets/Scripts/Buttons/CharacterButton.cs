using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterButton : EventTrigger
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        UIController.instance.ShowCharacterSheet(gameObject.GetComponent<CharButtonRef>().characterSheet);
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
