using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject[] preyPrefabs;
    public GameObject[] predatorPrefabs;

    public void SpawnPrey()
    {
        int index = Random.Range(0, preyPrefabs.Length);
        Instantiate(preyPrefabs[index], new Vector3(Random.Range(-16, 16), 0, Random.Range( - 16, 16)), preyPrefabs[index].transform.rotation);
    }

    public void SpawnPredator()
    {
        int index = Random.Range(0, predatorPrefabs.Length);
        Instantiate(predatorPrefabs[index], new Vector3(Random.Range(-16, 16), 0, Random.Range(-16, 16)), predatorPrefabs[index].transform.rotation);
    }
}
