using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        IEnumerator Show()
        {
            var SP = gameObject.GetComponent<SpriteRenderer>();
            while (SP.color.a < 0.98f)
            {
                var c = SP.color;
                c.a += 0.03f;
                SP.color = c;

                yield return new WaitForSeconds(0.01f);
            }

        }

        StartCoroutine(Show());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
