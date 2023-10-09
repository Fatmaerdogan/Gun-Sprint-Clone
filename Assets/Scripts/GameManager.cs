using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    int goldAmount;
    public int TempGold { 
        get { goldAmount = PlayerPrefs.GetInt("Gold"); return goldAmount; }
        set { goldAmount += value; PlayerPrefs.SetInt("Gold", goldAmount); Events.OnTempGoldChange?.Invoke(); }
    }
    public int Gold
    {
        get { goldAmount = PlayerPrefs.GetInt("Gold"); return goldAmount; }
        set { goldAmount = value; PlayerPrefs.SetInt("Gold", goldAmount); Events.OnGoldChange?.Invoke(); }
    }
    public void MultiplierGoldCalculation(int Multiplier)
    {
        int gold =goldAmount*Multiplier;
        TempGold = gold;
        Events.OnGoldChange?.Invoke();
    }
    public void FinishGoldCalculation()
    {
        Gold = goldAmount;
        Events.OnGoldChange?.Invoke();
    }
    private void Awake()
    {
        if(instance == null) instance = this;
    }
    void Start()
    {
        Time.timeScale = 1;
        Events.OnGameFinish += Finish;
    }
    private void OnDestroy()
    {
        Events.OnGameFinish -= Finish;
    }
    public void Finish()
    {
       
    }
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void LoadScene(string sceneName)
    {
        if (sceneName == "Exit")
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
