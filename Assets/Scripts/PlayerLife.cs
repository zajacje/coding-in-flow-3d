using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy Body")) {
            Die();
        }
    }

    void Die() {
        // Make player invisible
        GetComponent<MeshRenderer>().enabled = false;

        // Stop other objects pushing the player
        GetComponent<Rigidbody>().isKinematic = true;

        // Disable player movement
        GetComponent<PlayerMovement>().enabled = false;

        // Alternatively, Destroy(gameObject).
        // But this destroys the player and PlayerLife script, so we cannot reset the level.

        // Reload the level... with a delay using Invoke
        Invoke(nameof(ReloadCurrentLevel), 1.3f);
    }

    void ReloadCurrentLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
