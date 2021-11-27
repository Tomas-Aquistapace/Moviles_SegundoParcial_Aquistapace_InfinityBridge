public abstract class LoggerImpl
{

    public abstract void SendLog(string msg);

    public abstract void ShowAlertView(string[] strings, System.Action<int> handler = null);

    public abstract void SaveScore(int score);

    public abstract int GetScore();

}
