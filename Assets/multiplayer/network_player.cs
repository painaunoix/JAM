using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkPlayer : NetworkBehaviour
{

  //  public CharacterController playerController;
    public Cinemachine.CinemachineVirtualCamera playerCam;
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

   //     playerController.enabled = IsOwner;
        playerCam.Priority = IsOwner ? 1 : 0;
    }
}
