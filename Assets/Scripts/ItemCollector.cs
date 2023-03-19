using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    int coinsCollected = 0;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Coin")) {
            Destroy(other.gameObject);
            coinsCollected += 1;
            Debug.Log("Coins: " + coinsCollected);
        }
    }
}
