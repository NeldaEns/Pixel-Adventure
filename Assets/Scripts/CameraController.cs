using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerMovement player;
    void Update()
    {
        player = FindObjectOfType<PlayerMovement>();
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}
