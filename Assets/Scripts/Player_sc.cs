using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_sc : MonoBehaviour
{
    public GameObject PlayerHealth;
    TextMeshProUGUI PlayerHealth_text;
    Rigidbody rbody;
    public float speed;
    [SerializeField]
    private float horizontalInput;
    [SerializeField]
    private float verticalInput;
    public GameObject kamera;
    public float mouseX, mouseY;
    public float saglik;

    public float MaxSaglik;
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        PlayerHealth_text = PlayerHealth.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        Hareket();
        MauseHareket();  
        Ziplama();      
        PlayerHealth_text.text = saglik.ToString();

    }
    bool zeminde;
    float ziplama = 0.7f;
    public void Ziplama(){
        if (Input.GetAxis("Jump") > 0.0f){
            if (zeminde)
            {   
                rbody.AddForce(new Vector3(0, ziplama, 0), ForceMode.Impulse);
            }
        }
    }
    void OnCollisionStay(Collision collision){
		if(collision.gameObject.tag == "platform")
		{
            zeminde = true;
		}
	}
    void OnCollisionExit(Collision collision){
        if (collision.gameObject.tag == "platform")
        {
            zeminde = false;
        }
    }
    public void Hareket()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed * horizontalInput);
        transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed * verticalInput);
    }
    public void MauseHareket()
    {
        float hiz = 2f;
        mouseX = Input.GetAxis("Mouse X") * hiz;
        //mouseY = Input.GetAxis("Mouse Y") * hiz;
        //kamera.transform.rotation *= Quaternion.Euler(new Vector3(-mouseY, 0, 0));
        transform.rotation *= Quaternion.Euler(new Vector3(0, mouseX, 0));
    }

    public void Hasar()
    {
        saglik -= GameObject.FindObjectOfType<Enemy_sc>().EnemyDamage;

        if (saglik < 1)
        {
            GameObject.FindObjectOfType<GameControl_sc>().PlayerDeath();
        }

    }
}
