using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CrimeList")]
public class CrimeList : ScriptableObject
{
    public List<Crime> _crimeList;
}

[System.Serializable]
public class Crime
{
    public CrimeType crime;
    public int dangerLevel;
}