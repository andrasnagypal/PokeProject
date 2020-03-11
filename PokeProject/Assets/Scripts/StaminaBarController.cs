using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBarController : MonoBehaviour
{
    public GameObject StaminaPoint,StaminaBarContentPanel;

    List<GameObject> StaminaPoints = new List<GameObject>();

    //private void Awake()
    //{
    //    for (int i = 0; i < 9; i++)
    //    {
    //        AddStaminaPointToUI();
    //    }
    //    RemoveStaminaPointFromUI();
    //    RemoveStaminaPointFromUI();
    //    RemoveStaminaPointFromUI();
    //}

    public void AddStaminaPointToUI()
    {
        GameObject go = Instantiate(StaminaPoint, StaminaBarContentPanel.transform);
        StaminaPoints.Add(go);
    }
    public void RemoveStaminaPointFromUI()
    {
        GameObject go = StaminaPoints[0];
        StaminaPoints.RemoveAt(0);
        Destroy(go);
    }
    public void ResetStaminaBar()
    {
        foreach (var item in StaminaPoints)
        {
            Destroy(item);
        }
        StaminaPoints.Clear();
    }
    public int GetNumberOFStamina()
    {
        return StaminaPoints.Count;
    }
}
