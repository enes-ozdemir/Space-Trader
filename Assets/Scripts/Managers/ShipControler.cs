using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShipControler : MonoBehaviour
{
    private Dictionary<Transform, bool> occupiedParkingSpaces = new();
    public SpaceShipPrefabs spaceShips;
    public List<Transform> spawnTransformList;
    public List<Transform> parkingSpaceList;

    private void Start()
    {
        foreach (var parkingSpace in parkingSpaceList)
        {
            occupiedParkingSpaces[parkingSpace] = false;
        }

        StartCoroutine(InstantiateSpaceships());
    }

    private IEnumerator InstantiateSpaceships()
    {
        while (true)
        {
            int parkingSpaceIndex = WaitForAvailableParkingSpace();
            if (parkingSpaceIndex == -1)
            {
                yield return null;
                continue;
            }

            var randomTransform = Random.Range(0, spawnTransformList.Count - 1);
            var currentShip = Instantiate(GetRandomSpaceShip().gameObject, spawnTransformList[randomTransform]);

            var parkingSpace = parkingSpaceList[parkingSpaceIndex];

            occupiedParkingSpaces[parkingSpace] = true;
            currentShip.transform.DOMove(parkingSpace.position, 10f);
            currentShip.transform.DOLookAt(parkingSpace.position, 2f);
            currentShip.transform.DORotate(new Vector3(0, 0, 0), 2f);

            occupiedParkingSpaces[parkingSpace] = true;

            yield return new WaitForSeconds(25f);
            SendShipAway(currentShip);
            Destroy(currentShip, 10f);
            occupiedParkingSpaces[parkingSpace] = false;
        }
    }

    private int WaitForAvailableParkingSpace()
    {
        for (int i = 0; i < parkingSpaceList.Count; i++)
        {
            if (IsParkingSpaceAvailable(parkingSpaceList[i]))
            {
                return i;
            }
        }

        return -1;
    }

    private bool IsParkingSpaceAvailable(Transform parkingSpace)
    {
        return !occupiedParkingSpaces[parkingSpace];
    }


    private void SendShipAway(GameObject currentShip)
    {
        var randomTransform = Random.Range(0, spawnTransformList.Count - 1);
        currentShip.transform.DOMove(spawnTransformList[randomTransform].position, 10f);
        currentShip.transform.DOLookAt(spawnTransformList[randomTransform].position, 2f);
    }

    private GameObject GetRandomSpaceShip()
    {
        var randomNumber = Random.Range(0, spaceShips.spaceShipList.Count);
        return spaceShips.spaceShipList[randomNumber];
    }
}