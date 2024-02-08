# Aerobatics-Game
Arcade airplane game implemented in Unity.
![Environment](https://github.com/Viktr0/Aerobatics-Game/assets/47856193/da2cde50-0a66-4809-8ca5-9662956ca4d5)


## The game
The game takes place in a spectecular minimalist environment, where the goal is to complete the track as fast as possible. For successfully completing it, the users have to reach all of the checkpoints in the correct order by controlling the plane with the A,W,S,D,Q,E keys.

<p align="center">
  <img src="https://github.com/Viktr0/Aerobatics-Game/assets/47856193/1b5a33b9-d21c-417a-be05-960372d87f83" alt="animated" />
</p>

In the future more tracks with different levels of difficulty will be added to the game. The project is capable to have different airplane models with unique properties, so the users can choose the plane that matches their preferences.
These extensions are not added yet.

## Game environment
The environment is created by procedural landmass generation. This random noise generated infinty terrain is colored by its height values.
Map             |  Regions
:-------------------------:|:-------------------------:
![Terrain_1](https://github.com/Viktr0/Aerobatics-Game/assets/47856193/851eca1f-61b1-41cf-849e-65c2f5676c6b)  |  ![Regions](https://github.com/Viktr0/Aerobatics-Game/assets/47856193/b3e04962-3cfa-46c3-a8fe-b905c2a5075c)


## Game models
Every model object used in the game are created in AUTODESK 3ds Max. The models were imported to Unity.

### Airplane
The Airplane is built up of different components. Some of them are responsible for the movements of the plane, which are
* Propeller: the propeller is like a spinning wing, that makes lift in a forward direction.
* Elevator: the elevator is a primary flight control surface that controls movement about the lateral axis of an aircraft.
* Rudder: the rudder is a vertical fin that is attached to the vertical stabilizer. It helps maintain directional control known as “yaw”.

To make the game more realistic, these components are actively involved to the movements.
<p align="center">
  <img width="70%" src="https://github.com/Viktr0/Aerobatics-Game/assets/47856193/c5a674d7-2a52-45fa-b5c1-bcc3de38a6fe"/>
</p>


Another advantage of the fact that the airplane is built from several pieces is that it can fall apart when the plane crashes making it more dynamic.

### Checkpoint
The track consists of checkpoints. These checkpoints are large rings, which yellow and purple colors allow it to stand out from its surroundings. The players do not have to keep in mind which one is the next, because they are always highlighted.
<p align="center">
  <img width="70%" src="https://github.com/Viktr0/Aerobatics-Game/assets/47856193/957c9ece-8d1b-4b69-9cfd-91c11ea420e7"/>
</p>

### Arrow
It is very easy for the player to get lost, but there is no need to despair, because the semi-transparent, arrow shaped object on the top of the window always shows you the direction to the next ring.
<p align="center">
  <img width="70%" src="https://github.com/Viktr0/Aerobatics-Game/assets/47856193/b146f052-a371-4655-b28a-7a45985fb9f7"/>
</p>
