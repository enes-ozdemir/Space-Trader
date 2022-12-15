using System.Collections.Generic;

public struct Customer
{
    public int dangerLevel;
    public bool isWanted;
    public Dictionary<Crime, int> crimeCountDictionary;
}