using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text goldText;
    [SerializeField] TMP_Text tempGoldText;

    [SerializeField] GameObject finishPanel;

    void Start()
    {
        Events.OnGoldChange += GoldTextWrite;
        Events.OnTempGoldChange += TempGoldTextWrite;
        Events.OnGameFinish += Finish;
    }
    private void OnDestroy()
    {
        Events.OnGoldChange -= GoldTextWrite;
        Events.OnTempGoldChange -= TempGoldTextWrite;
        Events.OnGameFinish -= Finish;
    }
    void GoldTextWrite()
    {
        goldText.text = GameManager.instance.Gold.ToString();
    }
    void TempGoldTextWrite()
    {
        tempGoldText.text = GameManager.instance.TempGold.ToString();
    }
    void Finish()
    {
        finishPanel.SetActive(true);
    }
}
