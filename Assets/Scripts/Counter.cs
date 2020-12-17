using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    private static Text textsc, textem;
    private static string scoreText_ = "0";
    public static string scoreText
    {
        get { return scoreText_; }
        set
        {
            scoreText_ = value;
            if (textsc != null)
                textsc.text = scoreText;
        }
    }

    private static string employersText_ = "0";
    public static string employersText
    {
        get { return employersText_; }
        set
        {
            employersText_ = value;
            if (textem != null)
                textem.text = employersText;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (name == "cTxTEXT")
        {
            textsc = GetComponent<Text>();
            textsc.text = scoreText;
        }
        else if (name == "eTxTEXT")
        {
            textem = GetComponent<Text>();
            textem.text = employersText;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
