using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Rain : MonoBehaviour
{
    public GameObject rain;
    void Start()
    {
        StartCoroutine(RainCoroutine());
    }

    IEnumerator RainCoroutine()
    {
        while (true)
        {
            rain.SetActive(true);
            yield return new WaitForSeconds(Random.Range(1f, 2f));
            rain.SetActive(false);
            yield return new WaitForSeconds(Random.Range(1f, 3f));
        }
    }
}
