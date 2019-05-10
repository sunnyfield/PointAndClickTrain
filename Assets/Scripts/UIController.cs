using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Button gameMenuButton;
    public Animator gameMenuAnimator;

    public Button exitButton;

    private bool isOpen = false;

    void Start()
    {
        gameMenuButton.onClick.AddListener(() => OpenMenu());
        gameMenuAnimator.SetBool("isOpen", isOpen);

        exitButton.onClick.AddListener(() => Application.Quit());
    }

    private void OpenMenu()
    {
        isOpen = !isOpen;
        gameMenuAnimator.SetBool("isOpen", isOpen);
    }
}
