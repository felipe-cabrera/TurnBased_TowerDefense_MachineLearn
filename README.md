# A Turn-Based Tower Defense Game With AI
The objective of the game is to propose a method to Classify the enemies using AI.

# History
The game runs in a period of war, your nation is being attacked by 5 different arms and you need to use your missiles to defeat the enemies and survive as long as possible.

# Game Idea
- The game have 5 types of Towers: Blue, Yellow, Green, Purple and Orange;
  - All towers also have 2 lifes;
- The game also have 5 types of Enemies (2 variants per type): Blue, Yellow, Green, Purple and Orange;
- Each enemy have two properties: Attack and Defense;
   - The Attack and Defense have an random interval for each type, for example:
     - Blue Attack goes from 21 to 30 and Defense from 1 to 9.
     - Green Attack goes from 11 to 20 and Defense from 11 to 20 too.
     - You can check it on Dataset Overview.xlsx
   - All enemies also have 2 lifes.
- If a tower shot an enemy with the same type it, the enemy die;
  - Otherwise, the enemy only lost 1 life point.
- If an enemy hit a tower, the tower lost 1 life point;

# Gameplay
- The player can only set the position of the towers in the Game Board;
- After that the game will start and the towers will try to learn what is type of each enemy and choose one to shot.
  - The only info that the tower will have is the enemy Attack and Defense.
  - Using k-NN algorithms we will try to teach the tower how to classify an enemy and find it's type.
  
# Metris and Score
- To check how a trained Tower can play and compare to less trained and fully-random Towers, we have 2 kind of scores:
  - How many Battles we win
  - How many Enemies we defeat

# Authors
Felipe Cabrera Ribeiro dos Santos - 
Mauricio Anderson Perecim
Vinícius de Souza Gonçalves

# Requirements
Unity version 2019.1.0b9 or superior.
  - You can download it at: https://unity3d.com/pt/get-unity/download
Visual Studio 2019 (Recommended) or 2017.
  - You can download it at: https://visualstudio.microsoft.com/pt-br/vs/
  
# Copyright
This project is totally educational, aiming only at sharing knowledge and science.
If it is useful to you, you can use it as you wish, just give us the credits (citation)

# Images used in game
All images used are free and have no copyright  
- Background: The U.S. National Archives   
  - Source: https://nara.getarchive.net/media/artwork-close-combat-world-war-ii-artist-hamilton-greene-catalog-number-d13883-949654  
- Game Sprites (Images): Kenney  
  - Source: https://www.kenney.nl/assets/tower-defense-top-down  
 
