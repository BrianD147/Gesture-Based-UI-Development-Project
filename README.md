# Gesture Based UI Development Project

Developed by: Ryan Conway and Brian Doyle <br/>
Hardware used: Myo Armband

### Project Requirements

Develop an application with a Natural User Interface. There are a number of options available to you and this is an opportunity to combine a lot of technology that you have worked with over the past four years.
<br/>

At the very least, this should be a local implementation of the application using gestures to interact with it.  For example, a voice controlled application fits the parameters of gesture basedcontrol. You can expand out to include real-world hardware and use this as an opportunity to prove a concept.  The Internet of Things is a common phrase, so you could implement a solution taking advantage of hardware like the Raspberry Pi, using the cloudfor data transfer and creating a real-world scenario through this medium.  
<br/>
You can reproducea classic game or system using a gesture-based interface.  For example, a platformer game or a navigation application using Kinect or voice control.  Maybe Tetris using the Myo armbands to control the blocks, or Flappy Bird using the Kinect as the controller.  Applications with multiple users are also acceptable.
<br/>

Voice control applications need to be more complex and achieve something.  Creating a skill in Alexa for the sake of creating a skill is not enough.  You need to take the application further than this.  You could, for example, implement a simple learning mechanism that will build a conversational skill as time progresses and demonstrate this.  You could use the voice control to progress through a game or achieve a task.  If you are doing this, then you need to distinguish the code you write from the samples available.

### What we decided on

With these requirements we decided on making a shooting gallery style game in unity. The hardware we decided upon was the Myo armband, as we thought it would best suit our style of game.

The game used the Gyroscope on the Myo to control the camera movement in a first person perspective. Using the Myo's gestures, we could navigate through the menus and also use them for in game functions such as shooting the gun and pausing the game.


### How to play

The Main objective of the game is to shoot all of the bottles in each level. The user moves their arm to move the camera in the scene from a first person perspective. Once the crosshairs are in line with a bottle, perform a fist gesture to shoot the bottle. If the crosshairs are directly inline with the bottle the bottle should be destroyed. Once all the bottles have been shot the player moves onto the next level.

### Scenes / Gestures

#### Main Menu
The Main Menu consists of 3 buttons, each controlled by a unique gesture to that scene.
<br/>
The Play button is triggered by the "Wave In" gesture. This navigates the user to the first level of the game.

The Controls button is triggered by the "Wave Out" gesture. This navigates the user to the Controls scene.

The Quit button is triggered by the "Spread Hand" gesture. This exits the application.

#### Controls
The controls menu displays the game controls and each gesture used in the game scene to use these controls. It also contains one gesture controlled button to navigate away from the scene.
<br/>
The Back button is triggered by the "Wave Out" gesture. This exits the controls scene and navigates to either the main menu or level pause, depending on how the user nevigated to the options menu.

#### Levels 1-3
The level scenes are where the game is played. Camera is in first person perspective and is controlled by the gyroscope on the Myo armband. 
<br/>
To shoot the gun the user must use the "Fist" gesture. This sends out a Raycast to whatever object the crosshairs are pointing at. The objective is to shoot the bottles so when you shoot the bottles, the raycast is sent out and they are destroyed.

To Pause the game, the user uses the "Wave Out" gesture. This pauses the current scene and opens up more options for the user to navigate to.

Each level has a set number of bottles. Three in the first, Four in the second and Five in the third. Once all the bottles in the scene are destroyed, the user is navigated to the next. Once the final level is complete, the user is brought to the win scene and the game is completed.

#### Pause Menu
The Pause menu itself is not a new scene, but an overlay in each level. When the pause menu is triggered the gameplay is paused and a new pool of gestures are available.
<br/>
To resume the game, the user uses the "Wave In" gesture. This hides the pause menu and resumes the game from where it left off.

The Controls button is triggered by the "Spread Hand" gesture. This navigates the user to the controls menu.

The Quit button is triggered by the "Fist" gesture. This navigates the user back to the main menu.

### Video Example
Below is a video of these gestures in action. This was a requirement for submission.
[The video can be viewed here](https://www.youtube.com/watch?v=4J3vp3vl2dk "Gesture Based UI Video Example")
