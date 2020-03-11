using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TypeHoverOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string TypeName;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(TypeName);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("End");
    }

   
}
