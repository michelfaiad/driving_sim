using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Header("Object References")]
    [Tooltip("Player Object")]
    [SerializeField] GameObject player;

    //Private variables
    Vector3 offset = new Vector3(0f, 6.87f, -9.03f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
