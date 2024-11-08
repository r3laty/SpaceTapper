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
    private GameObject _previousPlanet = null;
    private GameObject _prepreviousPlanet = null;
    private GameObject _oldPlanets = null;

    // 1 - public void OnPlanetEnd() - вызывается когда игрок прибывает на другую планету, в этом скрипте происходит перемещение планеты и создание новой. Сначала перемещаем, берем
    // текущую, которая у нас на сцене 
    // 2 - 
    // 3 - 
    //
    //
    //
    //
    //
    //
    private void Start()
    {
        Debug.Log("7ProcedularGeneration Start");
        MessageAboutNextPlanet.Instance.SetProcedularGeneration(this);
    }
    public void OnPlanetEnd()
    {
        Debug.Log("OnPlanetEnd");

        Debug.Log("call method MovePlanet");
        MovePlanet();
        Debug.Log("MovePlanet finished");
        Debug.Log("Instantiate new planet");
        _currentPlanet = Instantiate(planetPrefabs[Random.Range(0, planetPrefabs.Count)],
            planetSpawnPoints[Random.Range(0, planetSpawnPoints.Count)].position,
            Quaternion.identity);
    }
    private void MovePlanet()
    {
        Debug.Log("enter to method MovePlanet");
        if (_prepreviousPlanet != null)
        {
            Debug.Log($"_prepreviousPlanet != null, _prepreviousPlanet.name = {_prepreviousPlanet.name}");
            _prepreviousPlanet.SetActive(false);
        }
        if (basePlanet != null && basePlanet.activeSelf)
        {
            Debug.Log("MovePlanet basePlanet != null && basePlanet.activeSelf");
            basePlanet.SetActive(false);
        }

        if (_currentPlanet != null)
        {
            Debug.Log("MovePlanet _currentPlanet != null");
            _previousPlanet = _currentPlanet;
            _currentPlanet = null;
//            Debug.Log("MovePlanet _previousPlanet = " + _previousPlanet.name + " _currentPlanet = null");
        }
        else if (_previousPlanet != null)
        {
            _previousPlanet.transform.position = new Vector2(0, planetPositionY);
            _prepreviousPlanet = _previousPlanet;
            Debug.Log("_previousPlanet.transform.position = " + _previousPlanet.transform.position);
        }
        else
        {
            Debug.Log("_currentPlanet == null, firstPlanet.transform.position = " + firstPlanet.transform.position);
            firstPlanet.transform.position = new Vector2(0, planetPositionY);
            _prepreviousPlanet = firstPlanet;
        }

        // if (firstPlanet.activeSelf && firstPlanet.transform.position.y >= planetPositionY && _previousPlanet == null || _currentPlanet == null)
        // {
        //     Debug.Log("MovePlanet firstPlanet.SetActive(false) in if activeself");
        //     firstPlanet.SetActive(false);
        // }


        if (_oldPlanets == null)
        {
            _oldPlanets = new GameObject("OldPlanets");
        }

        returnPlayer.Return();
        // _previousPlanet?.transform.SetParent(_oldPlanets.transform);
    }
}
