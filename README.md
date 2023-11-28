# Magicorse a Miniproject
Magicka but WORSE


Date: 29/11-2023  
By Rikke Bragh Jensen

![image](https://github.com/Bragh2001/Programmering3Dverdener/assets/112693932/65862f1e-25ab-4d8f-87c4-701bf8c3298a)


## Overview of the game  
In Magicorse a wizard fights against a goblin. They walk around in a little village area and attack each other. The player is the wizard, who casts the different elements of water, life, cold, lightning, arcane, earth and fire onto the goblin, and the enemy goblin fights back with a bow and arrows. The game is an action-adventure.
### The game’s elements:
- Player - Moves by holding the left mouse button down, can attack with different elements by either pressing Q, W, R, A, S, D or F. 
- Enemy - Follows the player if they are in sight and attacks with bow and arrow if they are in range.
- Environment - A plane with houses, trees and flowers, where the player and enemy can move around in. They can only move on the NavMesh Surface.
- Camera - Follows the player from a set position using Cinemachine Virtual camera.
- Healthbar - Shows the health of the player and enemy in a slider under them as UI in world space.

## How to run it
Download Unity with 2021.3.8f1.  
Download or clone the project.  
Mouse and keyboard are need to play the game.  

## Used parts of the course
For the player to move around and the weapons to fire in the right direction, raycasting was used to find the hit point of the mouse on the plane in the game by casting a ray between the two. The element water, cold and fire are sprayed out using Unity Particle Systems. For the player and enemy to take damage the prefabs which are used as weapons have rigidbodies for them to respond to colliders and have some standard physics behavior. They also have colliders so the onCollisionEnter can be used. When the different objects collide with one of the two damage is given. The player and enemy are NavMesh Agents which gives them the option to move around on the NavMesh Surface placed on the Plane. The NavMesh Surface determines, when baked, what the agents can move on. The primitive capsules from Unity used as player and enemy have materials with different colors to differentiate the two from each other. 


## All Project Elements
### Scripts
#### Billboard:  
This script is placed on the healthbar for it to look at the camera. Followed from this tutorial: https://www.youtube.com/watch?v=BLfNP4Sc_iA&ab_channel=Brackeys
#### DestroyProjectileAndDamage:  
It destroys the objects, which the script is placed on after 4 seconds and gives damage to the enemy and player, if they collide with the object.
#### EnemyController:  
How to attack the player if they are in range, follow the player if they are in sight and runs the damage and destroy of the enemy. This script has elements from this tutorial: https://www.youtube.com/watch?v=UjkSFoLxesw&ab_channel=Dave%2FGameDevelopment 
#### LookAtMouse:  
Is placed on three particle systems, which gets it to follow in the direction of where the mouse is.
#### PlayerController:  
This script controls how the player moves, the different attacks it can make and sets the health and damage for the player. This script has taken inspiration from this tutorial: https://www.youtube.com/watch?v=LVu3_IVCzys&ab_channel=Pogle 
### Models & Prefabs
- Medieval houses downloaded from: https://assetstore.unity.com/packages/3d/environments/historic/medieval-buildings-exteriors-72836 
- Medieval bow and arrow downloaded from: https://assetstore.unity.com/packages/3d/props/weapons/low-poly-rpg-fantasy-weapons-lite-226554 
- Low poly forest elements downloaded from: https://assetstore.unity.com/packages/3d/environments/free-low-poly-forest-nature-pack-84621 
- Stones downloaded from: https://assetstore.unity.com/packages/3d/props/exterior/stones-40329 
- Player and Enemy are Unity primitive capsules.
- Three particle systems of water, cold and fire which function as a spray.
- Visual effects, VFX Graphs with Shaders which functions as beams of lightning, arcane and life. Made by following this tutorial: https://www.youtube.com/watch?v=_SaBXY-Ejqo&ab_channel=GabrielAguiarProd.
- UI Element icons in the bottom left corner of the screen are a direct image from the game Magicka.
### Materials
The player, enemy and ground have Basic Unity materials.
### Scenes
There is only one scene in this game.
### Testing
The game has been runned on Windows and is not tested for other platforms.



## Time Management
 
| Tasks                     | Time (Hours) |
| --------------------------| ------------ |
| NAV Mesh                  | 1.5          |
| Hold to move              | 2            |
| Enemy movement and attack | 3            |
| Player attack             | 7            |
| Healthbar                 | 3            |
| Taking Damage             | 3            |
| VFX stylized beams        | 4            |
| Visual assets             | 3.5          |
| Sound                     | 2.5          |
| Rapport                   | 4.5          |
| Readme file               | 1            |
| Total                     | Approx. 33.5 |


## Used Resources
- FULL 3D ENEMY AI in 6 MINUTES! || Unity Tutorial By Dave / GameDevelopment: https://www.youtube.com/watch?v=UjkSFoLxesw&ab_channel=Dave%2FGameDevelopment   
- Click To Move | Unity RPG Tutorial #1 By Pogle: https://www.youtube.com/watch?v=LVu3_IVCzys&ab_channel=Pogle   
- How to make a HEALTH BAR in Unity! By Brackeys: https://www.youtube.com/watch?v=BLfNP4Sc_iA&ab_channel=Brackeys   
- Unity VFX Graph - Stylized Laser Beam Tutorial by Gabriel Aguiar Prod.: https://www.youtube.com/watch?v=_SaBXY-Ejqo&ab_channel=GabrielAguiarProd.   
- Medieval Buildings Exteriors By Lukas Bobor: https://assetstore.unity.com/packages/3d/environments/historic/medieval-buildings-exteriors-72836   
- Low Poly RPG Fantasy Weapons Lite By JustCreate: https://assetstore.unity.com/packages/3d/props/weapons/low-poly-rpg-fantasy-weapons-lite-226554   
- Free Low Poly Forest Nature Pack By Deadly Props: https://assetstore.unity.com/packages/3d/environments/free-low-poly-forest-nature-pack-84621   
- Stones By Pixelcloud: https://assetstore.unity.com/packages/3d/props/exterior/stones-40329  
- All sounds in the game are downloaded from https://freesound.org/   

