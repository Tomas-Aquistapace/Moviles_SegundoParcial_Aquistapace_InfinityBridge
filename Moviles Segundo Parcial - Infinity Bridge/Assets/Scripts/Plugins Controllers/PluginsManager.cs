public class PluginsManager : MonoBehaviourSingleton<PluginsManager>
{
    private LoggerImpl loggerImpl;

    public override void Awake()
    {
        base.Awake();

#if UNITY_EDITOR || UNITY_STANDALONE
        loggerImpl = new StandAloneLoggerImpl();
#elif UNITY_ANDROID
        loggerImpl = new AquistapaceLoggerImpl();
#endif
        
        StartGame();
    }

    private void OnApplicationQuit()
    {
        EndGame();
    }

    public void StartGame()
    {
        loggerImpl.SendLog("Start Game");
    }

    public void EndGame()
    {
        loggerImpl.SendLog("End Game");
    }

    // -------------------

    public LoggerImpl GetLogger()
    {
        return loggerImpl;
    }
}
