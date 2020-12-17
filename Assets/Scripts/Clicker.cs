using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    private static int score_ = 0;
    public static int score
    {
        get { return score_; }
        set
        {
            score_ = value;
            Counter.scoreText = score.ToString();
            checkUpgrades();
        }
    }

    private static int employers_ = 0;
    public static int employers
    {
        get { return employers_; }
        set
        {
            employers_ = value;
            Counter.employersText = employers.ToString();
        }
    }

    public static void checkUpgrades()
    {
        var dict = Upgrade.upgrades;
        if (score >= Constants.START_COST)
            Upgrade.Unlock("start_up");
        else Upgrade.Lock("start_up");

        if (score >= Constants.FST_EMP_COST && dict["start_up"])
            Upgrade.Unlock("fst_emp_up");
        else Upgrade.Lock("fst_emp_up");
        if (score >= Constants.GARAGE_COST && dict["start_up"])
            Upgrade.Unlock("garage_up");
        else Upgrade.Lock("garage_up");

        if (score >= Constants.MORE_EMP_COST && dict["fst_emp_up"])
            Upgrade.Unlock("more_emp_up");
        else Upgrade.Lock("more_emp_up");
        if (score >= Constants.MOBIL_COST && dict["more_emp_up"])
            Upgrade.Unlock("mobil_up");
        else Upgrade.Lock("mobil_up");
    }

    public void OnClick()
    {
        score++;
    }
}
