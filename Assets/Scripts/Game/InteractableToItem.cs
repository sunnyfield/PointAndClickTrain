using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableToItem: MonoBehaviour
{

    public Sprite itemSprite;

    public GameObject text;

    public GameObject objToDeactivate;

    private void OnMouseDown()
    {
        UIController.instance.ShowItem(itemSprite, text, objToDeactivate);
        UIController.instance.PlaceToInventory(itemSprite);
        gameObject.SetActive(false);
    }
}
