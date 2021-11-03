using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using Live2D.Cubism.Framework.Motion;
using Live2D.Cubism.Framework;
using TMPro;
using System;

public class Live2DMController : MonoBehaviour
{

    public GameObject CL;
    ConversationController CCLR;

    public GameObject m_Parameters;
    public AnimationClip[] animClip;
    CubismEyeBlinkController CEBC;
    private CubismMotionController motion;
    private Dictionary<string, AnimationClip> clip = new Dictionary<string, AnimationClip>();
    // Start is called before the first frame update

    IEnumerator WaitEncoFor13()
    {
        yield return new WaitForSeconds(10);
        yield break;
    }

    IEnumerator CBlick()
    {
        while (true)
        {
            while (CEBC.EyeOpening >= 0)
            {
                CEBC.EyeOpening -= 0.13f;
                yield return new WaitForSeconds(0.01f);
            }

            while (CEBC.EyeOpening <= 1)
            {
                CEBC.EyeOpening += 0.13f;
                yield return new WaitForSeconds(0.01f);
            }

            yield return StartCoroutine(WaitEncoFor13());
        }
    }
    public virtual void PlayMotion(string name, bool isLoop, int priority)
    {
        if (!clip.ContainsKey(name)) return;

        motion.PlayAnimation(clip[name], isLoop: isLoop, priority: priority);
    }
    void Start()
    {
        motion = gameObject.GetComponent<CubismMotionController>();
        CCLR = gameObject.GetComponent<ConversationController>();
        CEBC = this.gameObject.GetComponent<CubismEyeBlinkController>();
        AddMotion();

        StartCoroutine(CBlick());


    }

    bool flag = false;
    // Update is called once per frame
    void Update()
    {
        if (!motion.IsPlayingAnimation())
        {
            System.Random rd = new System.Random();
            if (rd.Next(0, 3) == 0)
            {
                PlayMotion("stand_1", false, 1);
            }
            else
            {
                PlayMotion("stand_2", false, 1);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (!flag)
                PlayMotion("hiyori_m01", false, 2);
            flag = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (!flag)
                PlayMotion("hiyori_m02", false, 2);
            flag = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (!flag)
                PlayMotion("hiyori_m03", false, 2);
            flag = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (!flag)
                PlayMotion("hiyori_m04", false, 2);
            flag = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (!flag)
                PlayMotion("hiyori_m05", false, 2);
            flag = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (!flag)
                PlayMotion("hiyori_m06", false, 2);
            flag = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (!flag)
                PlayMotion("hiyori_m07", false, 2);
            flag = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            if (!flag)
                PlayMotion("hiyori_m08", false, 2);
            flag = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            if (!flag)
                PlayMotion("hiyori_m09", false, 2);
            flag = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            if (!flag)
                PlayMotion("hiyori_m10", false, 2);
            flag = true;
        }
        else
        {
            flag = false;
        }
    }

    public CubismMotionController GetMotion
    {
        get
        {
            return motion;
        }
    }

    public Dictionary<string, AnimationClip> GetClip
    {
        get
        {
            return clip;
        }
    }

    private void AddMotion()
    {
        foreach (var i in animClip)
        {
            clip.Add(i.name, i);
        }
    }

    void OnMouseUpAsButton()
    {
        if (BookClick.Showed_book) return;

        IEnumerator Touch_Head()
        {
            PlayMotion("hiyori_m04", false, 2);
            yield return CCLR.ShowConversation("再多...摸摸头。", 3, null);
        }

        IEnumerator Touch_Face()
        {
            PlayMotion("motion5", false, 2);
            yield return CCLR.ShowConversation("好痒。", 3, null);
        }

        IEnumerator Touch_Opae()
        {
            PlayMotion("hiyori_m10", false, 2);
            yield return CCLR.ShowConversation("不要摸，那种地方......", 3, null);
        }

        IEnumerator Cround()
        {
            yield return CCLR.ShowConversation("请选择一个数字", 3, null);

            int choicefkag = -1;
            var option1 = new Dictionary<string, Action>();
            option1.Add("1",()=> { choicefkag = 1; });
            option1.Add("2", () => { choicefkag = 2; });
            yield return ShowOptions(option1);



            yield return CCLR.ShowConversation(choicefkag.ToString(), 3, null);
        }

        RaycastHit RH;
        bool hitted = Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, out RH);
        if (RH.collider != null)
        {
            Debug.Log(RH.point);

            if (RH.point.y < 5.4f && RH.point.y >= 3.6f)
                StartCoroutine(Touch_Head());
            if (RH.point.y < 3.6f && RH.point.y >= 1.5f)
                StartCoroutine(Touch_Face());
            if (RH.point.y < 1.5f && RH.point.y >= -0.5f)
                StartCoroutine(Touch_Opae());
            if (RH.point.y < -0.5f && RH.point.y >= -2.5f)
                StartCoroutine(Touch_Face());
            if (RH.point.y < -2.5f)
                StartCoroutine(Touch_Opae());
        }

    }

    public Coroutine ShowOptions(Dictionary<string, Action> Options)
    {
        IEnumerator Av()
        {
            int count = Options.Count;
            int index = 0;

            foreach (var i in Options)
            {
                if (index == count - 1)
                {
                    var EButton = Instantiate(CL);
                    var ECCL = EButton.GetComponent<CLEventController>();

                    EButton.transform.parent = this.transform.parent;

                    var Eolol = EButton.transform.localPosition;
                    Eolol.y = 4f - index * 1.5f;
                    EButton.transform.localPosition = Eolol;

                    yield return ECCL.Show(() =>
                    {
                        i.Value?.Invoke();

                        this.transform.parent.gameObject.BroadcastMessage("DestroyWithoutEvent");
                    }, i.Key);
                    break;
                }
                var Button = Instantiate(CL);
                var CCL = Button.GetComponent<CLEventController>();

                Button.transform.parent = this.transform.parent;

                var olol = Button.transform.localPosition;
                olol.y = 4f - index * 1.5f;
                Button.transform.localPosition = olol;

                CCL.Show(() =>
                {
                    i.Value?.Invoke();

                    this.transform.parent.gameObject.BroadcastMessage("DestroyWithoutEvent");
                }, i.Key);


                index++;
            }
        }

        return StartCoroutine(Av());
    }

    public Coroutine RuningSript = null;
    public void StartScript1()
    {
        if (RuningSript != null) StopCoroutine(RuningSript);
        IEnumerator Script()
        {
            yield return CCLR.ShowConversation("先来认识一下C语言的基本结构。", null, null);
        }

        RuningSript = StartCoroutine(Script());
    }
}
