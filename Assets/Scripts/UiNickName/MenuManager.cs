using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TMP_InputField nickname;
    public void Enter()
    {
        if(nickname.text != "" && nickname.text.Length >3)
        {
            PlayerPrefs.SetString("nickname", nickname.text);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Game");
        }
        else
        {
            Debug.Log("Comprobar el nickname");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
