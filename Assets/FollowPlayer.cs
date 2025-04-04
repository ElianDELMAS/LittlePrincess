using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 marginFromPlayer;

    // Start is called before the first frame update
    void Start()
    {
        marginFromPlayer = new Vector3(0f, 25.0f, 25.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + marginFromPlayer;
    }
}
