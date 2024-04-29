using System.Collections;
using Mirror;
using UnityEngine;
using UnityEngine.Serialization;

namespace Wcng
{
    public class MatchNetworkManager : NetworkManager
    {
        [SerializeField] private TurnBasedNetWorkManager manager;
        /// <summary>
        /// Runs on both Server and Client
        /// Networking is NOT initialized when this fires
        /// </summary>
        public override void Awake()
        {
            base.Awake();
        }

        #region Server System Callbacks

        /// <summary>
        /// Called on the server when a client is ready.
        /// 服务端等待链接
        /// <para>The default implementation of this function calls NetworkServer.SetClientReady() to continue the network setup process.</para>
        /// </summary>
        /// <param name="conn">Connection from client.</param>
        public override void OnServerReady(NetworkConnectionToClient conn)
        {
            base.OnServerReady(conn);
            manager.OnServerReady(conn);
        }

        /// <summary>
        /// Called on the server when a client disconnects.
        /// 服务端断开链接
        /// <para>This is called on the Server when a Client disconnects from the Server. Use an override to decide what should happen when a disconnection is detected.</para>
        /// </summary>
        /// <param name="conn">Connection from client.</param>
        public override void OnServerDisconnect(NetworkConnectionToClient conn)
        {
            StartCoroutine(DoServerDisconnect(conn));
        }

        IEnumerator DoServerDisconnect(NetworkConnectionToClient conn)
        {
            base.OnServerDisconnect(conn);
            yield return null;
        }

        #endregion

        #region Client System Callbacks

        /// <summary>
        /// Called on the client when connected to a server.
        /// 客户端链接中
        /// <para>The default implementation of this function sets the client as ready and adds a player. Override the function to dictate what happens when the client connects.</para>
        /// </summary>
        public override void OnClientConnect()
        {
            base.OnClientConnect();
        }

        /// <summary>
        /// Called on clients when disconnected from a server.
        /// 客户端断开链接
        /// <para>This is called on the client when it disconnects from the server. Override this function to decide what happens when the client disconnects.</para>
        /// </summary>
        public override void OnClientDisconnect()
        {
            base.OnClientDisconnect();
        }

        #endregion

        #region Start & Stop Callbacks

        /// <summary>
        /// This is invoked when a server is started - including when a host is started.
        /// 开启服务端时调用
        /// <para>StartServer has multiple signatures, but they all cause this hook to be called.</para>
        /// </summary>
        public override void OnStartServer()
        {
            base.OnStartServer();
            manager.OnStartServer();
        }

        /// <summary>
        /// This is invoked when the client is started.
        /// 开启客户端调用
        /// </summary>
        public override void OnStartClient()
        {
            base.OnStartClient();
            manager.OnStartClient();
        }

        /// <summary>
        /// This is called when a server is stopped - including when a host is stopped.
        /// 停止服务端时调用
        /// </summary>
        public override void OnStopServer()
        {
            base.OnStopServer();
        }

        /// <summary>
        /// This is called when a client is stopped.
        /// 停止客户端时调用
        /// </summary>
        public override void OnStopClient()
        {
            base.OnStopClient();
        }

        #endregion


        public void SendMatchList(TurnBasedMessageType type) => manager.SendMatchList(type);
    }
}
