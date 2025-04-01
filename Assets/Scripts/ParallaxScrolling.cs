using UnityEngine;

public class ParallaxScrolling : MonoBehaviour
{
    public float scrollSpeed = 2f; // Kecepatan scroll
    public float parallaxFactor = 0.5f; // Efek parallax
    public bool stop = false; // Status untuk menghentikan background

    private Transform bg1, bg2;
    private float backgroundWidth;

    void Start()
    {
        // Ambil kedua background
        bg1 = transform.GetChild(0);
        bg2 = transform.GetChild(1);

        // Pastikan lebar background benar
        backgroundWidth = bg1.GetComponent<SpriteRenderer>().bounds.size.x;

        // Atur posisi awal agar bg2 langsung mengikuti bg1
        bg2.position = new Vector3(bg1.position.x + backgroundWidth, bg1.position.y, bg1.position.z);
    }

    void Update()
    {
        // Jika status stop = true, background tidak bergerak
        if (stop) return;

        // Gerakkan kedua background ke kiri
        bg1.position += Vector3.left * scrollSpeed * Time.deltaTime;
        bg2.position += Vector3.left * scrollSpeed * Time.deltaTime;

        // Jika bg1 keluar dari layar, pindahkan ke kanan bg2
        if (bg1.position.x < -backgroundWidth)
        {
            bg1.position = new Vector3(bg2.position.x + backgroundWidth, bg1.position.y, bg1.position.z);
            SwapBackgrounds();
        }

        // Jika bg2 keluar dari layar, pindahkan ke kanan bg1
        if (bg2.position.x < -backgroundWidth)
        {
            bg2.position = new Vector3(bg1.position.x + backgroundWidth, bg2.position.y, bg2.position.z);
            SwapBackgrounds();
        }
    }

    void SwapBackgrounds()
    {
        // Tukar referensi bg1 dan bg2 agar selalu bergantian
        Transform temp = bg1;
        bg1 = bg2;
        bg2 = temp;
    }

    // Fungsi untuk mengubah status stop
    public void SetStopStatus(bool status)
    {
        stop = status;
    }
}
