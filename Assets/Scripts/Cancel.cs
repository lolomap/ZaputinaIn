using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cancel : MonoBehaviour
{
 
    public void OnCancel()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnDpPanelCancel()
    {
        transform.parent.gameObject.SetActive(false);
        SceneLoader.UpUseButton.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (name == "CancelBtn" && !SceneLoader.DescriptionPanel.activeSelf)
            {
                OnCancel();
                return;
            }
            if (name == "CancelDpBtn")
            {
                OnDpPanelCancel();
            }
        }
    }

}
