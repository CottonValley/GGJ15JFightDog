using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioController  {
	private static AudioController _instance = null;
	public static AudioController instance {
		get {
			if(_instance == null) _instance = new AudioController();
			return _instance;
		}
	}

	GameObject seObj;
	GameObject bgmObj;
	AudioSource seSource;
	AudioSource bgmSource;
	
	Dictionary<string, AudioClipInfo> audioClips = new Dictionary<string, AudioClipInfo>();
	
	// AudioClip information
	class AudioClipInfo {
		public string resourceName;
		public string name;
		public AudioClip clip;
		
		public AudioClipInfo( string resourceName, string name ) {
			this.resourceName = resourceName;
			this.name = name;
		}
	}

	private AudioController(){
		audioClips.Add( "SEcat", new AudioClipInfo( "cat", "SEcat" ) );
		audioClips.Add( "SEcrow", new AudioClipInfo( "crow", "SEcrow" ) );
		audioClips.Add( "SEdog", new AudioClipInfo( "dog", "SEdog" ) );
		audioClips.Add( "SEwalk", new AudioClipInfo( "walk", "SEwalk" ) );
		audioClips.Add( "SEshock", new AudioClipInfo( "shock2", "SEshock" ) );
		audioClips.Add( "bgm001", new AudioClipInfo( "game01", "bgm001" ) );
		audioClips.Add( "bgm002", new AudioClipInfo( "bgm_catche", "bgm002" ) );
		audioClips.Add( "bgm003", new AudioClipInfo( "Sunrise", "bgm003" ) );
		audioClips.Add( "bgmEnd", new AudioClipInfo( "happyend", "bgmEnd" ) );
	}

	public bool PlaySE(string seName){
		if ( audioClips.ContainsKey( seName ) == false )
			return false;
		
		AudioClipInfo info = audioClips[ seName ];
		
		// Load
		if ( info.clip == null )
			info.clip = (AudioClip)Resources.Load( info.resourceName );
		
		if ( seObj == null ) {
			seObj = new GameObject( "SoundPlayer" ); 
			seSource = seObj.AddComponent<AudioSource>();
		}
		
		// Play SE
		seSource.PlayOneShot( info.clip );
		
		return true;
	}

	public bool PlayBGM(string bgmName){
		if ( audioClips.ContainsKey( bgmName ) == false )
			return false;
		
		AudioClipInfo info = audioClips[ bgmName ];
		
		// Load
		if ( info.clip == null )
			info.clip = (AudioClip)Resources.Load( info.resourceName );

		if(bgmSource!=null && !info.clip.name.Equals(bgmSource.clip.name))
			StopBGM();

		if ( bgmObj == null ) {
			bgmObj = new GameObject( "BGMPlayer" ); 
			bgmSource = bgmObj.AddComponent<AudioSource>();
		}

		bgmSource.clip = info.clip;
		// Play BGM
		bgmSource.Play();
		
		return true;
	}

	public void StopBGM(){
		if(bgmSource == null) return;

		bgmSource.Stop();
	}
}
