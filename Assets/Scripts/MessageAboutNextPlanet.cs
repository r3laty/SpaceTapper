using System;

public class MessageAboutNextPlanet
{
    private static MessageAboutNextPlanet instance;
    private ProcedularGeneration proceduralGeneration;
    public event Action NextPlanet;
    
    public static MessageAboutNextPlanet Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MessageAboutNextPlanet();
            }
            return instance;
        }
    }



    public void NextPlanetEvent()
    {
        NextPlanet?.Invoke();
    }
}
