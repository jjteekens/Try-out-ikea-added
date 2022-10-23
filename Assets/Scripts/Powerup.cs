using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powerup : MonoBehaviour
{

    [SerializeField] private AudioSource collectionSoundEffect;
    [SerializeField] private float PowerUpTimer = 0f;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            gameObject.GetComponent<PlayerMovement>().moveSpeed = 14f;
            PowerUpTimer += 10f;
        }
        
    if (PowerUpTimer <= 0f)
        {
            gameObject.GetComponent<PlayerMovement>().moveSpeed = 14f;
        }
    }
}
