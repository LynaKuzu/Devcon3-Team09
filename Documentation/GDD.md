# **Skee-Ball / Curling**

# 1. Overview 

> What are you making?

This project is a hybrid between Skee-Ball and Curling, where players launch a ball by charging force and then steer it left or right while it moves. The goal is to navigate obstacles and land in a scoring hole or stop within curling-style scoring rings. Unlike traditional Skee-Ball, this prototype emphasizes continuous player engagement through mid-roll control and precision navigation.

<img width="1919" height="765" alt="Screenshot 2025-12-02 235638" src="https://github.com/user-attachments/assets/966a0bd2-47e7-4b34-ad62-821126c44c21" />



# 2. Objective Statement 

> What question are you trying to answer with your prototype? Why?

The question we are trying to answer with our prototype is: Will it will be more interesting for players to need to control their stone through a sort of obstacle course through navigating left and right, to be able to reach the house at the end?

# 3. Design Rationale 

> What do you envision? How is the game experience informed by metrics? How is it engaging beyond a simulation?

We believe that this more dynmaic and difficult level of control that the player will be presented with will lead to a more interesting and less mindless way to play a game that takes a unique spin compared to how the game is played. 

# 4. Metric Research and References

> What real-world information are you leveraging to inform objects scale, weight, friction, etc?

- Curling Stone: a weight between 17.24 and 19.96 kilograms (38 and 44 lb), a maximum circumference of 914 millimetres (36 in), and a minimum height of 114 millimetres (4+1⁄2 in).

- Curling Sheet: 146 to 150 feet (45 to 46 m) in length by 14.5 to 16.5 feet (4.4 to 5.0 m) in width.
	- House: A target, the house, is centred on the intersection of the centre line, drawn lengthwise down the centre of the sheet and the tee line, drawn 16 feet (4.9 m) from, and parallel to, the backboard. These lines divide the house into quarters. The house consists of a centre circle (the button) and three concentric rings, of diameters 4, 8, and 12 feet

# 5. Gameplay Elements
* Charge shot strength
* Release stone
* Steer during movement (left/right)
* Avoid obstacles
* Reach scoring area
* Score based on where the ball stops or lands

# 6. Core Loop
1. Player charges up force
2. Player releases the stone
3. Player navigates left/right while avoiding obstacles during travel
4. Player attempts to hit optimal scoring zone
5. Points awarded based on accuracy
6. Repeat for next round

# 7. Front End
* Power meter (charge indication)
<img width="107" height="328" alt="Screenshot 2025-12-02 235538" src="https://github.com/user-attachments/assets/78efb2be-b0c5-4886-b220-5a3354c6b4eb" />

* Score UI 
<img width="239" height="71" alt="Screenshot 2025-12-03 000511" src="https://github.com/user-attachments/assets/7392062a-fae9-4098-ae46-805a356542b6" />

# 8. Playtest 
## Feedback
* The camera spinning with the stone was the most common complaint.
* Pressing A and D moved the stone in the same direction; left/right steering did not behave as expected.
* Ice friction felt inconsistent, either too high or too low, leading to unrealistic sliding.
* Players liked the overall concept, especially the idea of obstacles and the hybrid gameplay approach.

## Iteration
* Removed camera rotation inheritance and implemented a smoother follow camera to eliminate jitter and stabilize the view along the lane.
* Corrected left/right input so A reliably moves left and D moves right, removing mirrored movement behavior.
* Added controlled drag and custom friction to better simulate ice, and locked X/Z rotation to prevent unwanted rolling or tipping.
* Resolved rigidbody sleep-state issues to ensure consistent movement, collision handling, and scoring detection.

# 9. Citations
_Metric Research and References for Curling Stone & Sheet:_ https://worldcurling.org/rules/

- AI used to provide some code (all provided code was to our knowledge modified to a meaningful degree and only used to figure out paths forwards towards solutions)












