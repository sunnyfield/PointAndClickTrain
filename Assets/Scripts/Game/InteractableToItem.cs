using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableToItem: MonoBehaviour
{
    [SerializeField]
    private Sprite itemSprite;
    [SerializeField]
    private Sprite text;
    [SerializeField]
    private GameObject objToDeactivate;

    private void OnMouseDown()
    {
        UIController.instance.ShowItem(itemSprite, text, objToDeactivate);
        gameObject.SetActive(false);
    }
}
