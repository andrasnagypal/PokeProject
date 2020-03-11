using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageRelations :byte
{
    no_damage_to,
    half_damage_to,
    double_damage_to,
    no_damage_from,
    half_damage_from,
    double_damage_from
}
public class PokeModel 
{
    public string PokeName;
    
    public Texture2D[] SpritesOfPoke;
    public string[] TypesOfPoke;
    public string[] AbilitiesOfPoke;
    public int Lvl, Stamina, MaxNumberOfAttacks, CurrentAttackAmount,IndexOfPoke;
    public byte[] DamageRelationsArray;

}
