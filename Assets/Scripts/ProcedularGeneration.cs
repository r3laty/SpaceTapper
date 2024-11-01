using System.Collections.Generic;
using UnityEngine;

public class ProcedularGeneration : MonoBehaviour
{
    [SerializeField] private List<GameObject> planetPrefabs;
    [SerializeField] private List<Transform> planetSpawnPoints;
    private void Start()
    {
        OnPlanetEnd();
    }
    private void OnPlanetEnd()
    {
        Instantiate(planetPrefabs[Random.Range(0, planetPrefabs.Count)], planetSpawnPoints[Random.Range(0, planetSpawnPoints.Count)].position, Quaternion.identity);
    }
}
