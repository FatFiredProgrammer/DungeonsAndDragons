# Dungeons and Dragons C#

A sample / teaching project showing some useful C# concepts while implementing a very basic DnD game.

My goal here was to write a rather simple example which uses good coding techniques
and which also demonstrates a variety of different features of C#.
Hopefully, this provides a good basis for a novice to build on.

You'll find your original project substantially changed and broken out into classes. 
The top level class is now an **Adventure** class. 
You supply it a **UserInterface** (to provide I/O) and a _player_. 
Both _player_ and _enemy_ are of the **Character** class. 
The is an **IWeapon** interface and numerous instances of _IWeapon_ which a character can wield. 
A helper class named **Battle** handles the battle between a single _player_ and a single _enemy_. 
Pay attention to the [separation of concerns](https://en.wikipedia.org/wiki/Separation_of_concerns) - each class does a few specific things relavent to that class. 
Also notice the use of interfaces for things like [inversion of control](https://en.wikipedia.org/wiki/Inversion_of_control) or to define the behavior of a weapon. 
There is a **Dice** class which contains static instances of the 7 commom Dnd dice.