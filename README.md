# Refactoring the Star Wars Universe with Design Patterns  

This repo takes a look at a few of the most important design patterns in Object-Oriented Programming.  Of course this is my opinion, but as an object-oriented programmer you should know these patterns.

The patterns discussed and demonstrated in this repository are:

- The Strategy Pattern
- The Singleton Pattern
- The Factory Pattern
- The Decorator Pattern
- The Template Pattern

## Why Design Patterns

Why design patterns -

- Proven Solutions
- Maintenance and Resilience
- Patterns proven across languages
- Coding to patterns provides better solutions to problems

## How Design Patterns

How do you do it -

- Learn the basics
- Look for ways to implement
- Upgrade existing solutions
- Follow examples and then teach your team

## Problems with code that does not implement patterns 

There are a number of problems with Object-Oriented code when patterns are not implemented.  

- Coding new behvavior requires new classes
- Code modifications allow for spaghetti implementations
- No Inversion of Control/Dependency Injection
- Code relies on specific implementations
- Instantiation is Public and therefore not controlled
- Massive amounts of unnecessarily duplicated code.
- Unnecessary object instantiation & potential memory leaks.
- Unprotected algorithms that can be changed or modified.

## The Strategy Pattern

Code to behavior to save lots of problems.

- Evaluate code for common algorithms

- Create an interface for the family of algorithms

- Implement concrete types for different algorithms

- Use composition to consume code with the appropriate behavior

### Implementation

- New behaviors for attack and defend

    - Elminate class-specific attack and defense instances
    - Add new behaviors as easily as adding new classes
    - Modify behaviors in one place for the entire solution
    - Composition allows for characters to change their main method of attack.

Defend with blaster becomes defend with light saber.

Attack with blaster becomes attack with blaster cannon.

## The Decorator Pattern

Eliminate the problems with making a new subclass for each of your inheritance needs.

### Implementations

- Light Saber 
- Double-Bladed light Saber
- Light Saber with Force bonus

## The Singleton Pattern

Why instantiate a new roller class every time you need it?

### Implementations

A singleton static character roller class.

## The Factory Pattern

Not all instantiation should be public...This is why...

### Implementations

Character rolling with characteristics based on the roll and choices to generate the right type of character.

## The Template Pattern

Protect your algorithms - give additional options when appropriate.

### Implementations

The roll algorithm with hooks to change a few things when necessary.