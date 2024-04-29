using System;
using System.Collections.Generic;
using Mirror;
using Mirror.Examples.MultipleMatch;
using UnityEngine;

namespace Wcng
{
    public struct TurnBasedMessage : NetworkMessage
    {
        public TurnBasedMessageType TurnBasedMessageType;
    }
    
    public enum TurnBasedMessageType : byte
    {
        Null,
        Update,
        RoundPass
    }


    public class TurnBasedNetWorkManager : MonoBehaviour
    {
        internal static readonly List<NetworkConnectionToClient> WaitingConnections = new List<NetworkConnectionToClient>();

        private NetworkConnectionToClient host;
        internal void OnServerReady(NetworkConnectionToClient conn)
        {
            if (host == null) host = conn;
            WaitingConnections.Add(conn);
            SendMatchList(TurnBasedMessageType.Null);
        }
        
        [ServerCallback]
        //服务器开启调用：
        internal void OnStartServer()
        {
            //注册Match事件
            NetworkServer.RegisterHandler<TurnBasedMessage>(OnServerMatchMessage);
        }
        
        
        [ServerCallback]
        //订阅的事件
        void OnServerMatchMessage(NetworkConnectionToClient conn, TurnBasedMessage msg)
        {
            switch (msg.TurnBasedMessageType)
            {
                case TurnBasedMessageType.Update:
                {
                    SystemManager.EventSystem.GetManager<NetWorkEventManager>().Publish(NetWorkEventType.UpdateView);
                    break;
                }
                case TurnBasedMessageType.RoundPass:
                {
                    SystemManager.EventSystem.GetManager<NetWorkEventManager>().Publish(NetWorkEventType.RoundPass);
                    break;
                }
            }
        }
        
        
        
        [ClientCallback]
        internal void OnStartClient()
        {
            //客户端订阅事件
            NetworkClient.RegisterHandler<TurnBasedMessage>(OnClientMatchMessage);
        }

        [ClientCallback]
        //订阅的事件
        void OnClientMatchMessage(TurnBasedMessage msg)
        {
            switch (msg.TurnBasedMessageType)
            {
                case TurnBasedMessageType.Update:
                {
                    SystemManager.EventSystem.GetManager<NetWorkEventManager>().Publish(NetWorkEventType.UpdateView);
                    break;
                }
                case TurnBasedMessageType.RoundPass:
                {
                    SystemManager.EventSystem.GetManager<NetWorkEventManager>().Publish(NetWorkEventType.RoundPass);
                    break;
                }
            }
        }
        
        
        [ServerCallback]
        internal void SendMatchList(TurnBasedMessageType type,NetworkConnectionToClient conn = null)
        {
            if (conn != null)
                conn.Send(new TurnBasedMessage { TurnBasedMessageType = type});
            else
                foreach (NetworkConnectionToClient waiter in WaitingConnections)
                {
                    //广播给客户端，不发送给服务端客户端双端
                    if (waiter != host)
                    {
                        waiter.Send(new TurnBasedMessage { TurnBasedMessageType = type });
                    }
                }
        }
    }
}
