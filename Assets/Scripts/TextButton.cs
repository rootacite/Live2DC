using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextButton : MonoBehaviour
{
    TextMeshPro TMP;
    // Start is called before the first frame update
    void Start()
    {
        TMP = GetComponent<TextMeshPro>();
        var BC2D = this.gameObject.AddComponent<BoxCollider2D>();
        var RT = GetComponent<RectTransform>();

        BC2D.offset = new Vector2(0, 0);
        BC2D.size = new Vector2(RT.rect.width, RT.rect.height);

    }
    public event Action OnClick;
    private void OnMouseUpAsButton()
    {
        OnClick?.Invoke();



        if (BookClick.n_BookObject)
        {
            BookClick.Showed_book = false;
            Destroy(BookClick.n_BookObject);
            BookClick.n_BookObject = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        StopAllCoroutines();

        IEnumerator Faded()
        {
            while (TMP.color.a > 0.35f)
            {
                var c = TMP.color;
                c.a -= 0.03f;
                TMP.color = c;
                yield return new WaitForSeconds(0.01f);
            }
        }

        StartCoroutine(Faded());
    }
    private void OnMouseExit()
    {
        StopAllCoroutines();


        IEnumerator Faded()
        {
            while (TMP.color.a < 1f)
            {
                var c = TMP.color;
                c.a += 0.03f;
                TMP.color = c;
                yield return new WaitForSeconds(0.01f);
            }
        }



        StartCoroutine(Faded());
    }
}
