using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public UnityEngine.UI.InputField playerNameField;

    public void OnPlayPressed()
    {
        MainManager.playerName = playerNameField.text;
        if(playerNameField.text != "")
            SceneManager.LoadScene("main");
    }
}
