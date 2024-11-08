using System;

public class MessageAboutNextPlanet
{
    private static MessageAboutNextPlanet instance;
    private ProcedularGeneration proceduralGeneration;
    
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

    public void SetProcedularGeneration(ProcedularGeneration pg)
    {
        proceduralGeneration = pg;
    }

    public void NextPlanetEvent()
    {
        proceduralGeneration.OnPlanetEnd();
    }
}
