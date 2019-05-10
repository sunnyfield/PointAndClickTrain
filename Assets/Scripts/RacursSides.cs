

using UnityEngine;

public class RacursSides : Racurs
{
    protected RacursSides()
    { }


    public static new RacursSides CreateRacurs(GameObject obj)
    {
        RacursSides racurs = new RacursSides { gameObject = obj };
        return racurs;
    }

    protected override void Left()
    {
        if (leftRacurs == null)
            return;

        leftRacurs.ActivateRacurs();
        leftRacurs.SetPrev(prevRacurs);
        gameObject.SetActive(false);
    }

    protected override void Right()
    {
        if (rightRacurs == null)
            return;

        rightRacurs.ActivateRacurs();
        rightRacurs.SetPrev(prevRacurs);
        gameObject.SetActive(false);
    }
}
