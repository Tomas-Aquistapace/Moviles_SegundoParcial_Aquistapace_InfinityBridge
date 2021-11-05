using UnityEngine;

public class ReceiveDamage : MonoBehaviour
{
    public LoseController loseController;

    public void RestoreState()
    {
        loseController.AbleToReceiveDamage();
    }
}