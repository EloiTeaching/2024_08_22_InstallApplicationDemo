using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class ListenToUdpPortMono : MonoBehaviour
{
    private UdpClient udpClient;
    private Thread listenThread;
    private bool isRunning = true;

    public int port = 12345;

    public string m_lastReceivedMessage;

    public Queue<string> m_messageReceivedQueue = new Queue<string> ();
    public UnityEvent<string> m_onMessageReceivedOnUnityThread; 

    public void Update()
    {
        while (m_messageReceivedQueue!=null && m_messageReceivedQueue.Count > 0) {
            m_lastReceivedMessage = m_messageReceivedQueue.Dequeue ();
            m_onMessageReceivedOnUnityThread.Invoke(m_lastReceivedMessage);

        }
    }




    void Start()
    {
        // Start the UDP listener thread
        listenThread = new Thread(new ThreadStart(ListenForMessages));
        listenThread.Start();
    }

    private void OnDisable()
    {
        isRunning = false;


    }
    private void OnDestroy()
    {
        isRunning = false;


    }

    void ListenForMessages()
    {
        try
        {
            udpClient = new UdpClient(port);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, port);

            while (isRunning)
            {
                byte[] receiveBytes = udpClient.Receive(ref endPoint);
                string receivedData = Encoding.UTF8.GetString(receiveBytes);
                m_messageReceivedQueue.Enqueue(receivedData);
                Thread.Sleep(1);
            }
        }
        catch (Exception e)
        {
            Debug.LogError($"Error in UDP listener: {e.Message}");
        }
        finally
        {
            udpClient.Close();
        }
    }

    private void OnApplicationQuit()
    {
        isRunning = false; // Signal the thread to stop
    }
}
