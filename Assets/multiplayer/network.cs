using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class host : MonoBehaviour
{
    public void StartClient(){
        NetworkManager.Singleton.StartClient();
    }

    public void StartHost(){
        NetworkManager.Singleton.StartHost();
    }
}
