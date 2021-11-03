[System.Serializable]
public class PlayerData
{
    // Score:
    public int points;
    public int coins;

    // Skins:
    public int skin;
    public bool froggy;
    public bool skelly;

    public PlayerData(PlayerState player)
    {
        if (player != null)
        {
            points = player.points;
            coins = player.coins;

            skin = player.skin;

            froggy = player.froggy;
            skelly = player.skelly;
        }
        else
        {
            points = 0;
            coins = 0;

            skin = 0;

            froggy = false;
            skelly = false;
        }
    }
}
