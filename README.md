# Rest Assured Game Design Document

### Play this game on itch.io [here!](https://elenaywang.itch.io/rest-assured)

## Synopsis:
*Rest Assured* is a two-player, co-op shoot 'em up game that represents the differing experiences between people who have different circadian rhythms, specifically delayed sleep phase syndrome (DSPS) vs. a normal circadian rhythm. The main lesson from the game is that different people have different strengths and weaknesses, and we should take the time to understand those differences and work with them to benefit everyone.   

The two characters are sisters named Lux and Nox. Lux is the seemingly perfect older sister with a normal circadian rhythm, while Nox is the misunderstood younger sister with DSPS. They are tasked with protecting the Supreme Elixir of Blissful Rest in the center of the game screen for 72 hours in game time.

**Total playtime:** about 7 min



## Story: 
- The game takes place in a magical fantasy world.
- In the center of the game screen, there is a vault. Inside the vault, a precious resource called the Supreme Elixir of Blissful Rest is being held. The evil demons are constantly trying to steal the elixir throughout all hours of the day. It is of the utmost importance that the elixir is protected from being stolen.
- The two daughters of the king and queen are tasked with protecting the elixir when the king and queen are away on a trip. The older sister is the epitome of the golden child, while the younger sister is seen as lazy because she struggles with staying awake in the mornings and going to sleep at night.
- Each round lasts for 3 day/night cycles.



## Inspiration: 
- **Pixar’s *Day & Night* short film:** characters that embody day and night, each have their own strengths and it’s best when individual differences are appreciated
- **Plants vs. Zombies:** protecting something from an opponent
- **Degrees of Separation:** 2 characters with opposing powers working together, split-screen gameplay
- **Fireboy and Watergirl:** 2 characters with opposing powers working together



## Original Vision for this game
I had more ideas for this game, but my original vision proved to be too large in scope. Here are the addiitonal ideas I originally had for this game:      
- Game would consist of 2 types of rounds: a competitive round and a co-op round. 
- Lux and Nox would each have 2 distinct powers (types of attacks).
- There would be 4 types of opponents, one for each type of attack.
- Lux and Nox would be able to inflict damage on all opponents, but certain attacks would be more powerful against certain opponents than the rest.
- The opponents would also be able to attack Lux and Nox by depleting their energy.
- Lux and Nox would "burn out" if they completely run out of energy.

This is how the gameplay would have looked like:   
**Round 1:**
- Lux and Nox are competing against each other to determine who is the better guard.
- Lux and Nox defend different halves of the screen. A line goes through the middle of the screen to visually show this division. This will encourage competition between the 2 players.
- During this round, the people playing the game should realize that it is difficult to defend the vault when their player is asleep, but the other player will usually be awake.

**Round 2:**
- Could be removed if I decide that it is not necessary for the narrative
- Lux and Nox gain new abilities and/or the opponents become more powerful

**Round 3:**
- The king and queen return back home to find that their daughters are feuding and competing against each other to determine which one is the best guard. They have a dialogue before this round to point out that each player peaks in their abilities at different times and against certain opponents, then suggests that it would be better if Lux and Nox work together.
- At this point, the game turns into a teamwork-based game. The line between the halves of the screen is removed and Lux and Nox are free to move between both halves. 
- The people playing the game should be more successful at protecting the vault since they are able to draw on each other’s strengths.
- After this round is finished, the game will give a brief description of delayed sleep phase syndrome and provide some resources to learn more.

**Remaining rounds:**
- Now that Lux and Nox are able to work together, the game should be more enjoyable to play. The people playing are free to continue playing as many rounds as they like.



## Characters:
### Lux:
- Has a normal chronotype (awake during the day, sleeps at night)
- Older sister
- Is the epitome of the golden child, is seemingly perfect
- In my original vision for the game, Lux would have the following powers: light rays (burns what it touches), reflections (causes temporary blindness)

### Nox:
- Has delayed sleep phase disorder, also known as a night owl (functions best during the night, is very sleepy in the morning)
- Is chronically sleep-deprived, which is indicated by a lower level of initial energy
- Her sleep schedule is mistaken for laziness, but she is actually always trying her best given the circumstances
- Younger sister
- Is the underdog, is more powerful than she is given credit for
- In my original vision for the game, Nox would have the following powers: fireworks (creates loud sounds and bright colors), shadows (obscures vision and induces psychological fear)



