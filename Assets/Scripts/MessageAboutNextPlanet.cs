using System;

public class MessageAboutNextPlanet
{
    private static MessageAboutNextPlanet _instance;
    public static MessageAboutNextPlanet Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MessageAboutNextPlanet();
            }

            return _instance;
        }
    }

    public event Action NextPlanet;
    public void NextPlanetEvent()
    {
        NextPlanet?.Invoke();
    }
}
