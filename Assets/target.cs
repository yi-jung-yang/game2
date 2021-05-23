using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    Rigidbody rb;
    gameManager gm;
    public int pointvalue;
    public ParticleSystem p;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * Random.Range(12, 16), ForceMode.Impulse);
        rb.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-4, 4), -6);
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();
    }

    private void OnMouseDown()
    {
        if (gm.isplay)
        {
            Destroy(gameObject);
            gm.updateScore(pointvalue);
            Instantiate(p, transform.position, p.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gm.GameOver();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
