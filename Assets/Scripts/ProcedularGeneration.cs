using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcedularGeneration : MonoBehaviour
{
    [SerializeField] private float planetPositionY = -2.41f;
    [SerializeField] private GameObject firstPlanet;
    [SerializeField] private GameObject basePlanet;
    [SerializeField] private List<GameObject> planetPrefabs;
    [SerializeField] private List<Transform> planetSpawnPoints;
    private GameObject _currentPlanet;
    private GameObject _oldPlanets;
    private void OnEnable()
    {
        MessageAboutNextPlanet.Instance.NextPlanet += OnPlanetEnd;
    }
    private void Awake()
    {
        _currentPlanet = firstPlanet;
    }

    private void OnPlanetEnd()
    {
        Debug.Log("OnPlanetEnd");

        MovePlanet();

        _currentPlanet = Instantiate(planetPrefabs[Random.Range(0, planetPrefabs.Count)],
            planetSpawnPoints[Random.Range(0, planetSpawnPoints.Count)].position,
            Quaternion.identity);
    }
    private void MovePlanet()
    {
        if (basePlanet != null)
        {
            basePlanet.SetActive(false);
        }
        _currentPlanet.transform.position = new Vector2(0, planetPositionY);

        if (_oldPlanets == null)
        {
            _oldPlanets = new GameObject("OldPlanets");
        }
        _currentPlanet.transform.SetParent(_oldPlanets.transform);
    }
    private void OnDisable()
    {
        MessageAboutNextPlanet.Instance.NextPlanet -= OnPlanetEnd;
    }

}
