using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveDuration = 2f; // Waktu yang dibutuhkan untuk berpindah
    private Vector3 targetPosition;

    void Start()
    {
        // Atur posisi awal player di x = -11
        transform.position = new Vector3(-11, transform.position.y, transform.position.z);

        // Set target posisi ke x = 0
        targetPosition = new Vector3(-2, transform.position.y, transform.position.z);

        // Mulai perpindahan
        StartCoroutine(MovePlayer());
    }

    IEnumerator MovePlayer()
    {
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition; // Pastikan posisi akhir tepat di target
    }
}