# Simple walk-through outline

When demonstrating, follow these steps. 

## Overview  

1) Start with overview of model classes
2) Show creation of Characters
3) Show default Characters
4) Run the program and see a couple things in PerformAction

## Singleton Pattern

1) Show the instances of new random() in the solution
2) Create the new static singleton for roller
3) Implement the random and roller
4) Replace calls to new random with the Roller Singleton
5) Talk briefly about the problem with it being injected into the model class without injection in the constructor
6) Create a couple characters and run it with breakpoints on the new  Random.  Note it is only hit once in the entire solution

## Strategy Pattern

1) Show how each of the Characters has the exact same attack and defend
2) Call out how they cannot ever change (what happens when Luke picks up a gun or a storm trooper picks up a light saber?)
3) What happens if instead of attacking they don't have a weapon?
4) What happens if instead of defending they decide to run away?

In the current system, they cannot change weapons or behave differently in scenarios.

5) Implement the behaviors algorithms [Attack and Defend Base, AttackWithWeapon, AttackNoWeapon, DefendWithWeapon, DefendRetreat]
6) Implement the Properties for each at the ICharacter/Character level
7) Replace all attack/defend class code with call to the behaviors
8) Show the new code [Han and Chewy fail to attack]
9) Add the interchangability [Han and Chewy Attack, han still runs away, chewy fails to use the force, Emporer runs away instead of using force, Jedi changes to multi-attack, droid tries to use the force on attack and fails].

## Decorator Pattern

Refactor the code in the Weapons section

Use composition to build new weapons in code on the fly

1) Show the weapons refactoring
2) Show the ability to decorate
3) Decorate the weapons for Chewy, the trooper, and Darth Maul

## Factory Pattern

