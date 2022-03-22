using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{

    CapsuleCollider2D playerBodyCollider;

    private void Checklock(int keys)
    {
        if (playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("lock")))
        {
            if (keys == 3)
            {
                Destroy(gameObject);
            }
            if (!(keys == 3))
            {
                //GetComponent<Renderer>().enabled = int;
            }
        }
    }
}
