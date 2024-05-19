using System.Collections;
using System.Collections.Generic;
using Invector.vCharacterController;
using Unity.Netcode;
using UnityEngine;

public class NetworkPlayer : NetworkBehaviour
{

    public CharacterController playerController;
    public Camera playerCam;
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        playerController.enabled = IsOwner;
        playerCam.depth = IsOwner ? 1 : 0;
    }
}
