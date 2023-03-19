using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    int coinsCollected = 0;

    [SerializeField] TMP_Text coinsText;

    [SerializeField] AudioSource collectionSound;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Coin")) {
            Destroy(other.gameObject);
            coinsCollected += 1;
            coinsText.text = "Coins: " + coinsCollected;
            collectionSound.Play();
        }
    }
}
