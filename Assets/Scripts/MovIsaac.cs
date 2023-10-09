using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class MovIsaac : MonoBehaviour
{
    public float movX, movY;
    Rigidbody2D rb;
    public bool saltar = false;
    public float fuerzaSalto = 0.5f;
    public bool enSuelo = false;
    public bool gameOver;
    public bool victoria;
    public float tiempo = 0;
    public bool JuegoOn = true;
    public string Contador;
    public bool tenerLlave = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Contador = "Tiempo: 00:00";
        

      

       

        
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
    public void Pausa()
    {
        Time.timeScale = 1.0f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        enSuelo = true;



        if (collision.gameObject.name == "suelo")
        {
            enSuelo = true;
        }
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            Time.timeScale = 0f;

        }
        if (collision.gameObject.name == "trofeo")
        {
            Debug.Log("Victoria");
            victoria = true;
            Time.timeScale = 0f;

        }
        if (collision.gameObject.CompareTag("Pill"))
        {
            Debug.Log("Te haces más pequeño");
            transform.localScale = new Vector2(3.2f, 3.2f);
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
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        Destroy(collision.gameObject);

        if(gameObject.CompareTag("Key"))
        {

            tenerLlave = true;

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
  
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
