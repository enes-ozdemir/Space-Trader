using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "WeaponPrefabs")]
    public class WeaponPrefabs : ScriptableObject
    {
        public List<GameObject> Rifles;
        public List<GameObject> Swords;
        public List<GameObject> Bombs;
        public List<GameObject> DeathBombs;
        public List<GameObject> Pistols;
        public List<GameObject> HeavyArtilery;
        public List<GameObject> Medical;
        public List<GameObject> NiceMedical;
        public List<GameObject> Artifact;
        public List<GameObject> ShipParts;
        public List<GameObject> ExpensiveShipParts;

    }
}