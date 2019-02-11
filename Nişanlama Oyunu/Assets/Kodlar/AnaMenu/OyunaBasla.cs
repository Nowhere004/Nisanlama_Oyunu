using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OyunaBasla : MonoBehaviour {

    public void HazirlikScene()
    {
        SceneManager.LoadScene("Hazırlık");
    }
    public void LevellerScene()
    {
        SceneManager.LoadScene("1");
    }
    public void AnaMenu()
    {
        SceneManager.LoadScene("AnaMenu");
    }
    public void CikisYap()
    {
        Application.Quit();


    }
}
