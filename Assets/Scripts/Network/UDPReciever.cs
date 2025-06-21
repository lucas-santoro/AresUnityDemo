using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Concurrent;

public class UDPReceiver : MonoBehaviour
{
    private UdpClient udpClient;
    private Thread receiveThread;
    public int port = 9000;

    private ConcurrentQueue<string> commandQueue = new ConcurrentQueue<string>();
    [SerializeField] private CommandProcessor processor;

    void Start()
    {
        udpClient = new UdpClient(port);
        receiveThread = new Thread(ReceiveLoop);
        receiveThread.IsBackground = true;
        receiveThread.Start();
        Debug.Log("[udp] listening on port 9000");
    }

    void ReceiveLoop()
    {
        IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, port);
        while (true)
        {
            try
            {
                byte[] data = udpClient.Receive(ref remoteEP);
                string message = Encoding.UTF8.GetString(data).Trim();
                commandQueue.Enqueue(message);
            }
            catch (SocketException ex)
            {
                Debug.LogError($"[udp] socket error: {ex.Message}");
                break;
            }
        }
    }

    void Update()
    {
        while (commandQueue.TryDequeue(out var cmd))
        {
            Debug.Log($"[udp] received: {cmd}");
            processor?.ExecuteCommand(cmd);
        }
    }

    void OnApplicationQuit()
    {
        receiveThread?.Abort();
        udpClient?.Close();
    }
}
