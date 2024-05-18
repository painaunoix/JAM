using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using System.Threading.Tasks;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Services.Core;
using UnityEngine;
using Unity.Services.Authentication;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;

public class host : MonoBehaviour
{
    private UnityTransport transport;
    public TMPro.TMP_InputField JoinCodeInputField;

    async void Awake() {
        await Authenticate();
    }

    private static async Task Authenticate(){
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }
    void Start() {
        transport = FindObjectOfType<UnityTransport>();
    }
    public async void CreateMultiplayerRelay(){
        Allocation a = await RelayService.Instance.CreateAllocationAsync(8);
        JoinCodeInputField.text = await RelayService.Instance.GetJoinCodeAsync(a.AllocationId);
        transport.SetRelayServerData(a.RelayServer.IpV4, (ushort) a.RelayServer.Port, a.AllocationIdBytes, a.Key, a.ConnectionData);
        NetworkManager.Singleton.StartHost();
    }

    public async void JoinSession(){
        JoinAllocation a = await  RelayService.Instance.JoinAllocationAsync(JoinCodeInputField.text);
        transport.SetClientRelayData(a.RelayServer.IpV4, (ushort) a.RelayServer.Port, a.AllocationIdBytes, a.Key, a.ConnectionData, a.HostConnectionData);
        NetworkManager.Singleton.StartClient();
    }
    public void StartClient(){
        NetworkManager.Singleton.StartClient();
    }

    public void StartHost(){
        NetworkManager.Singleton.StartHost();
    }
}
