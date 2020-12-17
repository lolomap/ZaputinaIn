using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    static bool isGameLoaded = false;
    //static bool isUpMenuLoaded = false;
    public static GameObject DescriptionPanel;
    public static GameObject UpUseButton;
    public static Text UpUseBtnText;
    public static Text UpNameText;
    public static Text UpDescriptionText;
    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Main")
            if (!isGameLoaded)
            {
                Upgrade.Init();
                SaveSerial.LoadGame();
            
                isGameLoaded = true;
            }
        if (SceneManager.GetActiveScene().name == "UpgradesMenu")
        {
            //if (!isUpMenuLoaded)
            {
                DescriptionPanel = GameObject.Find("Canvas/DescriptionPanel");
                UpUseButton = GameObject.Find("Canvas/DescriptionPanel/UpUseBtn");
                UpUseBtnText = GameObject.Find("Canvas/DescriptionPanel/UpUseBtn/UpUseBtnTEXT").GetComponent<Text>();
                UpNameText = GameObject.Find("Canvas/DescriptionPanel/UpNameText").GetComponent<Text>();
                UpDescriptionText = GameObject.Find("Canvas/DescriptionPanel/UpDescriptionText").GetComponent<Text>();
                //isUpMenuLoaded = true;
            }
            DescriptionPanel.SetActive(false);
        }
        
    }

    private void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            SaveSerial.SaveGame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
