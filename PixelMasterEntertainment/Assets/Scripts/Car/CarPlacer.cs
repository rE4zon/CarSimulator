using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarPlacer : MonoBehaviour
{
    [SerializeField] private GameObject[] carModels;

    private void Awake()
    {
        CarPlace(SaveManager.instance.currentCar);
    }

    private void CarPlace(int index)
    {
        Instantiate(carModels[index], transform.position, Quaternion.identity, transform);
    }
}
