using UnityEngine;

namespace DefaultNamespace
{
    public struct Weapon
    {
        public GameObject gameObject;
        public string name;
        public int dangerLevel;
        public string desc;
        public int money;
        public WeaponType weaponType;
    }


    public enum WeaponType
    {
        Rifles=100,
        Swords=80,
        Bombs=300,
        DeathBombs=10000,
        Pistols=50,
        HeavyArtilery = 1000,
        Medical=25,
        NiceMedical=400,
        Artifact=500,
        ShipParts=2000,
        ExpensiveShipParts=5000,
    }
}