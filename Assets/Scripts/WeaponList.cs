using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponList")]
public class WeaponList : ScriptableObject
{
    public List<WeaponValues> weapons;
}