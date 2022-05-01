# Refactoring the Star Wars Universe with Design Patterns  

This repo takes a look at a few of the most important design patterns in Object-Oriented Programming.  Of course this is my opinion, but as an object-oriented programmer you should know these patterns at a minimum when building solutions.

The patterns discussed and demonstrated in this repository are:

- The Singleton Pattern
- The Strategy Pattern
- The Factory Pattern
- The Decorator Pattern
- The Template Pattern

However, before diving into the patterns, let's take a look at why we should use patterns.  

## Why Design Patterns

Design patterns are not code, so why should you bother using them?  There are a number of benefits to using design patterns, including the following:

- Proven Solutions to known problems
- Provide benefits for the Maintenance and Resilience of code
- Patterns proven across languages

### Proven solutions to known problems

Design patterns exist because object-oriented developers continue to run into the same problems, and these patterns help to solve them.

It is important to remember that patterns are not code, but rather are blueprints to the solutions that solve the problems at hand.

With the blueprint, you can implement a robust solution that you know will solve the problem and also be resilient and easily maintainable.

### Provide benefits to the Maintenance and Resilience of code

By using patterns, you end up with a demonstrated solution to the problem that will not create a mess of spaghetti code that is reliant on each piece of the house of cards before it comes tumbling down.

When it's time to enhance, sometimes the pattern is built for immediate extension.  In other scenarios, a few simple changes here and there can enhance the code and stay in line with the original pattern.

As we'll see later in this demonstration/walkthrough, it will be easier to maintain this solution once the patterns are implemented, and the code will be more concise and easier to enhance.

### Patterns proven across languages

Design patterns will work in any object-oriented language, so whether you are using Java, C#, or another object-oriented language, you can implement these patterns.

Furthermore, when you discuss solutions with other developers, you can count on the fact that they understand and/or have used the patterns and can help to examine any scenarios or issues you are having.

## How Design Patterns

Ok, you're sold on using patterns, but not sure where to start.  A couple of strategies could be as follows:

- Learn the basics
- Look for ways to implement
- Upgrade existing solutions
- Follow examples and then teach your team

### Learn the basics

As with anything, you can't do something if you don't know about it. A good starting place would be to learn about some of the basic patterns.  Perhaps that is even why you are here.

### Look for ways to implement

Once you know about a solution, look for scenarios where it would be easy to enhance or change a solution (or greenfield develop) with one of the patterns you know.

For example, maybe you are implementing a solution to connect to a database.  Will it always be that database?  Maybe you need the ability to switch how to connect, query, and modify data within the target database.  The overall operations are the same, but based on your target the code can be quite different.  

>**Note:** Just because you can apply a pattern doesn't mean you should.  As Confucius said - "Don't use a cannon to kill a mosquito."

### Upgrade existing solutions

When you are performing an enhancement on an existing solution, if you see something that would benefit from a pattern, use that chance to implement the enhancements with the pattern to help make the solution less prone to bugs and problems in the future.

### Follow examples and teach your team

One of the best ways to learn and/or enhance your learning is to have to teach the material.  If you are learning something, look for ways you can share that knowledge.  Perhaps that's through a blog post or maybe your team does internal sessions like lunch and learns or even a monthly lightning talk.  

Use times like those to show the things you've learned to both solidify your knowledge and share it with your team so they can learn it as well.

## Problems with code that does not implement patterns 

The rest of this information is designed to help you see the problems and the solutions that exist when patterns should have been used but were not, and then how you can modify the system to get the pattern implemented.

Unfortunately, to do this requires a non-trivial amount of code in some very trivial scenarios.  For that reason, I'm trying to highlight as much as possible here, and you can look into the repository to see all of the code in full context.

### Problems in object-oriented code without patterns  

There are a number of problems with Object-Oriented code when patterns are not implemented.  

- Coding new behvavior requires new classes
- Code modifications allow for spaghetti implementations
- No Inversion of Control/Dependency Injection
- Code relies on specific implementations
- Instantiation is Public and therefore not controlled
- Massive amounts of unnecessarily duplicated code.
- Unnecessary object instantiation & potential memory leaks.
- Unprotected algorithms that can be changed or modified.

With all of that in mind, let's dive into some code.

## Quick overview

To complete this study, we're looking at a fictional Star Wars universe that could be used to generate roll-playing characters or as the base code in a more robust game.  

We'll start by looking at the Singleton pattern, then move to the Strategy Pattern, followed by the Factory Pattern, then the Decorator Pattern, and we'll finish with the Template Pattern

## The Singleton Pattern

In the example code that is used for this solution, even the bad universe has a Singleton class for the ConfigurationBuilder.

