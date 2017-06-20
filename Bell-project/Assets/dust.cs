using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dust : MonoBehaviour {
	private ParticleSystem[] m_particleSystem;
	private Rigidbody m_rigd;
	// Use this for initialization
	void Start () {
		
	}
	private void Awake()
	{
		m_rigd = GetComponent<Rigidbody> ();
	}



	private void onEnable(){


		m_rigd.isKinematic=false;
		m_particleSystem=GetComponentsInChildren<ParticleSystem>();
		for (int i = 0; i < m_particleSystem.Length; i++) {
		
			m_particleSystem [i].Play ();
		}

	}









	// Update is called once per frame
	void Update () {
		
	}
}
