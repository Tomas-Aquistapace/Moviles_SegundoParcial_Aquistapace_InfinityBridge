[System.Serializable]
public class PlayerData
{
    public int points;
    public int coins;

    public PlayerData(PlayerState player)
    {
        if (player != null)
        {
            points = player.points;
            coins = player.coins;
        }
        else
        {
            points = 0;
            coins = 0;
        }
    }
}
