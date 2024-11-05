using System.Collections.Generic;
using UnityEngine;

public class ProcedularGeneration : MonoBehaviour
{
    public GameObject CurrentPlanet => _currentPlanet;
    [SerializeField] private ReturnToHome returnPlayer;
    [Space]
    [SerializeField] private float planetPositionY = -2.41f;
    [SerializeField] private GameObject firstPlanet;
    [SerializeField] private GameObject basePlanet;
    [SerializeField] private List<GameObject> planetPrefabs;
    [SerializeField] private List<Transform> planetSpawnPoints;
    private GameObject _currentPlanet = null;
    private GameObject _oldPlanets = null;
    public void OnPlanetEnd()
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

        if (_currentPlanet != null)
        {
            _currentPlanet.transform.position = new Vector2(0, planetPositionY);
        }
        else
        {
            firstPlanet.transform.position = new Vector2(0, planetPositionY);
        }


        if (_oldPlanets == null)
        {
            _oldPlanets = new GameObject("OldPlanets");
        }
        returnPlayer.Return();
        _currentPlanet?.transform.SetParent(_oldPlanets.transform);
        _currentPlanet?.SetActive(false);
    }
}
