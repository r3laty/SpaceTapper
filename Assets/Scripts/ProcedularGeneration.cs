using System.Collections.Generic;
using UnityEngine;

public class ProcedularGeneration : MonoBehaviour
{
    public GameObject CurrentPlanet { get => _currentPlanet; set => _currentPlanet = value; }
    public GameObject PrelastPlanet { get => _prelastPlanet; set => _prelastPlanet = value; }
    public GameObject LastPlanet { get => _lastPlanet; set => _lastPlanet = value; }
    public GameObject BasePlanet { get => basePlanet; set => basePlanet = value; }
    public GameObject FirstPlanet { get => firstPlanet; set => firstPlanet = value; }
    [SerializeField] private ReturnToHome returnPlayer;
    [Space]
    [SerializeField] private float planetPositionY = -2.41f;
    [SerializeField] private GameObject firstPlanet;
    [SerializeField] private GameObject basePlanet;
    [SerializeField] private List<GameObject> planetPrefabs;
    [SerializeField] private List<Transform> planetSpawnPoints;
    private GameObject _currentPlanet = null;
    private GameObject _prelastPlanet = null;
    private GameObject _lastPlanet = null;
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
        if (_lastPlanet != null)
        {
            _lastPlanet?.transform.SetParent(_oldPlanets.transform);
            _lastPlanet.SetActive(false);
        }

        if (basePlanet != null && basePlanet.activeSelf)
        {
            basePlanet.SetActive(false);
        }

        if (_currentPlanet != null)
        {
            _prelastPlanet = _currentPlanet;
            _currentPlanet = null;
        }
        else
        {
            firstPlanet.transform.position = new Vector2(0, planetPositionY);
            _lastPlanet = firstPlanet;
        }

        if (_prelastPlanet != null)
        {
            _prelastPlanet.transform.position = new Vector2(0, planetPositionY);
            _lastPlanet = _prelastPlanet;
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
