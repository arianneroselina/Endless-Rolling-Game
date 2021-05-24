using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _view;

    private void Update()
    {
        this._view.text = "Score : " + Score.GetTime().ToString("F2");
    }
}
