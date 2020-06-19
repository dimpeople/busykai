using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DragDrop : MonoBehaviour
{

    bool isMoveAllowed;
    Collider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0) {
            var touch = Input.GetTouch(0);
            var touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                var touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if (collider == touchedCollider)
                {
                    isMoveAllowed = true;
                }

            } else if (touch.phase == TouchPhase.Moved) {
                if (isMoveAllowed)
                {
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                }
            } else if (touch.phase == TouchPhase.Ended)
            {
                isMoveAllowed = false;
            }
        }
    }
}
