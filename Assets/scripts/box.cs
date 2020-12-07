using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{

    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;

    private Collider2D col;

    // Update is called once per frame

    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
      if(isBeingHeld==true)
        {

            
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            isBeingHeld = true;
        }
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;

    
    }

    void OnColliSionEnter2D(Collision Collider)
    {
        if (Collider.gameObject.tag == "grandpa")
        {
            Debug.Log("hit");
        }
    }
}
