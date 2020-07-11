using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private PlayerController player;

    private void Awake() 
    {
        player = GetComponentInParent<PlayerController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!enabled)
        {
            return;
        }

        if (other.tag == "Eel")
        {
            player.OnHitEel();
        }
        else if (other.tag == "Chip")
        {
            player.OnHitChip();
        }
    }
}
