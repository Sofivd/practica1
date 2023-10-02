using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovIsaac : MonoBehaviour
{
    public float movX, movY;
    Rigidbody2D rb;
    public bool saltar = false;
    public float fuerzaSalto = 0.5f;
    public bool enSuelo = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");
        Vector2 direccion = new Vector2(movX, movY);
        transform.Translate(direccion * Time.deltaTime * 10);

        if (Input.GetButtonDown("Jump"))
        {
            saltar = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        enSuelo = true;



        if (collision.gameObject.tag == "suelo")
        {
            enSuelo = true;
        }
        else if (collision.gameObject.tag == "keeper")
        {

        }
    }
    void FixedUpdate()
    {
        if (saltar && enSuelo)
        {
            rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            saltar = false;
            enSuelo = false;
        }
    }
}
