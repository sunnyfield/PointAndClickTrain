using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Button gameMenuButton;
    public Animator gameMenuAnimator;

    public Button exitButton;

    public Button backFromCloseUpButton;

    private bool isOpen = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

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
