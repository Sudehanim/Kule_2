using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nesnedöndür : MonoBehaviour
{
    public float donmeHizi = 100f; // Nesnenin dönme hızı

    private bool hedefeUlasti = false; // Nesnenin hedefe ulaşıp ulaşmadığını kontrol etmek için

    private void Update()
    {
        if (!hedefeUlasti && Input.GetMouseButtonDown(0))
        {
            NesneDon();
        }
    }

    public void HedefNoktayaUlasmadaKontrol(Transform hedefNokta)
    {
        StartCoroutine(KontrolEt(hedefNokta));
    }

    private IEnumerator KontrolEt(Transform hedefNokta)
    {
        while (!hedefeUlasti)
        {
            if (transform.position.y <= hedefNokta.position.y)
            {
                Oyun.instance.OyunuKaybet();
                break;
            }
            yield return null;
        }
    }

    private void NesneDon()
    {
        transform.Rotate(0f, donmeHizi * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hedef"))
        {
            hedefeUlasti = true;
        }
    }
}