It is important to note that this is not really necessary and since we're only building the solution once the gain here is minimal.  However, if the builder needed to be used in multiple places, it would be useful.

That being said, there are a number of places where a new Random class is generated, all for the purposes of rolling for ability.  Sometimes it's for force skills, sometimes its for hit probability or damage value.

It could be interesting to just create a new Roller class that allows for using a singleton Random class.  While this might also be a cannon to kill a mosquito, it's a good simple demonstration of how we can avoid "newing up" Random classes all over the place - and over and over again in code.

Goals:

- Eliminate multiple new Random() class instantiations
- Be able to use the Roller throughout the solution to generate appropriate random numbers

### Old code

The old code looks something like this when used:

```c#
Random r = new Random(); //or new Random(seedValueInt)
var nextRandom = r.Next(x, y); //or r.Next();
```  

The new code will reference the instance to get the next value

```c#
var roller = Roller.Instance;
roller.Next(x, y); // or r.Next();
```  

Yes, this is probably a bit of overkill for this simple scenario, but it illustrates how to build out the singleton.  Additionally, it's important to note that a number of systems already implement the singleton pattern for you.  For example, in an MVC web application, you create a new instance of your database context and any service files in the Program (or Startup) file.  Once you do this, you can inject the singleton instance into your controllers.

To implement, the main point is to keep from having to restart the class over and over again.

Create a new static class to house the instance of the Roller, and then implement the code as follows:

```c#
public sealed class RandomRoller
{
    private static RandomRoller _roller = null;
    private static readonly object instanceLock = new object();
    private static Random _random;

    //do not expose a public constructor
    private RandomRoller()
    {
        _random = new Random();
    }

    //instead, expose a static instance
    public static RandomRoller Instance
    {
        get
        {
            lock (instanceLock)
            {
                //if the roller is null, create it new
                if (_roller == null)
                {
                    _roller = new RandomRoller();
                }
                //return the roller 
                return _roller;
            }
        }
    }

    //utilize this method to get access to the internal
    //random object that is now singleton
    public static Random Roller
    {
        get
        {
            if (_roller == null) { var x = Instance; }
            
            return _random;
        }
    }
}
```  

After creating the singleton, replace all calls to a new Random() with the roller instance and utilize that to prove that the random object is only created once per solution run.

## The Strategy Pattern

In your solutions, when you find that there are similar problems with various solutions, this might be a good time to apply the strategy pattern.

The strategy pattern takes an algorithm family (similar processes), and then creates a code implementation for the behaviors in the algorithm, and then allows them to be used interchangeably in code at runtime via composition. 

For example, think of changing a tire.  No matter the vehicle, the algorithm is similar:

- Loosen (don't remove) lugnuts
- Jack the vehicle up/support it
- Remove lugnuts
- Remove tire
- Place new tire on vehicle
- Tighten lugnuts by hand
- Lower vehicle
- Use power tool/all your might to ensure lugnuts are as tight as possible.

When the solution is implemented, it might matter at minor details like what size of tire, what strength of jack, and how to tighten the lugnuts, but the algorithm is the same.  The strategy pattern would use behaviors around the pieces that can vary and implement the code for the algorithm, allowing the right tools to be used and the right size tires to be used as appropriate without having to write different versions of the code for the entire algorithm.

When implementing the strategy pattern, assuming you have found a valid candidate for utilizing the strategy pattern, follow these suggestions:  

- Create an interface for the interchangeable behavior
- Implement concrete types for different implementations of the behavior
- Use composition to consume code with the appropriate behavior injected at runtime
### Implementation

To examine this pattern in the Star Wars Universe, consider code that has the following problems:  

- Each class must implement its own behavior for attack and defense 
- Some behavioral code in classes is exactly repeated in other character classes
- A character cannot ever change their attack or defense behavior
- The solution has to have knowledge of each character to leverage attack and defense behaviors

After applying the strategy pattern, the code will have a number of improvements:

- Elimination of class-specific attack and defense instances
- Can now add new behaviors as easily as adding new classes, and all characters can use them immediately
- Modify existing behaviors in one place for the entire solution
- Composition allows for characters to change their attack or defense strategy

For example: 
- Defend with blaster becomes defend with light saber.
- Attack with blaster becomes attack with blaster cannon.

## The Decorator Pattern

Eliminate the problems with making a new subclass for each of your inheritance needs.

### Implementations

- Light Saber 
- Double-Bladed light Saber
- Blaster
- BlasterRifle
- BlasterCannon

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



Singleton => RollerClass
Strategy => Attack and defense behaviors
Factory => Character Classification factory
Decorator => Weapons
Template => Character Classifications