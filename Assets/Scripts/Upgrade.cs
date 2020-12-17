using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public static Dictionary<string, bool> upgrades = new Dictionary<string, bool>();
    public static Dictionary<string, bool> upButtons = new Dictionary<string, bool>();

    private Button thisBtn;


    public static void Unlock(string key)
    {
        upButtons[key] = true;
    }
    public static void Lock(string key)
    {
        upButtons[key] = false;
    }

    public void OnClick()
    {
        if (!upgrades[name])
        {
            upgrades[name] = true;
            UpUse();
            thisBtn.image.sprite = thisBtn.spriteState.pressedSprite;
        }
    }

    public void ShowPanel()
    {
        SceneLoader.DescriptionPanel.SetActive(true);
        SceneLoader.UpUseButton.GetComponent<Button>().onClick.AddListener(OnClick);
        if(upgrades[name])
        {
            SceneLoader.UpUseButton.SetActive(false);
        }
        else
        {
            SceneLoader.UpUseButton.SetActive(true);
        }
        if (name == "start_up")
        {
            SceneLoader.UpNameText.text = "Основать офис";
            SceneLoader.UpDescriptionText.text = "";
            SceneLoader.UpUseBtnText.text = Constants.UPGRADE_BUY_BUTTON_TEXT
                + "(" + Constants.START_COST.ToString() + "коин)";
        }
        else if (name == "fst_emp_up")
        {
            SceneLoader.UpNameText.text = "Первый сотрудник";
            SceneLoader.UpDescriptionText.text = "Автоматические +1коин/с";
            SceneLoader.UpUseBtnText.text = Constants.UPGRADE_BUY_BUTTON_TEXT
                + "(" + Constants.FST_EMP_COST.ToString() + "коин)";
        }
        else if(name == "more_emp_up")
        {
            SceneLoader.UpNameText.text = "Привлечь волонтеров";
            SceneLoader.UpDescriptionText.text = "Автоматические +8коин/с";
            SceneLoader.UpUseBtnText.text = Constants.UPGRADE_BUY_BUTTON_TEXT
                + "(" + Constants.MORE_EMP_COST.ToString() + "коин)";
        }
        else if(name == "mobil_up")
        {
            SceneLoader.UpNameText.text = "Мобилизировать Штабы";
            SceneLoader.UpDescriptionText.text = "Автоматические +20коин/с";
            SceneLoader.UpUseBtnText.text = Constants.UPGRADE_BUY_BUTTON_TEXT
                + "(" + Constants.MOBIL_COST.ToString() + "коин)";
        }
        else if (name == "garage_up")
        {
            SceneLoader.UpNameText.text = "Арендовать гараж";
            SceneLoader.UpDescriptionText.text = "";
            SceneLoader.UpUseBtnText.text = Constants.UPGRADE_BUY_BUTTON_TEXT
                + "(" + Constants.GARAGE_COST.ToString() + "коин)";
        }
    }

    void UpUse()
    {
        if (name == "start_up")
            Clicker.score -= Constants.START_COST;
        else if (name == "fst_emp_up")
        {
            TimeClicker.coinsPerSecond++;
            Clicker.employers++;
            Clicker.score -= Constants.FST_EMP_COST;
        }
        else if (name == "more_emp_up")
        {
            TimeClicker.coinsPerSecond += 8;
            Clicker.employers += 8;
            Clicker.score -= Constants.MORE_EMP_COST;
        }
        else if (name == "mobil_up")
        {
            TimeClicker.coinsPerSecond += 20;
            Clicker.employers += 20;
            Clicker.score -= Constants.MOBIL_COST;
        }
        else if (name == "garage_up")
        {
            Clicker.score -= Constants.GARAGE_COST;
        }
        Clicker.checkUpgrades();
    }

    public static void Init()
    {
        if (!upgrades.ContainsKey("start_up"))
            upgrades.Add("start_up", false);
        if (!upButtons.ContainsKey("start_up"))
            upButtons.Add("start_up", false);

        if (!upgrades.ContainsKey("fst_emp_up"))
            upgrades.Add("fst_emp_up", false);
        if (!upButtons.ContainsKey("fst_emp_up"))
            upButtons.Add("fst_emp_up", false);

        if (!upgrades.ContainsKey("more_emp_up"))
            upgrades.Add("more_emp_up", false);
        if (!upButtons.ContainsKey("more_emp_up"))
            upButtons.Add("more_emp_up", false);

        if (!upgrades.ContainsKey("mobil_up"))
            upgrades.Add("mobil_up", false);
        if (!upButtons.ContainsKey("mobil_up"))
            upButtons.Add("mobil_up", false);
    }

    // Start is called before the first frame update
    void Awake()
    {
        thisBtn = GetComponent<Button>();
        if (!ConnectUps.ButtonsPosition.ContainsKey(name))
        {
            ConnectUps.ButtonsPosition.Add(name, (transform as RectTransform).localPosition);
        }
        //Debug.Log((transform as RectTransform).sizeDelta.x);
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (!upButtons.ContainsKey(name))
            {
                upButtons.Add(name, false);
            }
            if (!upgrades.ContainsKey(name))
            {
                upgrades.Add(name, false);
            }
            if (upButtons[name])
                thisBtn.interactable = true;
            else thisBtn.interactable = false;
            if (upgrades[name])
                thisBtn.image.sprite = thisBtn.spriteState.pressedSprite;
        }
        catch(KeyNotFoundException e)
        {
            Debug.Log("Update KeyNotFound\n"+e.Message);
            foreach(var key in upgrades.Keys)
            {
                Debug.Log("Key:" + key.ToString());
            }
            Debug.Log(name);
        }
    }
}
