using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "CustomerPrefab")]
    public class CustomerPrefabs : ScriptableObject
    {
        public List<GameObject> customer;
    }
}