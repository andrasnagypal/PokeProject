using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoBarController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI InfoBar;

    public void ChangeInfoBar(string info)
    {
        InfoBar.text = info;
    }
}
