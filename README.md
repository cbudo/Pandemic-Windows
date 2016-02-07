# Pandemic-Windows

This is the repository for our CSSE376 and CSSE375 projects
<br /><br />
Chris Budo, Austin Fahsl, Gene Logan, and Andrew Ma
<br /><br />
# CSSE375 Refactoring
The main objective of our 375 project was to refactor the existing game of Pandemic. We prioritized the many bad smells that existed in the current project and fixed the important ones first. Throughout the project, we made sure we had the mindset that our refactorings would improve the project's scalabiilty, maintainability, ease of use, and clarity. Each refactoring made a step towards cleaner, more maintainable code that would reduce the overhead of any addtions/modifcations to the code at any later date.
<br /><br />
# CSSE375 Enhancements
Another aspect of our CSSE375 project was to add a couple additional features to the project. Since the game already had 100% functionality when we started, we decided that adding Quality of Life improvements to the game were probably the best features to add. These enhancemenets would improve the player's ease of use in our project. We also found that due to our refactorings, we could easily add parts of an expansion pack to the game.
<br /><br />
# CSSE375 Milestone 2 Tasks
- Add difficulty levels to the game (extra epidemic cards, infection rate change, difficulty selector, difficulty indicator)
- Tooltips for cards and cities
# CSSE375 Milestone 3 Tasks
- Help Panel
- Rebuild GameboardModels.cs (extract internal classes, decouple variables)
- Duplicate code in PlayerActionsBL.cs
- Excessive comments thorughout the project
- Create.cs sloppy initializations
- Removing empty classes, methods, if/switch statements
- Decouple functions in HelperBL.cs
- Strategy Pattern for Card.cs
- Decouple player actions
# CSSE375 Milestone 4 Tasks
- Highlight Possible Moves
- Remove PlayerDeck method from Create.cs
- Change exceptions for win/loss
- Duplicate code in SetDiseaseCubse() in City.cs
- Fix Dispatcher move
- Fix long method InfectCity() in InfectorBL.cs
- Card remaining counter
