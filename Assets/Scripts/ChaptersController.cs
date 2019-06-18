using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChaptersController : MonoBehaviour {

    public RectTransform TotalRT;
    public AudioClip[] audioClips = new AudioClip[5];

    private enum State {
        s,
        k,
        m,
        n,
        l
    }

    private bool moveDone = true;
    private AudioSource audioSource;
    private State state = State.s;
    private bool recordedMoveDone = true;

	// Use this for initialization
	void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (moveDone && !recordedMoveDone) {
            recordedMoveDone = true;
            if (state == State.s) {
                audioSource.clip = audioClips[0];
                audioSource.Play();
            }
            else if (state == State.k) {
                audioSource.clip = audioClips[1];
                audioSource.Play();
            }
            else if (state == State.m) {
                audioSource.clip = audioClips[2];
                audioSource.Play();
            }
            else if (state == State.n) {
                audioSource.clip = audioClips[3];
                audioSource.Play();
            }
            else if (state == State.l) {
                audioSource.clip = audioClips[4];
                audioSource.Play();
            }
        }
        else if (!moveDone && recordedMoveDone) {
            recordedMoveDone = false;
            audioSource.Stop();
        }

	}

    public void StoK() {
        moveDone = false;
        state = State.k;
        StartCoroutine(Move(TotalRT.localPosition.x, -800));
    }

    public void KtoS() {
        moveDone = false;
        state = State.s;
        StartCoroutine(Move(TotalRT.localPosition.x, 0));
    }

    public void KtoM() {
        moveDone = false;
        state = State.m;
        StartCoroutine(Move(TotalRT.localPosition.x, -1600));
    }

    public void MtoK() {
        moveDone = false;
        state = State.k;
        StartCoroutine(Move(TotalRT.localPosition.x, -800));
    }

    public void MtoN() {
        moveDone = false;
        state = State.n;
        StartCoroutine(Move(TotalRT.localPosition.x, -2400));
    }

    public void NtoM() {
        moveDone = false;
        state = State.m;
        StartCoroutine(Move(TotalRT.localPosition.x, -1600));
    }

    public void NtoL() {
        moveDone = false;
        state = State.l;
        StartCoroutine(Move(TotalRT.localPosition.x, -3200));
    }

    public void LtoN() {
        moveDone = false;
        state = State.n;
        StartCoroutine(Move(TotalRT.localPosition.x, -2400));
    }

    IEnumerator Move(float startX, float aimX) {
        
        if (startX > aimX) {
            for (float i = startX; i >= aimX; i -= 20) {
                TotalRT.localPosition = new Vector2(i, TotalRT.localPosition.y);
                yield return null;
            }
        }
        else {
            for (float i = startX; i <= aimX; i += 20) {
                TotalRT.localPosition = new Vector2(i, TotalRT.localPosition.y);
                yield return null;
            }
        }
        moveDone = true;
    }
}
