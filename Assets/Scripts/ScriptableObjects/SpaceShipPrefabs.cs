using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "SpaceShipList")]
    public class SpaceShipPrefabs : ScriptableObject
    {
        public List<GameObject> spaceShipList;
    }
}