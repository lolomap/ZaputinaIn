using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeClicker : MonoBehaviour
{
    public static int coinsPerSecond = 0;

    void Start()
    {
        StartCoroutine("DoClick");
    }

    IEnumerator DoClick()
    {
        for(; ; )
        {
            yield return new WaitForSeconds(1f);
            Click();
        }
    }

    void Click()
    {
        Clicker.score += coinsPerSecond;
    }

}
