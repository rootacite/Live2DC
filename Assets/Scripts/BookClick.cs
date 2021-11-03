using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookClick : MonoBehaviour
{
    public GameObject BookObject;
    static public bool Showed_book = false;
    static public GameObject n_BookObject;
    private void OnMouseUpAsButton()
    {
        if (BookClick.Showed_book) return;
        Debug.Log("C");
        Showed_book = !Showed_book;

        if (Showed_book)
        {
            n_BookObject = Instantiate(BookObject);
            var B1 = n_BookObject.transform.Find("op1").gameObject;
            B1.GetComponent<TextButton>().OnClick += () =>
            {
                var HiYoRi = GameObject.Find("hiyori_pro_t10").GetComponent<Live2DMController>();
                HiYoRi.StartScript1();
            };
        }
        else
        {
            Destroy(n_BookObject);
            n_BookObject = null;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
