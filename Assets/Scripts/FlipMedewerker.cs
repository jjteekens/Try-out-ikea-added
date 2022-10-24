using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipMedewerker : MonoBehaviour
{
    private SpriteRenderer sprite;
    private float dirX = 0f;

    // Update is called once per frame
    void Update()
    {
        if (dirX > 0f)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }
    }
}
