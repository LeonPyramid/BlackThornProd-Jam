using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAnimation : MonoBehaviour
{
    public GameObject fireworks;
    private bool win;
    public Color[] colormin;
    public Color[] colormax;
    public int range;
    public GameObject camera;
    public bool first;
    // Start is called before the first frame update
    void Start()
    {
        first = true;
        camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        win = FindObjectOfType<GlobalVar>().win;
        if (win&&first)
        {
            first = false;
            StartCoroutine(Generator(range));
        }
    }

    public void GenerateFireworks (float lrange)
    {
        float x = Random.Range(-lrange, lrange);
        float y = Random.Range(-lrange, lrange);
        float z = Random.Range(-lrange, lrange);
        Vector3 pos = new Vector3(x,y,FindObjectOfType<WinAnimation>().transform.position.z);
        GameObject fireW = GameObject.Instantiate<GameObject>(fireworks, pos, new Quaternion ());
        int rand = Random.Range(0, 5);
        var ps = fireW.GetComponent<ParticleSystem>();
        var main = ps.main;
        main.startColor = new ParticleSystem.MinMaxGradient(colormin[rand], colormax[rand]);

    }
    public IEnumerator Generator ( float range)
    {
        GenerateFireworks(range);
        float time = Random.Range(0.1f, 0.5f);
        yield return new WaitForSeconds(time);
        GenerateFireworks(range);
        time = Random.Range(0.1f, 0.5f);
        yield return new WaitForSeconds(time);
        GenerateFireworks(range);
        time = Random.Range(0.1f, 0.5f);
        yield return new WaitForSeconds(time);
        GenerateFireworks(range);
        Destroy(this.gameObject);
    }
}
