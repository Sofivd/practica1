using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovMosca : MonoBehaviour
{
    // Start is called before the first frame update
    bool haciaIzquierda = false;
    bool haciaArriba = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (haciaIzquierda == true)
        {
            transform.Translate(2 * Vector2.left * Time.deltaTime);
            // float escalaX = transform.localScale.x; escalaX - 0.5f, escalaY + 0.5f
            // float escalaY = transform.localScale.y;
            

        }
        else
        {
            transform.Translate(2 * Vector2.right * Time.deltaTime);
            
        }
        if(haciaArriba == true)
        {
            transform.Translate(2 * Vector2.up * Time.deltaTime);
        }
        else
        {
            transform.Translate(2 * Vector2.down * Time.deltaTime);
        }

        if (transform.position.x >= 9)
        {
            haciaIzquierda = true;

        }
        else if (transform.position.x <= 2)
        {
            haciaIzquierda = false;
        }


        if (transform.position.y <= -3)
        {
            haciaArriba = true;

        }
        else if (transform.position.y >= 4)
        {
            haciaArriba = false;
        }
    }
}
