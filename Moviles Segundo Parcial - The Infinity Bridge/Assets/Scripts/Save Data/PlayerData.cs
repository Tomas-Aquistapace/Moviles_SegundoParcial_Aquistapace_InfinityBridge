[System.Serializable]
public class PlayerData
{
    public int points;

    public PlayerData(PlayerState player)
    {
        if (player != null)
            points = player.points;
        else
            points = 0;
    }
}
