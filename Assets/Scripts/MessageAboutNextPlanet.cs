using System;
using UnityEngine;

public class MessageAboutNextPlanet : MonoBehaviour
{
    public static MessageAboutNextPlanet Instance;
    [SerializeField] private ProcedularGeneration proceduralGeneration;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void NextPlanetEvent()
    {
        proceduralGeneration.OnPlanetEnd();
    }
}
