using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    public GameObject[] camaras;
    public Sensor[] sensor;
    float velocidad = 2.0f;
    float velocidad2 = 3.2f;
    float velocidad3 = 0.15f;
    Rigidbody rigidB;    
    Vector3 mov_Entrada;
    bool elegi1=false;
    bool elegi2=false;
    bool elegi3=false;
    void Start()
    {
        rigidB = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(elegi1)
        {
             MoverEn8();
        }
        else if(elegi2)
        {
             MoverSideScroller();
        }
        else if(elegi3)
        {
             MoverCasillas();
        }
        
        
    }
    void MoverEn8()
    {
        camaras[0].SetActive(true);
        camaras[1].SetActive(false);
        camaras[2].SetActive(false);
        float moverH=Input.GetAxisRaw("Horizontal");
        float moverV=Input.GetAxisRaw("Vertical");
        mov_Entrada = new Vector3(moverH, mov_Entrada.y, moverV).normalized;

        rigidB.MovePosition(rigidB.position + mov_Entrada * velocidad * Time.fixedDeltaTime);

    }
    void MoverSideScroller()
    {
        float moverH=Input.GetAxisRaw("Horizontal");
        float moverV=Input.GetAxisRaw("Vertical");
        camaras[0].SetActive(false);
        camaras[1].SetActive(true);
        camaras[2].SetActive(false);
        mov_Entrada = new Vector3(moverH, mov_Entrada.y, mov_Entrada.z).normalized;

        rigidB.MovePosition(rigidB.position + mov_Entrada * velocidad2 * Time.fixedDeltaTime);
        if(Input.GetButtonDown("Jump"))
        {
            rigidB.AddForce(Vector3.up * 3.5f, ForceMode.Impulse);
        }

    }
    void MoverCasillas()
    {
        float moverH=Input.GetAxisRaw("Horizontal");
        float moverV=Input.GetAxisRaw("Vertical");
        camaras[0].SetActive(false);
        camaras[1].SetActive(false);
        camaras[2].SetActive(true);

        if(moverH == 1 && sensor[0].es_Celda)
        {
        
            transform.position= new Vector3(transform.position.x+velocidad3, transform.position.y, transform.position.z);

        }
        else if(moverH == -1 &&sensor[1].es_Celda)
        {
            transform.position= new Vector3(transform.position.x-velocidad3, transform.position.y, transform.position.z);
        }
        else if(moverV == 1 && sensor[2].es_Celda)
        {
            transform.position= new Vector3(transform.position.x, transform.position.y, transform.position.z+velocidad3);
        }
        else if(moverV == -1 && sensor[3].es_Celda)
        {
            transform.position= new Vector3(transform.position.x, transform.position.y, transform.position.z-velocidad3);
        }


    }
    public void Elegir1()
    {

       elegi1=true;
       elegi2=false;
       elegi3=false;
    }
    public void Elegir2()
    {

       elegi1=false;
       elegi2=true;
       elegi3=false;
        

    }
    public void Elegir3()
    {

       elegi1=false;
       elegi2=false;
       elegi3=true;
       
    }

}
