using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CLEventController : MonoBehaviour
{
    public GameObject HiYoRi;
    void DestroyWithoutEvent()
    {
        clicked_flag = -1;
    }
    public Coroutine Show(Action OnClick, string text)
    {
        this.OnClick += OnClick;

        var SPR = this.gameObject.GetComponent<SpriteRenderer>();
        SPR.color = new Color(1, 1, 1, 0);
        TextMeshPro TMP = this.gameObject.transform.Find("MTestC").gameObject.GetComponent<TextMeshPro>();
        TMP.text = text;
        IEnumerator Show()
        {
            while (SPR.color.a < 0.98f)
            {
                var oldc = SPR.color;
                oldc.a += 0.03f;
                SPR.color = oldc;

                yield return new WaitForSeconds(0.01f);
            }

            yield return new WaitUntil(() => clicked_flag != 0);

        //    Destroy(this.GetComponent<CapsuleCollider2D>());
            var SP = GetComponent<SpriteRenderer>();
            IEnumerator Hide()
            {
                while (SP.color.a > 0)
                {
                    var SC = SP.color;
                    SC.a -= 0.03f;
                    SP.color = SC;
                    yield return new WaitForSeconds(0.01f);
                }

                Destroy(this.gameObject);
            }
            if (clicked_flag == 1)
                OnClick?.Invoke();
            yield return StartCoroutine(Hide());
            yield break;
        }

        return StartCoroutine(Show());
    }
    private int clicked_flag = 0;
    private event Action OnClick;
    public GameObject CLGr;
    // Start is called before the first frame update
    void Start()
    {
        HiYoRi = Camera.main.transform.parent.Find("hiyori_pro_t10").gameObject;
        this.transform.parent = Camera.main.transform.parent;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        var _CLGr = Instantiate(CLGr);
        _CLGr.transform.parent = this.gameObject.transform;
        _CLGr.transform.localPosition = new Vector3(0, 0, -1f);

       
    }

    private void OnMouseExit()
    {
       
    }

    private void OnMouseUpAsButton()
    {
        
        if (clicked_flag == 0)
            clicked_flag = 1;
    }


}
