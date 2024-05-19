using System.Collections;
using System.Collections.Generic;
using Invector.vCharacterController;
using Unity.Netcode;
using UnityEngine;

public class NetworkPlayer : NetworkBehaviour
{

    public vThirdPersonController playerController;
    public Cinemachine.CinemachineVirtualCamera playerCam;
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

       playerController.enabled = true;
        playerController.enabled = IsOwner;
        playerCam.Priority = IsOwner ? 1 : 0;
        playerController.enabled = false;
    }
}
