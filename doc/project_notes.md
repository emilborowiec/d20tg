# Project notes

## Project Goal

The main goal of the project is to try out Component-Based Architecture in Blazor.

I also wanted to explore some ideas around visualization of d20 system math.

## Application Scope and Purpose

**d20 Testing Grounds** (d20TG) is a web application for simulating trivial combat scenarios in d20 gaming system.
By running multiple simulations of the same scenario, the application provides statistical and visualize impact of buffs and build differences.

## The Domain

The application works with basic combat rules from d20 system which apply to many versions of D&D, 
Pathfinder and many computer games.

Here are the main concepts from d20 that are modelled in the application.

**Armor Class** - Armor class decides how difficult it is to hit a target.

**Attack Bonus** - Represents combat skill. It increases chance of hitting the target.

**Attack Roll** - 
1 on d20 always misses;
20 on d20 always hits;
if Attack Bonus + d20 >= Armor Class then the attack hits.

**Damage Dice** - Weapon-dependent formula of checking how much damage this weapon deals on hit.

**Damage Bonus** - Flat bonus amount of damage delt with every successful attack.

**Damage Roll** - DamageDelt = DamageDice + DamageBonus

**AttackerBuild** - A simplified model of character build equipped to attack; 

- AttackBonus
- DamageBonus
- DamageDice (dice type and count, for example 2d4)

**DefenderBuild** - A simplified model of character build that can be attacked:

- HitPoints
- ArmorClass

### Version-specific rules

Rules around critical hits, damage types and damage reduction are different in specific versions of D&D.
Covering those rules is out of scope of this application, as I see it at the time of writing this.
It is however an interesting option for future development.

## The Business 

d20TG lets users prepare trivialized combat scenarios where one or more Attackers try to defeat
one or more Defender. 
Those scenarios can then be tested statistically by running multiple simulations of how the combat could play out.
The application calculates averages of interesting metrics like damage-per-round or number of rounds needed
to defeat all Defenders.

Some of the main concepts featuring in application's business model are:

**Scenario**
One or more attacker builds vs one or more defender builds

**Scenario Simulation**
Combat simulation where a Scenario is played through round by round until all defenders are defeated.

**Defender**
A character to defeated in a simulation. Enemy is characterized by armor class, max hit points and current hit points.

**Attacker**
A character that attempts to defeat all Defenders in a simulation.

### Object-Oriented Model

The concepts from application's business and domain are modelled with classes and relations
depicted on the diagram below.

![model](business_model_i2.png)

## Development plan

I like to employ an incremental-iterative approach to development. 
This means that the application will be released early with very narrow scope of features and only
simple functionality. First, a crude feature is delivered, and then, it is improved upon 
in subsequent iterations. 
Once I'm happy with quality of functionality and code, I move to a new feature, which, incrementally,
builds on top of everything that was built earlier.

Here's how I see first couple of increments.

- First version will only allow to setup one build for attacker and one defender. 
The user can run a simulation and see a simulation page with log of combat rounds. 
This will require implementing core domain data types and rules engine, 
with a very simple user interface.
- Second version will allow running N number of simulations 
and show a distribution of number of rounds it took to complete the challenge.
This version will require adding a graph library.
- Thid version will allow adding more builds to compare. 
Each build will get a label and a random color.
It will also add a real-time preview of results based on calculation of averages.
- Fourth version will allow for buffing up during combat. 
Every build can use some of initial rounds of combat to buff up, instead of attacking. 
Only attack bonus and damage bonus buffs will be available.
- Fifth version will allow for building parties of up to 6 builds in each scenario.
