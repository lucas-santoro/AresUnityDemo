using UnityEngine;
using System.Net.Sockets;
using System.Text;

public class GameStatsReporter : MonoBehaviour
{
    [SerializeField] private TimerService timerService;

    private int shotsFired = 0;
    private int targetsHit = 0;
    private float elapsedTime = 0f;

    private UdpClient udpClient;
    private string targetIP = "127.0.0.1";
    private int targetPort = 8089;

    void Start()
    {
        udpClient = new UdpClient();
        TurretShooter.OnRealFire += HandleFire;
        TargetManager.Instance.OnTargetDestroyed += HandleTargetDestroyed;
    }

    void OnDestroy()
    {
        udpClient?.Close();
        TurretShooter.OnRealFire -= HandleFire;
        TargetManager.Instance.OnTargetDestroyed -= HandleTargetDestroyed;
    }

    void Update()
    {
        if (timerService.IsRunning)
            elapsedTime += Time.deltaTime;
    }

    void HandleFire() => shotsFired++;
    void HandleTargetDestroyed() => targetsHit++;

    public void SendGameStats()
    {
        string message = $"GAME_OVER|{elapsedTime:F1}|{shotsFired}|{targetsHit}";
        byte[] data = Encoding.UTF8.GetBytes(message);
        udpClient.Send(data, data.Length, targetIP, targetPort);
    }
}
