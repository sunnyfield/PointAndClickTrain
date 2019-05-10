using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IRacurs
{
    void OpenRacurs();
    void ActivateRacurs();
    void DeactivateRacurs();
    void SetForw(IRacurs forw);
    void SetPrev(IRacurs prev);
    void SetRight(IRacurs right);
    void SetLeft(IRacurs left);
    void SetButtons();
}

public class Racurs : IRacurs
{
    protected GameObject gameObject;
    protected IRacurs forwardRacurs = null;
    protected IRacurs prevRacurs = null;
    protected IRacurs leftRacurs = null;
    protected IRacurs rightRacurs = null;

    protected Racurs()
    { }

    public static Racurs CreateRacurs(GameObject obj)
    {
        Racurs racurs = new Racurs { gameObject = obj };
        return racurs;
    }

    protected void Forward()
    {
        if (forwardRacurs == null)
            return;

        forwardRacurs.ActivateRacurs();
        forwardRacurs.SetPrev(this);
        gameObject.SetActive(false);
    }

    protected virtual void Left()
    {
        if (leftRacurs == null)
            return;

        leftRacurs.ActivateRacurs();
        leftRacurs.SetPrev(this);
        gameObject.SetActive(false);
    }

    protected virtual void Right()
    {
        if (rightRacurs == null)
            return;

        rightRacurs.ActivateRacurs();
        rightRacurs.SetPrev(this);
        gameObject.SetActive(false);
    }

    protected void Backward()
    {
        if (prevRacurs == null)
            return;

        prevRacurs.ActivateRacurs();
        gameObject.SetActive(false);
    }

    public void OpenRacurs()
    {  
        prevRacurs.DeactivateRacurs();
        ActivateRacurs();
    }

    public void ActivateRacurs()
    {
        gameObject.SetActive(true);
        SetButtons();
    }

    public void DeactivateRacurs()
    {
        gameObject.SetActive(false);
        ClearButtons();
    }

    public void SetForw(IRacurs forw)
    {
        forwardRacurs = forw;
    }

    public void SetPrev(IRacurs prev)
    {
        prevRacurs = prev;
    }

    public void SetRight(IRacurs right)
    {
        rightRacurs = right;
    }

    public void SetLeft(IRacurs left)
    {
        leftRacurs = left;
    }

    public void SetButtons()
    {
        if (forwardRacurs == null)
            GameController.instance.forward.gameObject.SetActive(false);
        else
        {
            GameController.instance.forward.gameObject.SetActive(true);
            GameController.instance.forward.onClick.RemoveAllListeners();
            GameController.instance.forward.onClick.AddListener(Forward);
        }

        if (prevRacurs == null)
            GameController.instance.backward.gameObject.SetActive(false);
        else
        {
            GameController.instance.backward.gameObject.SetActive(true);
            GameController.instance.backward.onClick.RemoveAllListeners();
            GameController.instance.backward.onClick.AddListener(Backward);
        }

        if (rightRacurs == null)
            GameController.instance.right.gameObject.SetActive(false);
        else
        {
            GameController.instance.right.gameObject.SetActive(true);
            GameController.instance.right.onClick.RemoveAllListeners();
            GameController.instance.right.onClick.AddListener(Right);
        }

        if (leftRacurs == null)
            GameController.instance.left.gameObject.SetActive(false);
        else
        {
            GameController.instance.left.gameObject.SetActive(true);
            GameController.instance.left.onClick.RemoveAllListeners();
            GameController.instance.left.onClick.AddListener(Left);
        }
    }

    protected void ClearButtons()
    {
        GameController.instance.forward.onClick.RemoveAllListeners();
        GameController.instance.backward.onClick.RemoveAllListeners();
        GameController.instance.right.onClick.RemoveAllListeners();
        GameController.instance.left.onClick.RemoveAllListeners();
    }  
}
