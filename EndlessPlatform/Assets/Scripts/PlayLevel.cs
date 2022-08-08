using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayLevel : MonoBehaviour
{
    [SerializeField]
    public GameObject player;
    public bool isPlaying = false;
    public PlayerData playerData;
    
    void Start()
    {

    }
    
    void Update()
    {
        if (isPlaying)
        {
            
        }
    }

    public void StartPlaying()
    {
		Instantiate(player);
        this.isPlaying = true;
        player.GetComponent<Rigidbody2D>().AddForce(transform.right * playerData.hRunSpeed);
    }

    public void EndPlaying()
    {
        this.isPlaying = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}
