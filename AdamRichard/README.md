# Bowling Game Kata

## Background

Sure Strike Bowling Alley has asked you to implement a new scoring system for their ten pin bowling lanes.

The rules for tenpin bowling scoring are as follows:

A game of bowling consists of 10 frames (aka rounds). Each player bowls twice in a frame attempting to knock down all 10 pins.

The player is then scored based on the number of pins they knocked down for that frame.

Example:

**3 pins knocked down following by 4 pins = 7 score**

A player's final score is the tally of their score across all 10 frames.


More information can be found here:
[Bowling Scoring](https://www.topendsports.com/sport/tenpin/scoring.htm)



## Task 1

The requirements are simple. Players bowl a ball and knock down pins. The system needs to track each Bowl and then calculate the final score at the end of the game.

For example

```
    var game = new Game();
    game.Bowl(0);
    game.Bowl(0);
    // ... 18 more gutter balls
    game.Score();
```

The score for a gutter game (all zeros) should be **0**

Verify that a game where every bowl knocks down 1 pin (20 Bowls of 1) returns a score of **20**.

## Task 2

The regulars have reminded you that bowling has **spares**. If a player knocks down all 10 pins across two Bowls in a frame, the bonus for that frame is the number of pins knocked down on the *next* Bowl.

For example

```
    var game = new Game();
    game.Bowl(5);
    game.Bowl(5);  // Spare!
    game.Bowl(3);
    // ... 17 more gutter balls
    game.Score();
```

The score should be **16**

(Frame 1: 5 + 5 + 3 bonus = 13, Frame 2: 3, remaining frames: 0)

## Task 3

The league players are back and they're throwing **strikes**. If all 10 pins are knocked down on the first Bowl of a frame, the bonus is the next *two* Bowls.

For example

```
    var game = new Game();
    game.Bowl(10);  // Strike!
    game.Bowl(3);
    game.Bowl(4);
    // ... 16 more gutter balls
    game.Score();
```

The score should be **24**

(Frame 1: 10 + 3 + 4 bonus = 17, Frame 2: 3 + 4 = 7, remaining frames: 0)

## Task 4

It's tournament night and the best player has just bowled a **perfect game**  12 strikes in a row. *The 10th frame allows up to 3 Bowls if the player strikes or spares*.

```
    var game = new Game();
    for (int i = 0; i < 12; i++)
    {
        game.Bowl(10);
    }
    game.Score();
```

The score should be **300**

Make sure your system correctly handles the bonus Bowls in the 10th frame.

## Task 5

A spare in the 10th frame should grant exactly one bonus Bowl. Verify this works correctly.

```
    var game = new Game();
    // ... 18 gutter balls for frames 1-9
    game.Bowl(5);
    game.Bowl(5);  // Spare in the 10th frame
    game.Bowl(3);  // Bonus Bowl
    game.Score();
```

The score should be **13**

## Task 6

The staff at StrikeForce Lanes have noticed some suspicious scores being entered. Add validation to the scoring system to reject invalid input.

1. Pin counts must not be negative.
2. Pin counts must not be greater than 10.
3. Two Bowls in a frame must not sum to more than 10 (unless the first Bowl is a strike).
4. No more Bowls should be accepted once the game is complete.

## Task 7

The lanes are getting busier and the manager would like to display a **traditional scorecard** showing the running total for each frame, including the standard bowling notation.

For example, a game of `1, 4, 4, 5, 6, 4, 5, 5, 10, 0, 1, 7, 3, 6, 4, 10, 2, 8, 6` should produce something like:

```
    | F1  | F2  | F3  | F4  | F5  | F6  | F7  | F8  | F9  | F10   |
    | 1 4 | 4 5 | 6 / | 5 / | X   | 0 1 | 7 / | 6 / | X   | 2 / 6 |
    |  5  | 14  | 29  | 49  | 60  | 61  | 77  | 97  | 117 |  133  |
```
