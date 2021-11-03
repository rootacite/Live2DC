using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConversationController : MonoBehaviour
{
    public Coroutine ShowConversation(string text, float? time, Action ends)
    {
        GameObject _CP = Instantiate(CP);

        var SRR = _CP.GetComponent<SpriteRenderer>();
        SRR.color = new Color(1, 1, 1, 0);

        IEnumerator SCHide()
        {
            while (SRR.color.a > 0)
            {
                var oldc = SRR.color;
                oldc.a -= 0.05f;
                SRR.color = oldc;

                yield return new WaitForSeconds(0.01f);
            }

            yield break;
        }

        IEnumerator SCShow()
        {
            while (SRR.color.a < 1)
            {
                var oldc = SRR.color;
                oldc.a += 0.05f;
                SRR.color = oldc;

                yield return new WaitForSeconds(0.01f);
            }
            if (time != null)
                yield return new WaitForSeconds(time.Value);
            else
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

            yield return StartCoroutine(SCHide());

            ends?.Invoke();
            Destroy(_CP);
            yield break;
        }

    

        GameObject Container = _CP.transform.Find("Container").gameObject;
        TextMeshPro TMP = Container.GetComponent<TextMeshPro>();

        TMP.text = text;

        return StartCoroutine(SCShow());
    }
    public GameObject CP;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
