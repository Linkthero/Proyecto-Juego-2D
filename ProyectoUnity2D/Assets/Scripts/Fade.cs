using UnityEngine;

public class Fade : MonoBehaviour
{

    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(AudioManager.instance.FadeIn(1f));
    }

    public void FadeOut()
    {
        animator.Play("FadeOut");
        StartCoroutine(AudioManager.instance.FadeOut(1f));
    }

}
