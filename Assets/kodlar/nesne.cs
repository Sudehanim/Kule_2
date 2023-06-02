using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nesne : MonoBehaviour
{
    Vector3 pos;
    public GameObject[] objects;
    public GameObject nesnePrefab; // Olu?turulacak nesne prefab?
    public Transform olusturmaNoktasi; // Nesnelerin olu?turulaca?? nokta
    public Transform hedefNokta; // Nesnelerin dü?mesi gereken hedef nokta
    public float atisGucu = 10f; // Nesnelerin at?lma gücü

    private bool oyunDevamEdiyor = true; // Oyunun devam edip etmedi?ini kontrol etmek için
    void Start()
    {
        int index = Random.Range(0, objects.Length);
        Instantiate(objects[index], transform.position, Quaternion.identity);

    }
    private void Update()
    {
            pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            Vector3 newpos = Camera.main.ScreenToViewportPoint(pos);
            float x = Mathf.Clamp(newpos.x, -7, 7);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);

        
        if (oyunDevamEdiyor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                NesneOlustur();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                YeniOyun();
            }
        }
    }

    private void NesneOlustur()
    {
        GameObject yeniNesne = Instantiate(nesnePrefab, olusturmaNoktasi.position, Quaternion.identity);
        Rigidbody nesneRigidbody = yeniNesne.GetComponent<Rigidbody>();
        nesneRigidbody.AddForce(Vector3.down * atisGucu, ForceMode.Impulse);
        yeniNesne.GetComponent<NesneKontrol>().HedefNoktayaUlasmadaKontrol(hedefNokta);
    }

    public void OyunuKaybet()
    {
        oyunDevamEdiyor = false;
        Debug.Log("Oyunu Kaybettin!");
    }

    private void YeniOyun()
    {
        oyunDevamEdiyor = true;
        // Yeni oyun ba?latma i?lemleri burada yap?labilir
    }
}
