# Snake Project Overview
![Main photo](https://media.discordapp.net/attachments/1076565079333548184/1184885784365506732/2023-12-14_16_52_39-Ignacuv_had.png?ex=658d99e1&is=657b24e1&hm=da3581a013fa47774b3501f42fedf5ed0f18f32fd44d73bacd6a8a58870d081e&=&format=webp&quality=lossless&width=1655&height=988)


## Project Structure
The Snake project is implemented in C# using Windows Forms. It consists of a main form (`MainWindow`) and various supporting classes.

### Key Components
1. **Snake Class:** Represents the snake in the game. Manages its movement, collision detection, and scoring.
2. **GameDrawer Class:** Responsible for drawing game elements on the screen, including the snake, fruits, and game overlays.
3. **CursorChange Class:** Configures custom cursor files, it's a great feature, trust me.

## Game Logic
- The game starts with a snake composed of a specified number of segments.
- The player controls the snake's movement using the W, A, S, D keys.
- Fruits appear on the screen, and the player must guide the snake to collect them.
- The snake grows longer with each collected fruit, and the player earns points.
- Collision with the snake's own body or game borders results in game over.
- The game can be won by collecting a set number of fruits.

## User Interface
- The main window is maximized and displays the game area.
- Sound settings (on/off) can be toggled using a radio button.
- Speed information is displayed in a text box.
- Score information is displayed in another text box.
- Buttons for starting, stopping, and resetting the game.

## Sound Effects
- Sound effects are played for collecting fruits, winning the game, and when the game is over.
- Background music plays during gameplay.

## Configuration and Settings
- Custom cursor files are configured for different game states.
- The program includes options to customize cursor files.

## Scaling and Display
- The game window is designed to scale with the screen size.
- The game warns users if their display may not render the game correctly.

## Additional Features
- The game adjusts the snake's speed based on the player's score.
- Winning the game triggers a victory screen.
- The game over screen is displayed in case of collisions.

## Notes
- The project includes a link to the author's GitHub profile.
- Certain features may be designed for specific display configurations.

## Dependencies
- NAudio library is used for audio playback.

## Acknowledgments
The project credits the author and provides links to external resources.

**Disclaimer:** This documentation assumes a basic understanding of C# and Windows Forms.
