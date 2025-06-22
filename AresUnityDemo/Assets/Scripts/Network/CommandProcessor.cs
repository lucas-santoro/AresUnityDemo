using UnityEngine;
using System;

public class CommandProcessor : MonoBehaviour
{
    [SerializeField] CombinedGameStarter starter;

    private TankController tankController;
    private TurretController turretController;
    private TurretShooter turretShooter;

    private bool isGameStarted = false;
    public event Action OnExitCommand;

    public void ExecuteCommand(string cmd)
    {
        switch (cmd.Trim().ToUpperInvariant())
        {
            case "START":
                starter?.OnNativeGameStart();
                Invoke(nameof(SetupPlayerReferences), 0.5f);
                isGameStarted = true;
                break;

            case "MOVE_FORWARD":
                if (isGameStarted)
                    tankController?.Drive(30f, 0f);
                turretController?.Aim(0f, 0f);
                break;
            case "MOVE_BACKWARD":
                if (isGameStarted)
                    tankController?.Drive(-30f, 0f);
                turretController?.Aim(0f, 0f);
                break;
            case "MOVE_LEFT":
                if (isGameStarted)
                    tankController?.Drive(0f, -30f);
                turretController?.Aim(0f, 0f);
                break;
            case "MOVE_RIGHT":
                if (isGameStarted)
                    tankController?.Drive(0f, 30f);
                turretController?.Aim(0f, 0f);
                break;
            case "ROTATE_LEFT":
                if (isGameStarted) turretController?.Aim(-30f, 0f);
                break;
            case "ROTATE_RIGHT":
                if (isGameStarted) turretController?.Aim(30f, 0f);
                break;
            case "ELEVATE_UP":
                if (isGameStarted) turretController?.Aim(0f, 30f);
                break;
            case "ELEVATE_DOWN":
                if (isGameStarted) turretController?.Aim(0f, -30f);
                break;
            case "FIRE":
                if (isGameStarted) turretShooter?.Fire();
                break;
            case "EXIT":
                OnExitCommand?.Invoke();
                break;
        }
    }

    private void SetupPlayerReferences()
    {
        var player = GameManager.PlayerInstance;
        if (player == null)
        {
            Debug.LogWarning("PlayerInstance not found.");
            return;
        }

        tankController = player.GetComponent<TankController>();
        turretController = player.GetComponentInChildren<TurretController>();
        turretShooter = player.GetComponentInChildren<TurretShooter>();
    }
}
