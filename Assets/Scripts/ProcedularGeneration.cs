using System.Collections.Generic;
using UnityEngine;

public class ProcedularGeneration : MonoBehaviour
{
    [SerializeField] private ReturnToHome returnPlayer;
    [Space]
    [SerializeField] private float planetPositionY = -2.41f;
    [SerializeField] private GameObject firstPlanet;
    [SerializeField] private GameObject basePlanet;
    [SerializeField] private List<GameObject> planetPrefabs;
    [SerializeField] private List<Transform> planetSpawnPoints;
    private GameObject _currentPlanet = null;
    private GameObject _previousPlanet = null;
    private GameObject _prepreviousPlanet = null;
    private GameObject _oldPlanets = null;

    private void Start()
    {
        MessageAboutNextPlanet.Instance.NextPlanet += OnPlanetEnd;
    }
    public void OnPlanetEnd()
    {
        MovePlanet();
        _currentPlanet = Instantiate(RandomPlanet(), RandomSpawnPoint().position, Quaternion.identity);
    }
    private void MovePlanet()
    {
        if (_prepreviousPlanet != null)
        {
            _prepreviousPlanet?.transform.SetParent(_oldPlanets.transform);
            _prepreviousPlanet.SetActive(false);
        }

        if (basePlanet != null && basePlanet.activeSelf)
        {
            basePlanet.SetActive(false);
        }

        if (_currentPlanet != null)
        {
            _previousPlanet = _currentPlanet;
            _currentPlanet = null;
        }
        else
        {
            firstPlanet.transform.position = new Vector2(0, planetPositionY);
            _prepreviousPlanet = firstPlanet;
        }

        if (_previousPlanet != null)
        {
            _previousPlanet.transform.position = new Vector2(0, planetPositionY);
            _prepreviousPlanet = _previousPlanet;
        }

        if (_oldPlanets == null)
        {
            _oldPlanets = new GameObject("OldPlanets");
        }

        returnPlayer.Return();
    }
    private GameObject RandomPlanet()
    {
        return planetPrefabs[Random.Range(0, planetPrefabs.Count)];
    }
    private Transform RandomSpawnPoint()
    {
        return planetSpawnPoints[Random.Range(0, planetSpawnPoints.Count)];
    }
    private void OnDisable()
    {
        MessageAboutNextPlanet.Instance.NextPlanet -= OnPlanetEnd;
    }
}
