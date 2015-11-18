using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
   // public GameObject prefabGrenade;
    public GameObject prefabBullet;

    Transform camTr;
    Transform spawnpoint;

    bool modeAuto;
    //public float forceGrenade = 10f;
    public float forceBullet = 100f;
    float timer;
    public float shootRate = 0.2f;

    // Use this for initialization
    void Start()
    {
        Camera cam = (Camera)FindObjectOfType(typeof(Camera));
        if (cam == null)Debug.LogError("No camera found");
        camTr = cam.GetComponent<Transform>();
        spawnpoint = transform.Find("Spawn");
        if (spawnpoint == null) Debug.LogError("No spawn point found");
        modeAuto = true;
    }

    // Update is called once per frame
    void Update()
    {
      // if (Input.GetMouseButtonDown (1))
       // {
        //    GameObject cloneGrenade = (GameObject)Instantiate(prefabGrenade, spawnpoint.position, transform.rotation);
       //     cloneGrenade.rigidbody.AddForce((camTr.forward + camTr.up).normalized * forceGrenade, ForceMode.Impulse);
       // }

        if (modeAuto)
        {
            if (Input.GetMouseButton(0))
            {
                timer -= Time.deltaTime;
                if (timer <= 0.0f)
                {
                    Shoot();
                    timer = shootRate;
                }
            }
            if (Input.GetMouseButtonUp(0))
                timer = 0f;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            modeAuto = !modeAuto;
        }
    }

    void Shoot()
    {
        GameObject cloneBullet = (GameObject)Instantiate(prefabBullet, spawnpoint.position, transform.rotation);
        cloneBullet.rigidbody.AddForce((camTr.forward).normalized * forceBullet, ForceMode.Impulse);
        Destroy(cloneBullet, 1.0f);
    }
}