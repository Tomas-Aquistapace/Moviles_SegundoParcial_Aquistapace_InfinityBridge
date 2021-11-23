using UnityEngine;

public class PluginsManager : MonoBehaviour
{
    static LoggerImpl loggerImpl;

    private void Awake()
    {
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

    public static LoggerImpl GetLogger()
    {
        return loggerImpl;
    }
}
