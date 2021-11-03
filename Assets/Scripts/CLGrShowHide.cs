using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CLGrShowHide : MonoBehaviour
{
    IEnumerator MHide()
    {
        var SR = GetComponent<SpriteRenderer>();

        while (SR.color.a > 0)
        {
            var SC = SR.color;
            SC.a -= 0.02f; ;
            SR.color = SC;

            yield return new WaitForSeconds(0.01f);
        }

        yield break;
    }

    IEnumerator MExpland()
    {
        while (this.transform.localScale.x < 0.98f)
        {
            var tl = this.transform.localScale;
            tl.x += 0.03f;
            this.transform.localScale = tl;

            yield return new WaitForSeconds(0.01f);
        }

        yield return StartCoroutine(MHide());

        Destroy(gameObject);
        yield break;
    }
    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = new Vector3(0, 1, 1);
        StartCoroutine(MExpland());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
