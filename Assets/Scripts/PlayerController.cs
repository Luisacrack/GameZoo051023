using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public PhotonView photonView;
    public GameObject camara;
    public TextMeshPro textNickName;
    public Rigidbody rb;
    private void Start()
    {
        if(photonView.IsMine)// activa todo lo de mi personaje
        {
            textNickName.text = PlayerPrefs.GetString("nickname");
            photonView.Owner.NickName = PlayerPrefs.GetString("nickname");
            camara = GameObject.FindGameObjectWithTag("MainCamera");
            camara.GetComponent<Camera>().enabled =true;
            camara.GetComponent<AudioListener>().enabled =true;
            camara.GetComponent<CameraFollow>().target = this.gameObject.transform;
            camara.GetComponent<CameraFollow>().enabled = true;
        }
        else// para activar cosas del otro jugador
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine)
        {
            float H = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            float V = Input.GetAxis("Vertical") * Time.deltaTime * speed;
            transform.Translate(H,0,V);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 200);
        }
    }
}
