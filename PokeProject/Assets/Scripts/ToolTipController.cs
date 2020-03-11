using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToolTipController : MonoBehaviour
{
    bool IsActive = false;
    [SerializeField]TextMeshProUGUI ToolTipInfo;
    

    // Update is called once per frame
    void Update()
    {
        if (IsActive)
            MoveToolTip();
    }

    private void MoveToolTip()
    {
        
    }
    public void ChangeTooltipInfo(string info)
    {
        ToolTipInfo.text = info;
    }
    public void SetTooltipState(bool state)
    {
        ToolTipInfo.gameObject.SetActive(state);
    }
}
