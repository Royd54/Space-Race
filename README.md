# Space Race
This is one of my own projects, that I have made in my spare time. The game is about a ship that vanished from radars. You, as the player stumbled upon the ship, and want to find clues about the event that took place on the ship. The goal of the game is to find out what happened on the ship, that led to its disappearing. You are able to accomplish this goal, by finding all the keycards and opening the doors to new parts of the maps. While searching for the cards in the dark, the player does not need to fear about getting lost. The player does not need to fear getting lost, because the trusty AI (Henry) will help the player get trough the map, with it's excellent directions/hints. Lastly, the game is also foccused on making the player feel like a badass, while shooting enemies.


As you would expect, a good portion is made by myself. The only things that I did not make is the art. I tried to make everything as loosely coppled as I could, to increase readability/reusability. And at last, I rewrote/expanded on the excisting XR library.

## Educational goals
The things that I wanted to learn from this project are:
- I wanted to learn the functionalities of the Unity XR library
- I wanted to learn in's and outs of making a complete game

## Scripts 
The scripts listed below are some scripts that I wanted to clarify, these scripts are also the most interesting in my opinion.

### MovementProvider
[MovementProvider](https://github.com/Royd54/Space-Race/blob/master/Space%20Race/Assets/Player/Scripts/Movement/MovementProvider.cs)
The script first assigns the correct height to the player, relative to the head's height.
After setting up the height it waits for input from a controller.
When input gets detected, the script makes the characterController move, realative to the speed and direction.

### VR-Rig
[VR-Rig](https://github.com/Royd54/Space-Race/blob/master/Space%20Race/Assets/Player/Scripts/Rig/VRRig.cs)
This script handles the VR character rig (visual arms and body).
The script works via calculating the rotation and position based on the target and offset values of the body-parts.
The script also handles the pitch/rotation of the head.

### Pistol
[Weapon](https://github.com/Royd54/Space-Race/blob/master/Space%20Race/Assets/Player/Scripts/Weapons/Weapon.cs), 
[Pistol](https://github.com/Royd54/Space-Race/blob/master/Space%20Race/Assets/Player/Scripts/Weapons/Pistol.cs)
This system works from a main class where weapons are made from (Weapon.cs).
The basic variables and functions for guns are created in the main class.
Every created gun will inherit from this main class.
Then in the Pistol.cs class for example, the sound/other fx will be activated.
And lastly the projectiles will get instantiated/launched here.

### Backpack
[BackpackSlot](https://github.com/Royd54/Space-Race/blob/master/Space%20Race/Assets/Player/Scripts/Backpack/BackpackSlot.cs), 
[Holster](https://github.com/Royd54/Space-Race/blob/master/Space%20Race/Assets/Player/Scripts/Backpack/Holster.cs), 
[FollowPlayer](https://github.com/Royd54/Space-Race/blob/master/Space%20Race/Assets/Player/Scripts/Backpack/FollowPlayer.cs)
The backpack works as a slot system. To put things in the backpack, you can simply drop an item into a visible slot.
Not everything can fit in the slots (only small items). Other items like guns and stuff can fit in the Holsters next to the player. These holsters work the same way as the backpackslots. The holsters rotate with the player, relative to the head's rotation. The holster script calculates the difference between the head en the transform. After calculating it sets the speed at wich the holster needs to rotate. The speed gets devided or boosted based on the difference gap from the calculation.
The player is also able to put on hats, or put the backpack on their back. This works with a socket that follows the player.

### Dialogue system
[Dialogue](https://github.com/Royd54/Space-Race/blob/master/Space%20Race/Assets/DailogueWithAudio/Scripts/Dialogue.cs), 
[DialogueManager(https://github.com/Royd54/SpaceRace/blob/master/Space%20Race/Assets/DailogueWithAudio/Scripts/DialogueManager.cs), 
[DialogueTrigger](https://github.com/Royd54/Space-Race/blob/master/Space%20Race/Assets/DailogueWithAudio/Scripts/DialogueTrigger.cs)
The dialogue class has 2 simple arrays, that contain sentences and audioclips for these sentences.
The dialoguemanager then works with these values. When a dialogue gets triggered the dialoguetrigger class starts the dialogue, and shuts down the collider/trigger. After this, the dialoguemanager start typing the sentence on a canvas letter for letter. While typing it also plays the first audioclip in the que. When the sentence and the audioclip are done, the next sentence and auioclip get played. If there is none of these left, the canvas will dissapear.

### GameEvents
[GameEvents](https://github.com/Royd54/Space-Race/blob/master/Space%20Race/Assets/AI/Scripts/GameEvents.cs)
This class is a class that works with events/actions. This way everything stays loose, and easy to reuse.
You can say that this class is a serving hatch for the functions. 

### TakeCoverAI
[TakeCoverAI](https://github.com/Royd54/Space-Race/blob/master/Space%20Race/Assets/AI/Scripts/TakeCoverAI.cs)
This is the script for the enemy AI in the game. This AI needs a navmesh to navigate itself. So if the navmesh/navmesh-agent is active/enabeled it starts checking the distance between the player en itself. If the distance to the player is too low, it starts to fall back. The AI can also fall back to a different coverspot if needed. If the player is not to close to the AI, it starts checking for cover. If there is any cover in range it runs towards cover and faces towards the player. The AI finds cover with a OverlapSphere. It then adds all the colliders, that are in the sphere and are on the coverlayer to an array. It then loops trough the array and checks wich spot is the closest. This spot gets assigned to a variable, and gets used by the TakeCover function. This fucntion makes the AI get into cover. After getting into cover the AI starts shooting at the player if they are in sight of the AI. The AI can also take damage and if it's health gets to 0 or below 0, it turns into a ragdoll.

### AudioManager
[AudioManager](https://github.com/Royd54/Space-Race/blob/master/Space%20Race/Assets/Player/Scripts/Sound/AudioManager.cs)
This script is for playing all kinds of audio. This script ties into the timescale of the engine. So if the engine goes in slomo, the music/sounds do aswell. Furthermore this script handles the audio in the game and is loosely made. You can simply use the instance of the script and call the functions.

## Sources
The sources that I used for this project are:
I used the backpack mechanic from the game The Walking Dead: Saints & Sinners as reference.
- [XR library documentation](https://docs.unity3d.com/Manual/XR.html)
- [The Walking Dead: Saints & Sinners](https://www.youtube.com/watch?v=PwQx872oy4A&t=35s)

