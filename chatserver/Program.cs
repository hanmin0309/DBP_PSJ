using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Threading;

TcpListener listener = null;
List<StreamWriter> clients = new List<StreamWriter>();

try
{
    int port = 9000;
    listener = new TcpListener(IPAddress.Any, port);
    listener.Start();

    Console.WriteLine("채팅 서버 시작됨. 포트: " + port);

    while (true)
    {
        TcpClient client = listener.AcceptTcpClient();
        Console.WriteLine("클라이언트 접속!");

        Thread t = new Thread(HandleClient!);
        t.IsBackground = true;
        t.Start(client);
    }
}
catch (Exception ex)
{
    Console.WriteLine("서버 오류: " + ex.Message);
}
finally
{
    listener?.Stop();
}

void HandleClient(object obj)
{
    TcpClient client = (TcpClient)obj;

    using NetworkStream ns = client.GetStream();
    using StreamReader reader = new StreamReader(ns, Encoding.UTF8);
    using StreamWriter writer = new StreamWriter(ns, Encoding.UTF8) { AutoFlush = true };

    lock (clients)
    {
        clients.Add(writer);
    }

    try
    {
        while (true)
        {
            string? msg = reader.ReadLine();
            if (msg == null) break;

            Console.WriteLine("받음: " + msg);
            Broadcast(msg);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("클라이언트 오류: " + ex.Message);
    }
    finally
    {
        lock (clients)
        {
            clients.Remove(writer);
        }

        client.Close();
    }
}

void Broadcast(string msg)
{
    lock (clients)
    {
        foreach (var w in clients)
        {
            try
            {
                w.WriteLine(msg);
            }
            catch
            {
                // 전송 실패 무시
            }
        }
    }
}
