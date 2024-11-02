using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcedularGeneration : MonoBehaviour
{
    [SerializeField] private float planetPositionY = -2.41f;
    [SerializeField] private GameObject firstPlanet;
    [SerializeField] private List<GameObject> planetPrefabs;
    [SerializeField] private List<Transform> planetSpawnPoints;
    private GameObject _currentPlanet;
    private GameObject _oldPlanets;
    private void Awake()
    {
        _currentPlanet = firstPlanet;
    }
    private void Update()
    {
        OnPlanetEnd();
    }
    private void OnPlanetEnd()
    {
        if (MessageAboutNextPlanet.Instance.IsNextPlanet)
        {
            MovePlanet();

            _currentPlanet = Instantiate(planetPrefabs[Random.Range(0, planetPrefabs.Count)],
                planetSpawnPoints[Random.Range(0, planetSpawnPoints.Count)].position,
                Quaternion.identity);

            MessageAboutNextPlanet.Instance.SetNextPlanet(false);
        }
    }
    private void MovePlanet()
    {
        _currentPlanet.transform.position = new Vector2(0, planetPositionY);

        if (_oldPlanets == null)
        {
            _oldPlanets = new GameObject("OldPlanets");
        }
        _currentPlanet.transform.SetParent(_oldPlanets.transform);
    }

}
