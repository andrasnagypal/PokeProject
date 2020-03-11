using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TypeHoverOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string TypeName,OtherInfo;

    public void OnPointerEnter(PointerEventData eventData)
    {
        FindObjectOfType<ToolTipController>().SetTooltipState(true);
        FindObjectOfType<ToolTipController>().ChangeTooltipInfo(TypeName.ToUpper()+ OtherInfo);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        FindObjectOfType<ToolTipController>().SetTooltipState(false);
    }

   
}
