using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_GameMenu : MonoBehaviour
{
    private Button buttonComponent;
    private Animator animatorComponent;

    private bool isOpen = false;

    void Start()
    {
        animatorComponent = gameObject.GetComponentInParent<Animator>();
        buttonComponent = gameObject.GetComponent<Button>();
        buttonComponent.onClick.AddListener(OpenMenu);
        animatorComponent.SetBool("isOpen", isOpen);
    }

    private void OpenMenu()
    {
        isOpen = !isOpen;
        animatorComponent.SetBool("isOpen", isOpen);

    }
}
