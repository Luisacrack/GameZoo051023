using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public bool isSplash;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GoToMenu());
    }
    IEnumerator GoToMenu()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Menu");
    }
    public void GoToAnyScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    
}
