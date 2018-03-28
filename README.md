# Create your first game in Unity using C#
## Come make games on your employer’s dime!

By Alex Bezuska of [Two Scoop Games](http://twoscoopgames.com)





## Resources

[Free Music Archive](http://freemusicarchive.org/)
Creative Commons royalty free music

[Free Sound](https://freesound.org/)
Creative Commons royalty free sounds



### Default sounds used:

Boost.wav by MoushySound
https://freesound.org/people/MoushySound/sounds/420998/

Drive Fast by Three Chain Links
http://freemusicarchive.org/music/Three_Chain_Links/




## Instructions

### Unity Basics
  - The layout of the app
### Creating a player
  - add a new cube gameobject and name it `Player`
### Make your player move
  - Add a new script called `Move` to Player

```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public float moveSpeed = 10f;

	void Update () {
		var moveX = moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
		var moveY = 0f;
		var moveZ = 0f;
		transform.Translate(moveX, moveY, moveZ);
	}
}
```

### Make the camera follow player
  - set camera position to 0,0,-15
  - set camera rotation to 10,0,0
  - add new script called `Follow` to camera
    - explain that `lateUpdate` happens every frame after all `Update` functions so the player moves then the camera moves after

```
using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {

	public Transform target;
	public float height = 10;

	void LateUpdate () {
		transform.position = new Vector3(target.position.x,target.position.y + height,transform.position.z);
	}
}
```
### Apply physics to player
### Add a platform
### Make the player jump

  - add a script to the player called `Jump`

```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

	public float jumpVelocity;
	Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void Update () {
		var jumpButtonPushed = Input.GetButton ("Jump") || Input.GetMouseButton(0) || Input.touchCount > 0;

		if (jumpButtonPushed) {
			rb.velocity = Vector3.up * jumpVelocity;
		}
	}

}
```
### Add a jump sound

  - add to jump script
```
...
public AudioClip[] jumpSounds;
...
if (jumpButtonPushed && grounded) {
    ...
		SoundManager.Instance.Play (jumpSounds);
	}
```
### Prevent double jumping
  - add a new tag called Ground, add this tag to the platform
  - add this to the `Jump` script

```
public bool grounded = true;
```

in the if(jumpButtonPushed)
```
	grounded = false;
```

```
void OnCollisionEnter(Collision other) {
  if (other.gameObject.tag == "Ground"){
    grounded = true;
  }
}
```
### Reset scene on fall
  - add a new script `RestartOnFall` to player
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartOnFall : MonoBehaviour {

	public float resetZone = -50;

	void Update(){
		if (transform.position.y < resetZone) {
			Application.LoadLevel(Application.loadedLevel);
		}
	}
}
```
### Make player move on it’s own
  - Make change to Move script
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public float moveSpeed = 10f;

	void Update () {
		var moveX = moveSpeed * Time.deltaTime;
		var moveY = 0f;
		var moveZ = 0f;
		transform.Translate(moveX, moveY, moveZ);
	}
}
```
### Add some models

  - add model to the Player
  - talk about how prefabs work

### Procedurally generate platforms
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject platform;
	public Transform generationPoint;
	public float distanceBetween;
	private float platformWidth;

	void Update () {

		var yPosition = Random.Range (transform.position.y - 0, transform.position.y  + 0);
		if (transform.position.x < generationPoint.position.x) {
			transform.position = new Vector3 (transform.position.x + 10 + distanceBetween, yPosition);

			Instantiate (platform, transform.position, transform.rotation);
		}
	}
}

```

### Randomize height and distance of platforms

```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject[] platforms;
	public Transform generationPoint;

	public float heightVariance;

	public float distanceBetweenMin;
	public float distanceBetweenMax;

	private float platformWidth;


	void Update () {
		var index = Random.Range (0, platforms.Length);
		var platformPick = platforms[index];

		var distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);
		var yPosition = Random.Range (transform.position.y - heightVariance, transform.position.y  + heightVariance);
		if (transform.position.x < generationPoint.position.x) {
			transform.position = new Vector3 (transform.position.x + 10 + distanceBetween, yPosition);

			Instantiate (platformPick, transform.position, transform.rotation);
		}
	}
}

```

### Keeping score
  - Explain how Unity UI works
  - Create Score Text object in ui canvas
  - Score script on player:
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public int score = 0;
	public Text scoreText;

	public void AddPoints () {
		score++;
		scoreText.text = score.ToString();
	}

}
```
  - drag `Score Text` into score script on player

### Add a start button
  - add a ui button and setup the position and size
  - change the text to `Start`
  - talk about Unity On Click() events
  - add On Click() for Player object that enables the Move script
  - add On Click() event for start button itself to GameObject.SetActive false
### Add particle trail


### Add music
