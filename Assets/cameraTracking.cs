using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTracking : MonoBehaviour
{
    public GameObject Player;
    private Transform playerLocation;

    private void Start()
    {
        playerLocation = Player.transform;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerLocation.position.x, (playerLocation.position.y), -10);
    }
}
