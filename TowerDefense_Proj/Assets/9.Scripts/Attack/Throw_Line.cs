using NUnit.Framework;
using UnityEngine;

public class Throw_Line : MonoBehaviour
{
    public float ThrowPower;

    private void OnTriggerEnter(Collider other)
    {
        if( other.tag != "Enemy")
        {
            return;
        }

        //other.GetComponent<>();
        Debug.Log($"발사체 충돌 :  {this.name}, {other.name}");
    }




    void Start()
    {
        Rigidbody body = this.GetComponent<Rigidbody>();
        body.AddForce(this.transform.forward * ThrowPower);
    }

    void Update()
    {
        
    }
}
