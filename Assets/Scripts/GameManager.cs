using Player;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerMovement PMovement;

    private void Awake() {
        Instance = this;
    }

    public void DisablePlayerInput() {
        PMovement.DisableInput();
    }

    public void EnablePlayerInput() {
        PMovement.EnableInput();
    }
}
