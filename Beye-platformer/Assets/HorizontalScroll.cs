using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalScroll : MonoBehaviour
{
    [SerializeField] float scrollSpeed = 0.2f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(scrollSpeed * Time.deltaTime, 0.0f));
    }
}
