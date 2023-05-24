using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatBullet : PlatGunScript
{
    private Vector3 target;
    [SerializeField]
    private float speed;
    public GameObject platformPrefab;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position == target)
            DestroyBullet();
    }

    public void SetTarget(Vector3 target)
    {
        this.target = target;
    }

    // ボックスコライダーを使って、銃玉がEnvironmentというタグついてるものをぶつかると消える
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Environment"))
        {
            GetComponent<PlatGunScript>().bulletFired = false;
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
        Instantiate(platformPrefab, transform.position, Quaternion.identity);
    }
}
