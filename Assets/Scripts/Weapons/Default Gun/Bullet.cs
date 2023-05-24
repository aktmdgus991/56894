using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public float timer;

    /*// マズルフラッシュの部分
    // https://www.youtube.com/watch?v=jOIi8Y7XbiA
    public Sprite flashSprite;
    [Range(0, 5)]
    public int framesToFlash = 1;

    private Sprite defaultSprite;*/


    // 約９分辺りで https://www.youtube.com/watch?v=-bkmPm_Besk
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

        //StartCoroutine(DoFlash());
    }


    // Update is called once per frame
    void Update()
    {
        // 設定した時間の後で銃玉が消える
        timer += 1.0F * Time.deltaTime;
        if (timer >= 3)
            GameObject.Destroy(gameObject);
    }

    // ボックスコライダーを使って、銃玉がEnvironmentというタグついてるものをぶつかると消える
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Environment"))
            Destroy(gameObject);
    }


    /*IEnumerator DoFlash()
    {
        var renderer = GetComponent<SpriteRenderer>();
        var originalSprite = renderer.sprite;
        renderer.sprite = flashSprite;

        var framesFlashed = 0;
        while(framesFlashed < framesToFlash)
        {
            framesFlashed++;
            yield return null;
        }

        renderer.sprite = originalSprite;
    }*/
}
