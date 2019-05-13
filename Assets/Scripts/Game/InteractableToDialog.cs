using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableToDialog : MonoBehaviour
{
    public GameObject dialog;

    private void OnMouseDown()
    {
        if (!UIController.instance.menuIsOpen)
            dialog.SetActive(true);
    }

    private void OnEnable()
    {
        dialog.SetActive(false);
    }

    private void OnDisable()
    {
        dialog.SetActive(false);
    }
}