## Mechanisms:

### Player movement
- There are two players, so each has to be controlled by a different set of input.
- In the split-screen competitive rounds, the players will need to be limited to their half of the screen. In the co-op rounds the players can move between both halves of the screen.

### Player energy
- Each player has a limited amount of energy that generally decreases with time. 
- Lux will start with more energy that decreases throughout the day. By the time that night starts, Lux should sleep so that her energy is refilled by the time day starts. However, she is unlikely to completely run out of energy, so she is able to wake up every once in a while during the night if necessary.
- Nox will start with less energy since she is chronically sleep-deprived. However, her energy suddenly is boosted at night, even without sleep. However, by the time day starts again, her energy is generally depleted and she should sleep. She is more prone to completely running out of energy.
- Each player will need to sleep to recharge their energy, which means that they will be inactive for short periods during the game. Part of the point of this game is figuring out how to manage the players’ energy by strategically choosing when the player should sleep, while also keeping the vault safe.
- In my original vision for this game, if the player completely runs out of energy ("burnout"), they would need to sleep for a certain minimum amount of time before they are able to play again.

### Day/Night cycles
- The graphics will change between the night and day.
- Certain opponents will appear more frequently during day or night.
- In my original vision for this game, each player’s attacks will differ in effectiveness based on the time of day. Lux will be most effective during the day, Nox will be most effective during the second half of the day and throughout the night.

### Vault health
- The vault can withstand a certain number of attacks before it is destroyed and the opponents are able to confiscate the elixir and win the game.

### Player attacks (in my original vision for this game)
- Each player has different attacks from each other, and each has two types of attacks.
    - **Lux’s attacks:** light rays (burns what it touches), reflections (causes temporary blindness)
    - **Nox’s attacks:** fireworks (creates loud sounds and bright colors), shadows (obscures vision and induces psychological fear)
- Certain attacks will be more effective for certain opponents and will have different visuals.

### Opponent attacks (in my original vision for this game)
- There are four types of opponents. Each type is most vulnerable to a certain type of attack. 
- Each type of opponent has the ability to attack the player in some way, most likely by placing spells that temporarily interfere with the player’s ability to function in some way. 
- Opponents are more active during the day, but more powerful at night.



## Attributions

DIS Copenhagen    
Game Development: Programming and Practice core course    
Instructor: Benno Lüders    
2025 Spring semester   

### Assets
- Lux & Nox: https://9e0.itch.io/witches-pack
- Demon enemies: https://penzilla.itch.io/hooded-protagonist
- Lightning bolt: https://opengameart.org/content/game-icons-heart-diamond-star-and-lightning-bolt
- Health bar: [https://github.com/Brackeys/Health-Bar/tree/master/Health Bar/Assets/Sprites](https://github.com/Brackeys/Health-Bar/tree/master/Health%20Bar/Assets/Sprites)
- Vault & Elixir: Canva graphics
- Fairy character, Sun, Cloud, and Background for intro story: Canva graphics

### Tutorials I referenced
- start menu: https://youtu.be/zc8ac_qUXQY?si=UAwR5RGT-fQ-p8o6
- pause menu: https://youtu.be/JivuXdrIHK0?si=hY-hF44npcNaP-Ya
- health (energy) bar: https://youtu.be/BLfNP4Sc_iA?si=Zf88aRww3jtPZStr
- time system: https://youtu.be/Y_AOfPupWhU?si=x2i-JWlNpj5-3Xjy
- restricting player movement to within screen: https://youtu.be/qnr42UXQ0kc?si=pJbaleu7VR57bzBD
- changing camera color in game: https://youtu.be/gaFbwu1e0rI?si=wzFPSmxdfmP7bTeK
- creating Mac build: https://docs.unity3d.com/Manual/macos-building.html
- creating WebGL build: https://learn.unity.com/tutorial/create-and-publish-webgl-builds#
- uploading WebGL to itch.io: https://youtu.be/H2HCXVAbe0w?si=-sodW0D4EvUqh-IQ

I also consulted the Claude Sonnet 4 chatbot for help with writing some of my code. Any scripts containing code written with Claude's help are indicated with a comment at the top of the script.