using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAnimation : MonoBehaviour
{

    public enum AnimationState {
        // WalkDown,
        // WalkUp,
        WalkSide, 
        Idle
    }

    public float animationFPS;
    // public Sprite[] downAnim;
    // public Sprite[] upAnim;
    public Sprite[] sideAnim;
    public Sprite[] idleAnim;

    private Rigidbody2D rb2d;
    // private PlayerController controller;
    private SpriteRenderer sr;

    private float frameTimer = 0;
    private int frameIndex = 0;
    private AnimationState state = AnimationState.Idle;
    private Dictionary<AnimationState, Sprite[]> animationAtlas;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animationAtlas = new Dictionary<AnimationState, Sprite[]>();
        // animationAtlas.Add(AnimationState.WalkDown, downAnim);
        // animationAtlas.Add(AnimationState.WalkUp, upAnim);
        animationAtlas.Add(AnimationState.WalkSide, sideAnim);
        animationAtlas.Add(AnimationState.Idle, idleAnim);

        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        // controller = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimationState newState = GetAnimationState();
        if (state != newState) {
            TransitionToState(newState);
        }

        frameTimer -= Time.deltaTime;
        if (frameTimer <= 0.0f) {
            frameTimer = 1 / animationFPS;
            Sprite[] anim = animationAtlas[state];
            frameIndex %= anim.Length;
            sr.sprite = anim[frameIndex];
            frameIndex++;
        }

        if (rb2d.linearVelocity.x < -0.01f) {
            sr.flipX = true;
        }

        if (rb2d.linearVelocity.x > 0.01f) {
            sr.flipX = false;
        }
    }


    void TransitionToState(AnimationState newState) {
        frameTimer = 0.0f;
        frameIndex = 0;
        state = newState;
    }

    AnimationState GetAnimationState() {
        Vector3 velocity = rb2d.linearVelocity;

        if (velocity.y > 0.1f) {
            return AnimationState.WalkSide;;
        } else if (velocity.y < -0.1f) {
            return AnimationState.WalkSide;;
        }
        if (Mathf.Abs(velocity.x) > 0.1f) {
            return AnimationState.WalkSide;
        }
        return AnimationState.Idle;
    }
}
