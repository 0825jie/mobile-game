using UnityEngine;
using System.Collections;


public enum HouseTypesEnum
{
	BigHouse, MedHouse, SmallHouse
}

public class GameManager : MonoBehaviour {
	

	public Vector3 LastDoor;

	public Quaternion PlayerRotation;
	
	//houses
	public Transform BigHouseSpawn;
	public Transform MedHouseSpawn;
	public Transform SmallHouseSpawn;
	public HouseTypesEnum HouseTypeTarget;

	//exterior 
	public Transform TempleSpawn;
	public Transform PyramidSpawn;



		
	//public AudioClip TempleMusic; // licensed music
	//public AudioClip MainMusic;


	// Use this for initialization
	void Start () {

		DontDestroyOnLoad(transform.gameObject);

		Application.LoadLevel(1);

	
	}

	// 1 = exterior 2 = house 3 = pyramide 4 = temple

	// Update is called once per frame
	public void OnLevelWasLoaded(int level){

		if(level == 1){

			GameObject.Find("_First Person Controller").transform.rotation = PlayerRotation;
			GameObject.Find("_First Person Controller").transform.position = LastDoor;

		

			this.GetComponent<AudioSource>().volume = 0.7f;

			/*if(this.audio.clip != MainMusic){
				this.audio.clip = MainMusic;
				this.audio.Play ();
			}*/


		}

		if(level == 2){

			this.GetComponent<AudioSource>().volume = 0.3f;
			if(this.HouseTypeTarget == HouseTypesEnum.BigHouse)
				GameObject.Find("_First Person Controller").transform.position = BigHouseSpawn.position;
			else if(this.HouseTypeTarget == HouseTypesEnum.MedHouse)
				GameObject.Find("_First Person Controller").transform.position = MedHouseSpawn.position;
			else if(this.HouseTypeTarget == HouseTypesEnum.SmallHouse)
				GameObject.Find("_First Person Controller").transform.position = SmallHouseSpawn.position;

		}

		if(level == 3){

			/*this.audio.clip = TempleMusic;
			this.audio.volume = 0.6f;
			this.audio.Play();*/

		}

		if(level == 4){

			/*this.audio.clip = TempleMusic;
			this.audio.volume = 0.6f;
			this.audio.Play();*/

		}
	}

}
