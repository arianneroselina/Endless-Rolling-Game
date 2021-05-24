using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _view;

    public void SetLive(int hp)
    {
        this._view.text = "Health : " + hp.ToString();
    }
}
