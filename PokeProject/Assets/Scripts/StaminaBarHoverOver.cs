using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StaminaBarHoverOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        FindObjectOfType<ToolTipController>().SetTooltipState(true);
        FindObjectOfType<ToolTipController>().ChangeTooltipInfo(GetComponent<StaminaBarController>().GetNumberOFStamina().ToString()+" stamina points remaining");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        FindObjectOfType<ToolTipController>().SetTooltipState(false);
    }

    
}
