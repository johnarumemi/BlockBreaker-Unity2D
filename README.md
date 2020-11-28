# Block Breaker
- 2D Unity game

## Table Of Contents
+ [Assets](#assets)
+ 
## Assets
+ [Paddle](#paddle)
+ [Ball](#ball)
+ [Block](#block)
+ [Level](#level)
+ [GameSession](#gamesession)

### Paddle
__Scripts__: Script.cs

__Description__

Paddle controlled by Players Mouse

__Features__

+ Mouse Position converted to Unity World Units and clamped to within range of Camera Width

### Ball
__Scripts__: Ball.cs

__Description__

Ball Game Object / Prefab.

__Features__

- Clamped to initial displacement from Paddle at start of game until Ball is launched.
- Launched via applying velocity to RigidBody2D __component__ 
```
GetComponent<RigidBody2D>.velocity = new Vector2D(...)
```

- to stop the ball slowing down when it connects to inclined edges (paddle collider), set the friction to 0 on
the "Bounce" Material to 0.
`Collider-Material-Bounce[friction=0]`
- Audio Source __component__ has no Audio Clip reference to it, rather the Ball.cs has a SerializedField called `AudioClip[] ballSounds;`
which enables us to pass in an array of Audio Clips. A Random Clip is selected from this array and passed into
the `audioSource.PlayOneShot(randomAudioClip)` using `UnityEngine.Random.Range(start, endExclusive)`.
Audio is only played if Ball has been launched and it has collided with a game object that is __NOT__ a _Lose Collider_.

### Block
__Scripts__: Block.cs

- Destroyed when Ball hits it.

__Description__

Blocks that are hit by the Ball

__Features__

+ When block is destroyed via `Destroy(gameObject)` audio of it breaking will be cutt off.
    - Solved via using [`AudioSource().PlayClipAtPoint(AudioClip, Position)`][1], where Position that was used is
    at the location of the the Audio Listener (Game Camera).
 
+ holds references to GameSession and hence calls `gameSession.AddToScore()` when Block is destroyed.
+ holds reference to Level and calls `level.DestroyBreakableBlock()` when Block is destroyed.

### Level
__Scripts__: Level.cs

__Description__

This holds information for this specific level such as,

+ Total number of _breakable_ blocks
+ criteria for winning this level

Once level is complete, its activates moving to the next scene.

__Features__

+ Tracks total number of Blocks within the Scene via public method called externally.
+ Tracks blocks being destroyed.
+ loads next scene (using SceneLoader gameObject) when win condition is met, i.e. No. Blocks = 0.

### GameSession
__Scripts__: GameSession

__Description__

Overall Game State

_Singleton_, that holds overall game state

__Features__
+ gameSpeed is tracked using `Time.timeScale = gameSpeed: float`.
+ limit range of gameSpeed in inspected via `[Range(min, max)] [SerializedField]`
+ Stores how many points you get when a block is destroyed.
+ Singleton implemented via using `FindObjectsOfType<GameSession>.Length` and if there is more than 1 object
then the gameObject Destroys itself. This is executed in the [__Awake__][2] lifecycle method. __Singleton__ is 
used to create a persistent gameObject between Scenes.

Use of below call within __GameSession.cs__ 

```
DontDestroyOnLoad(gameObject);
```


## Audio
+ Use .ogg files for good quality
- Audio Listener __component__ added to "Game Camera".
- Audio Source __component__ added to "Ball" prefab.

[1]: https://docs.unity3d.com/ScriptReference/AudioSource.PlayClipAtPoint.html "AudioSource().PlayClipAtPoint()"
[2]: https://docs.unity3d.com/Manual/ExecutionOrder.html "Script lifecycle"