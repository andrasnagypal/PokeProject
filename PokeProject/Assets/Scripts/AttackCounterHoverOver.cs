using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class AttackCounterHoverOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        FindObjectOfType<ToolTipController>().SetTooltipState(true);
        FindObjectOfType<ToolTipController>().ChangeTooltipInfo(GetComponent<TextMeshProUGUI>().text + " attacks remaining before stamina is needed");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        FindObjectOfType<ToolTipController>().SetTooltipState(false);
    }

    
}
