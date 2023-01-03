using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arac : MonoBehaviour
{
     // Siyah çizgi üzerinde takip edilecek nokta
    public Transform targetPoint;

    // Arabanın hareketini kontrol etmek için gereken komponentler
    private Rigidbody rb;
    private Transform transform;

    // Hareket hızı ve dönme hızı
    public float speed = 10f;
    public float turnSpeed = 10f;

    void Start()
    {
        // Komponentleri çek
        rb = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        // Arabanın rotasyonunu siyah çizgi üzerinde takip edilecek noktaya doğru ayarla
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetPoint.position - transform.position), turnSpeed * Time.deltaTime);

        // Arabayı hareket ettir
        rb.AddForce(transform.right * speed);
    }
}
