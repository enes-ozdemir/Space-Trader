using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShipControler : MonoBehaviour
{
    public Dictionary<Transform, bool> parkingSpaceDictionary;
    public SpaceShipPrefabs spaceShips;
    public List<GameObject> activeShips;
    public List<Transform> spawnTransformList;
    public List<Transform> parkingSpaceList;

    public int index = 0;

    private void Start()
    {
        parkingSpaceDictionary = new Dictionary<Transform, bool>();
        foreach (var parkingSpace in parkingSpaceList)
        {
            parkingSpaceDictionary.Add(parkingSpace,false) ;
        }
    }

    private void Update()
    {
       CheckParkingSpace();
       SendShipAway();
    }

    private async void CheckParkingSpace()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(5));

        if (index<3)
        {
            index++;
            Debug.Log("Ship called");
            var randomShip = GetRandomSpaceShip();
            var randomTransform = Random.Range(0, spawnTransformList.Count - 1);
            activeShips.Add(randomShip);
            var currentShip=Instantiate(randomShip.gameObject, spawnTransformList[randomTransform]);

            var randomSpace = Random.Range(0,parkingSpaceDictionary.Count - 1);
            if (!parkingSpaceDictionary.ElementAt(randomSpace).Value)
            {
                var space = parkingSpaceDictionary.ElementAt(randomSpace).Key;
                parkingSpaceDictionary[space] = true;
                currentShip.transform.DOMove(space.position,10f);
                currentShip.transform.DOLookAt(space.position, 2f);
                await UniTask.Delay(TimeSpan.FromSeconds(2));
                currentShip.transform.DORotate(new Vector3(0, 0, 0), 2f);
            }
        }
    }

    private async void SendShipAway()
    {
        if(activeShips.Count<0) return;
        await UniTask.Delay(TimeSpan.FromSeconds(10));
        var randomShip = Random.Range(0, activeShips.Count-1);
        var randomTransform = Random.Range(0, spawnTransformList.Count - 1);
        if(activeShips[randomShip]==null) return;
        activeShips[randomShip].transform.DOMove(spawnTransformList[randomTransform].position,10f);
 
    }

    private GameObject GetRandomSpaceShip()
    {
        var randomNumber = Random.Range(0, spaceShips.spaceShipList.Count);
        return spaceShips.spaceShipList[randomNumber];
    }
}