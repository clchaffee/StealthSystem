# Enemy Detection System

## Overview

This script defines an enemy detection system for a game using the Godot engine. The system determines how an enemy detects and reacts to the player, transitioning through different states based on visibility and detection thresholds.

## Game States

The script defines an enumeration GameState that represents different states an enemy can be in:

Wander – Default non-hostile state where the enemy moves around.

Idle – Default non-hostile state where the enemy stays in place.

Surprised – Triggered when the enemy starts detecting the player, transitioning to either Wary or Investigating.

Wary – The enemy is actively moving or patrolling and detects the player more easily.

Investigating – The enemy moves toward a suspicious position and is more alert.

Reinforcing – The enemy signals other enemies to alert them.

Alerted – The enemy is hostile and moves toward the player's last known position.

Chasing – The enemy is actively pursuing and attacking the player.

## Enemy Detection Logic

The Enemy class is responsible for tracking the player and transitioning between states.

Key Properties:

rayLength and rayIntegrity – Placeholder properties for detection mechanics.

detectionIncreaseRate – How quickly the enemy detects the player.

detectionDecayRate – How quickly the enemy loses detection over time.

detectPlayerThreshold – The detection level required to transition into a fully hostile state.

currentDetection – The current detection level of the player.

canSeePlayer – A boolean flag indicating whether the player is visible to the enemy.

currentGameState – The current behavior state of the enemy.

## State Transitions:

If the enemy is in Wander or Idle, detecting the player gradually increases currentDetection. If it reaches half of detectPlayerThreshold, the enemy becomes Surprised.

In the Surprised state, the enemy transitions to Wary if they still see the player, or Investigating if they don't.

Wary and Investigating states increase detection faster if the player remains visible.

When currentDetection reaches detectPlayerThreshold, the enemy transitions to Chasing.

If an enemy in Alerted or Reinforcing states sees the player, they immediately start Chasing.

Chasing sets detection to max and continues until the player is lost, reverting to Alerted.

If an enemy loses sight of the player, their detection decays over time, potentially reverting to a passive state.

## Debugging and Testing Functions:

TESTBecomeSurprised() – Simulates the enemy becoming Surprised.

TESTChangePlayerVisibility() – Toggles canSeePlayer when Debug5 is pressed.

TESTCanSeePlayer() – Updates detection and transitions based on the current state.

## Execution Flow:

_ready() initializes the enemy in the Idle state.

_Process() continuously checks detection and player visibility.

This script serves as a foundation for enemy AI and can be expanded with movement, reinforcement, and attack logic.

