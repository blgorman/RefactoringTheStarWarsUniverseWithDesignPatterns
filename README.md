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

### Definition

A design pattern that restricts object creation for a class to only one instance. [ref. Singleton Pattern](https://en.wikipedia.org/wiki/Singleton_pattern)


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

Code changes can be seen by comparing commit a1cf9e1 to 6e3ad09.

```bash
git diff 6e3ad09 a1cf9e1
```  

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

### Definition  

A design pattern that enables the selection of an algorithm at runtime by taking a family of algorithms and encapsulating the implementations so as to create interchangeable behaviors.  [ref. Strategy Pattern](https://en.wikipedia.org/wiki/Strategy_pattern)  

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
- Default Attack and Defend Behaviors
- Attack with Force or Attack with Weapon or both
- Defend with Force or Defend with Weapon or retreat

Benefits: 

Use composition to change default behaviors
Can use one attack in round 1, then another attack in round 2
The same code can be used for any character to perform their attack and defend

### Code Samples

You will want to review the codebase for this.  Pay attention to the fact that all attack/defend code is removed from all classes.

Also note, you can change behaviors on the fly by setting new behaviors.

Review the Behaviors folder, and review how the AnyCharacter is composed as well as how the default characters can be modified.

## The Decorator Pattern

Eliminate the problems with making a new subclass for each of your inheritance needs.  

### Definition

Allow behavior to be enhanced for each object without affecting other objects of the same class by taking in an object of its own type and enhancing the base operations with new functionality.  Avoids the problem of subclass explosion. [ref. Decorator Pattern](https://en.wikipedia.org/wiki/Decorator_pattern)

### Implementations

- Light Saber 
- Double-Bladed light Saber
- Blaster
- BlasterRifle
- BlasterCannon

Currently, every new weapon has to have its own class.  What if, however, each weapon could just be a more advanced version of the base weapon?

For example, a blaster cannon is just like a blaster rifle, only with a different name and more power, while that is just the blaster with a different name and power.

Blaster -> 5 hp
BlasterRifle -> 10 hp (2 blasters)
BlasterCannon -> 15 hp (3 blasters)

Or light sabers and double-bladed light sabers:

LightSaber -> 15 hp
DoubleLightSaber -> 30hp

What about if you want to forge a new weapon like a BowCasterRifle?

With the decorator pattern, you can do this by creating your base weapons and then you can just go crazy when using them.

### Implementation

Change the base weapons and allow a constructor that decorates by using a base weapon

You will want to look at the changes in the Weapons classes as they can now be composed to become more powerful.

For example, you can create

- Blaster Cannon
- Blaster Rifle
- Blaster Blaster Rifle Cannon
- Bowcaster
- Bowcaster Rifle
- Bowcaster Bowcaster Rifle Cannon
- Light Saber
- Light Saber Light Saber
- Light Saber Cannon

As you can see the possibilities are endless but some would be ridiculous in this universe.  That being said, you no longer have to create a class for every single new weapon.


## The Factory Pattern

The changes necessary to implement a factory pattern could be trivial.  However, in this solution putting a factory in place for classifications revealed a bit of a "cross polination" of ideas - where the character was a type but really the type was a classification.  

There are really three types of characters, and different classifications may be required in one or more of these types.  Also, different types might be disallowed.  For this reason, the code should just spin up the classification type that is appropriate without the user having to do anything but configure it.  To make this happen, three factories are implemented:

- NoForceAbilityFactory
- ForceAbleFactory
- MightHaveForceCharacterFactory

Now all types can be leveraged by first setting the correct factory.  This should make it very difficult to incorrectly create a Jedi that doesn't have the force or a droid that does have the force.

Additionally, the correct algorithm for the activities will be able to easily be implemented by the classification choice without concern for spinning up the classification.  The correct classification type should be chosen by the way the user chooses to create the original character. 

### Definition  

Use a factory method to create objects based on the choices of the system without having to know everything about the exact class that will be created.  Delegates the construction of classes to another object and allows flexibility and abstraction of detail from the caller.  [ref. Factory Pattern](https://en.wikipedia.org/wiki/Factory_method_pattern)  

### Implementations

To make this happen, first create the abstract factory, then create three implementations of the factory

```cs
public abstract class CharacterClassificationFactory
{
    public CharacterClassification SetClass(ClassificationType c)
    {
        return CreateClass(c);
    }

    protected abstract CharacterClassification CreateClass(ClassificationType c);
}
``` 

Put all the types that are possible to be created with a "No Force" classification

```cs
public class NoForceAbilityFactory : CharacterClassificationFactory
{
    protected override CharacterClassification CreateClass(ClassificationType c)
    {
        switch (c)
        {
            case ClassificationType.BountyHunter:
                return new BountyHunter();
            case ClassificationType.Droid:
                return new Droid();
            case ClassificationType.Raider:
                return new Raider();
            case ClassificationType.Smuggler:
                return new Smuggler();
            case ClassificationType.Trooper:
                return new Trooper();
            case ClassificationType.Generic:
                return new GenericCharacter();
            default:
                return new GenericCharacter();
        }
    }
}
```  

Put all the types that are possible to be created with a "Must Have Force" classification

```cs
public class ForceAbleFactory : CharacterClassificationFactory
{
    protected override CharacterClassification CreateClass(ClassificationType c)
    {
        switch (c)
        {
            case ClassificationType.Jedi:
                return new Jedi();
            case ClassificationType.Sith:
                return new Sith();
            default:
                return new Jedi();
        }
    }
}
```  
Same for MightHaveForce:

```cs
public class MightHaveForceCharacterFactory : CharacterClassificationFactory
{
    //might have the force, might not
    protected override CharacterClassification CreateClass(ClassificationType c)
    {
        switch (c)
        {
            case ClassificationType.BountyHunter:
                return new BountyHunter();
            case ClassificationType.Raider:
                return new Raider();
            case ClassificationType.Smuggler:
                return new Smuggler();
            case ClassificationType.Trooper:
                return new Trooper();
            case ClassificationType.Generic:
                return new GenericCharacter();
            case ClassificationType.MobBoss:
                return new MobBossClassification();
            case ClassificationType.Politician:
                return new PoliticianClassification();
            case ClassificationType.Scavenger:
                return new ScavengerClassification();
            default:
                return new GenericCharacter();
        }
    }
}
```  

Note that there is some overlap here, but if you choose force enabled, you also most select Jedi or Sith.  If you choose NoForce, you could do any of the types other than Jedi/Sith but this is also the only place you can create a Droid.  The Might have includes types that may or may not have the force.  

To clean this up, all the classifications needed to be added to the enum and then in the Characters hierarchy all ability to manually configure force ability was removed.  Either it is automatic, not allowed, or is possible but not determined until runtime.

To make this complete, the SetClass method was delegated to the implementations to utilize the factory that was appropriate, and three new Characters are added - AnyCharacter, ForceAbledCharacter, and NoForceAbilityCharacter.  Most characters can be generated from those types, but the old types were left (except Scoundrel, which was removed).  

The SetClass method in each implementation uses the correct factory to get the implementation of the Classification to compose the character.  

```cs
//AnyCharacter - might have force
public override void SetClass(ClassificationType c)
{
    var characterFactory = new MightHaveForceCharacterFactory();
    Classification = characterFactory.SetClass(c);
}
//ForceCharacter - jedi/sith only
public override void SetClass(ClassificationType c)
{
    var characterFactory = new ForceAbleFactory();
    Classification = characterFactory.SetClass(c);
}
//nonForce character - any but jedi/sith
public override void SetClass(ClassificationType c)
{
    var characterFactory = new NoForceAbilityFactory();
    Classification = characterFactory.SetClass(c);
}
```  

The constructors inject the correct force settings, so the user doesn't have to think about them in any of the cases (note the true, false that are sent to the base for the choices of canHaveForce and mustHaveForce):

```cs
//any character but droid - might have force
public AnyCharacter(string name, int age, double height, double weight, int classificationChoice, int speciesChoice, int weaponChoice, Random random)
    : base(name, age, height, weight, classificationChoice, speciesChoice, weaponChoice, true, false, random)
{
}
//Force Character (jedi/sith only) - must have force
public ForceAbledCharacter(string name, int age, double height, double weight, int classificationChoice, int speciesChoice, int weaponChoice, Random random)
    : base(name, age, height, weight, classificationChoice, speciesChoice, weaponChoice, true, true, random)
{
}
//Non Force Character (any but jedi/sith)
public NoForceAbilityCharacter(string name, int age, double height, double weight, int classificationChoice, int speciesChoice, int weaponChoice, Random random)
    : base(name, age, height, weight, classificationChoice, speciesChoice, weaponChoice, false, false, random)
{
}
```  

With this in place, the default characters can be generated with the new factory types:  

```cs
private static List<ICharacter> MainCharacters() => new List<ICharacter>
{
    new NoForceAbilityCharacter("Han Solo", 42, 6.04, 225, (int)ClassificationType.Smuggler, (int)KnownSpeciesType.Human, (int)Wea...
    new NoForceAbilityCharacter("Chewbacca", 152, 8.31, 423, (int)ClassificationType.Smuggler, (int)KnownSpeciesType.Wookie, (int)...
    new ForceAbledCharacter("Luke Skywalker", 27, 5.72, 175, (int)ClassificationType.Jedi, (int)KnownSpeciesType.Human, (int)Weapo...
    new ForceAbledCharacter("Emporer Palpatine", 72, 5.61, 164, (int)ClassificationType.Sith, (int)KnownSpeciesType.Human, (int)We...
    new ForceAbledCharacter("Princess Leia", 29, 5.4, 120, (int)ClassificationType.Generic, (int)KnownSpeciesType.Human, (int)Weap...
    new AnyDroid("C-3PO", 92, 5.9, 320, (int)KnownSpeciesType.Droid, (int)WeaponChoices.Staff, RandomRoller.Roller, new AttackNoWe...
    new AnyCharacter("Finn", 27, 6.0, 190, (int)ClassificationType.Trooper, (int)KnownSpeciesType.Human, (int)WeaponChoices.Blaste...
    new ForceAbledCharacter("Darth Maul", 27, 6.4, 252, (int)ClassificationType.Sith, (int)KnownSpeciesType.Human, (int)WeaponChoi...
};
```  

## The Template Pattern

For the template pattern, the perform action needs to be equal for all of the players in the game.  It would be unfair if someone was able to run an extra action or attack every time.  Therefore, you want to protect the algorithm.  

There may be times when you want to add an additional, optional task.  A good example of this is two-factor authentication.  In some instances, you may be ok with just a single factor, but in others you will want to require it.

In this scenario, imagine that the actions must be taken one at a time, but there might be a second action that allows a user to act a second appropriately if the first action is something simple like Patrolling.  They might also be able to add a challenge if they run into another character, such as asking for identification (as part of the patrolling action).

To keep this simple, all actions are just strings and the code will respond when the string is "Patrolling".  In a real implementation you would want to have enums and a more robust solution.

### Definition  



### Implementations

All of the classification types have the ability to perform an action.  We don't want any of them to add additional actions like "Attack" and then "Attack Again".  However, we want to allow for a challenge action if the patrolling character encounters another character.

To do this, we need to first lock down the algorithm in the base class so it can't be overridden.  Once that is done, we need to add an optional hook to the algorithm for allowing the challenge action.

## Summary

In this video/code, we refactored the star wars universe to implement the following patterns using the listed approach:

- Singleton => RollerClass
- Strategy => Attack and defense behaviors
- Decorator => Weapons modifications without subclass explosion
- Factory => Character Classification factories for force abilities
- Template => Character Classifications action algorithms

I hope you found this useful and informative.

Let me know how it could be improved!

## Additional References

More information can be found in these links:

- [Head First Design Patterns](https://www.amazon.com/Head-First-Design-Patterns-Object-Oriented/dp/149207800X/ref=asc_df_149207800X/?tag=hyprod-20&linkCode=df0&hvadid=459709175715&hvpos=&hvnetw=g&hvrand=6676623056321867402&hvpone=&hvptwo=&hvqmt=&hvdev=c&hvdvcmdl=&hvlocint=&hvlocphy=9018135&hvtargid=pla-918195320150&psc=1)  
- [DoFactory](https://www.dofactory.com/net/design-patterns)  
- [Design Patterns](https://en.wikipedia.org/wiki/Design_Patterns)  
