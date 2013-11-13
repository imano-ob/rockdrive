/*Beat Generation
 * creates the "beat" values for the level generator, for one "room"
 */

using UnityEngine;
using System.Collections;

public class BeatGeneration : MonoBehaviour {
	public int lenght;//number of beats
	public float speed;//minimum interval between 2 beats
	public Beat[] beat= new Beat[102];// resultant beat
	
	//public string[,] verbs={{"run","stop"},{"shortJump","longJump"},{"weakEnemy","strongEnemy"}};
	string[] moveVerbs={"Run","Run"};
	string[] jumpVerbs={"ShortJump","LongJump"};
	string[] fightVerbs={"WeakEnemy","StrongEnemy"};
	string[] currentVerbs;
	float[,] verbTime= {{3f,3f},{3f,3f},{3f,3f}};//{{5,1f},{0.5f,1.5f},{2f,5f}};
	float[] lastActionEnd={0,0,0};
	
	[ContextMenu ("Generate Test Beat")]
	void BeatGenerate(int Lenght,float Speed){
		
		
		lenght=Lenght;
		speed=Speed;
		
		float currentTime=5f;
		beat[0]=new Beat("Run",0f,5f);
		int currentVerbLevel=0;
		lastActionEnd[0]=5;
		
		for(int i=1;i<lenght;i++){
			//chuta um nivel aleatorio de açao
			int randomVal= Random.Range(currentVerbLevel,3);
			if(currentVerbLevel==0) randomVal=0;
			Debug.Log("Nivel da proxima acao: "+randomVal);
			
			//Ajeita o ponteiro
			if(randomVal==0) currentVerbs= moveVerbs;
			if(randomVal==1) currentVerbs= jumpVerbs;
			if(randomVal==2) currentVerbs= fightVerbs;
			
			//Selects the action and defines data
			int nextRandomVal= Random.Range(0,currentVerbs.Length);
			Debug.Log("	Proxima acao: "+nextRandomVal+"= "+currentVerbs[nextRandomVal]);
			beat[i]= new Beat(currentVerbs[nextRandomVal],currentTime,currentTime+verbTime[currentVerbLevel,nextRandomVal]);
			lastActionEnd[currentVerbLevel]=currentTime+verbTime[currentVerbLevel,nextRandomVal];
			
			//Increments time
			currentTime=currentTime+speed;
			currentVerbLevel=0;
			if(currentTime<lastActionEnd[0])currentVerbLevel=1;
			if(currentTime<lastActionEnd[1])currentVerbLevel=2;
		}
		
		//Flatten();
		
		for(int i=0;i<lenght;i++){
			if(beat[i].verb=="Run"||beat[i].verb=="Stop")
				Debug.Log("ACAO-"+beat[i].verb+" DE "+beat[i].startTime+" A "+beat[i].endTime);
			else if(beat[i].verb=="ShortJump"||beat[i].verb=="LongJump")
				Debug.Log("---->ACAO-"+beat[i].verb+" DE "+beat[i].startTime+" A "+beat[i].endTime);
			else if(beat[i].verb=="WeakEnemy"||beat[i].verb=="StrongEnemy")
				Debug.Log("-------->ACAO-"+beat[i].verb+" DE "+beat[i].startTime+" A "+beat[i].endTime);
			else
				Debug.Log("ACAO-"+beat[i].verb+" DE "+beat[i].startTime+" A "+beat[i].endTime);
		}
		
		//TODO- separar isso do resto 
		for(int i=0;i<lenght;i++){
			GameObject newRoom;
			string partName;
			if(beat[i].verb=="Run") partName= "Block";
			else partName= beat[i].verb;
			Vector3 roomPosition = new Vector3(beat[i].startTime,0,0);
			Quaternion roomRotation= Quaternion.identity;
			newRoom= Instantiate(Resources.Load("LevelPieces/"+partName),roomPosition,roomRotation) as GameObject;
		}
		
	}
	
	void Start(){
		BeatGenerate(lenght,speed);	
	}
	
	void Flatten(){
		for(int i=0;i<lenght;i++){
			for(int j=i;j<lenght;j++){
				if(beat[j].endTime<beat[i].endTime)
					beat[j].verb=beat[i].verb+beat[j].verb;
			}
		}
	}
	
}
