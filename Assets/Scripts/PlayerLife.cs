using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private bool dead = false;
    private readonly float lowestPlatformY = -1;

    [SerializeField] AudioSource deathSound;

    private void Update() {
        // So we don't die on each frame during delay
        if (transform.position.y < lowestPlatformY && !dead) {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy Body")) {
            // Make player invisible
            GetComponent<MeshRenderer>().enabled = false;

            // Stop other objects pushing the player
            GetComponent<Rigidbody>().isKinematic = true;

            // Disable player movement
            GetComponent<PlayerMovement>().enabled = false;

            // Alternatively, Destroy(gameObject).
            // But this destroys the player and PlayerLife script, so we cannot reset the level.

            Die();
        }
    }

    void Die() {
        
        dead = true;

        // Reload the level... with a delay using Invoke
        Invoke(nameof(ReloadCurrentLevel), 1.3f);

        deathSound.Play();
    }

    void ReloadCurrentLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
