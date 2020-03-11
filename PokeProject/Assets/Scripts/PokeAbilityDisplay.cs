using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PokeAbilityDisplay : MonoBehaviour
{
    [SerializeField] GameObject AbilityToAttach;
    List<GameObject> ListOfAbilities = new List<GameObject>();
    string[] NameOfAbilities;
   public void AddAbilityToPanel(string nameOfAbility)
    {
        GameObject temp = Instantiate(AbilityToAttach, gameObject.transform);
        temp.transform.Find("AbilityNameText").GetComponent<TextMeshProUGUI>().text =  nameOfAbility.ToUpper();
        ListOfAbilities.Add(temp);
    }

    public void SetAbilityImages(string[] spritenames)
    {
        for (int i = 0; i < ListOfAbilities.Count; i++)
        {
            int rnd = Random.Range(0, spritenames.Length );
            ListOfAbilities[i].transform.Find("AbilityImage").GetComponent<Image>().sprite = FindObjectOfType<TypeCounter>().GetSpriteForType( spritenames[rnd]);
            ListOfAbilities[i].transform.Find("AbilityImage").GetComponent<TypeHoverOver>().TypeName = spritenames[rnd];
        }
    }
    public void SetAbilitiesName(string[] names)
    {
        ResetUI();
        NameOfAbilities = names;
        for (int i = 0; i < NameOfAbilities.Length; i++)
        {
            AddAbilityToPanel(NameOfAbilities[i]);
        }
        if(NameOfAbilities.Length==0)
        {
            AddAbilityToPanel("Growl");
        }
    }
    public void ResetUI()
    {
        foreach (var item in ListOfAbilities)
        {
            Destroy(item);
        }
        ListOfAbilities.Clear();
        ListOfAbilities = new List<GameObject>();
    }
}
