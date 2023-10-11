using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SelectName : MonoBehaviour
{
    public TMP_InputField inputText;
    public TextMeshProUGUI textName;
    public GameObject buttonAccept;
    public Image ligt;
    


    private void Update()
    {
        if(textName.text.Length < 4)
        {
            ligt.color = Color.red;
            buttonAccept.SetActive(false);
        }
        if(textName.text.Length >= 4)
        {
            ligt.color = Color.green;
            buttonAccept.SetActive(true);

        }

    }
    public void accept()
    {
        PlayerPrefs.SetString("nombre1", inputText.text);
    }
}
