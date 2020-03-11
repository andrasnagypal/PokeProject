using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToolTipController : MonoBehaviour
{
    bool IsActive = false;
    [SerializeField]TextMeshProUGUI ToolTipInfo;
    [SerializeField] GameObject ToolTip;
    static IEnumerator TooltipNumerator = null;
    

    private void MoveToolTip()
    {
        ToolTip.transform.position = Input.mousePosition;
    }
    public void ChangeTooltipInfo(string info)
    {
        ToolTipInfo.text = info;
    }
    public void SetTooltipState(bool state)
    {
        ToolTip.gameObject.SetActive(state);
        IsActive = state;
        if (TooltipNumerator == null)
        {
            TooltipNumerator = TooltipPosition();
            StartCoroutine(TooltipNumerator);
        }
        
        
       
        
    }

    IEnumerator TooltipPosition()
    {
        while(IsActive)
        {
            MoveToolTip();
            yield return new WaitForSeconds(.3f);
        }
        yield return null;
        TooltipNumerator = null;
    }
}
