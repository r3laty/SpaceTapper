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

    public bool IsNextPlanet { get; private set; }

    public void SetNextPlanet(bool value)
    {
        IsNextPlanet = value;
    }
}
