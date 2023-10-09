using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Multiplier : MonoBehaviour
{
    public int multiplyAmount;
    public MeshRenderer mCube;
    [SerializeField] TMP_Text mText;
    void Start()
    {
        mText.text = "x" + multiplyAmount.ToString();
    }
}
