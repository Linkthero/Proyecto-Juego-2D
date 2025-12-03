using UnityEngine;

public class Fade : MonoBehaviour
{

    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void FadeOut()
    {
        animator.Play("FadeOut");
    }

}
