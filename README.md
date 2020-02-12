# Mastermind Game Project
This game requires a player to guess a 4 digit combination randomly generated by the computer.  The player has 10 attempts to guess correctly.  During the game, the player may retrieve previous attempt information.  Information includes player combination guess, number of digits matched, and number of digit positions matched.  If player is successful in matching the combination, player is awarded a randomly generated quote (motivational, inspirational, wisdom, etc.).   

## Getting Started
Environment setup regarding application development logistics.

* IDE:
  * Visual Studio 2019
  
* Framework:
  * .NET Framework 4.7.2

* Language:
  * C#

* Output Type:
  * Windows Application (.exe)

* Additional Library Packages Implemented: </br>
  * Microsoft.AspNet.WebApi.Client
  * Newtonsoft.Json
  * Extended.Wpf.Toolkit
  * XamlAnimatedGif

## Application Development
Application features and specs

* User Interface
  * 4 number combination to be guessed
  * number of remaining attempts visible
  * view history of attempt guesses including number of matched digits and number of matched digit positions

* Application Specifications
  * numbers can be duplicated
  * number range is from 0 to 7
  * Using Random Number Generator API (https://www.random.org/integers) to provide computer number combination. 

* Extnesion
  * Random quote generated using API (https://api.forismatic.com/api/1.0/?method=getQuote&lang=en&format=jsonp&jsonp=?) when player is successful at decoding the combination.

## Application Structure
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;See below for the flow chart depicting overall structure and flow of the application.  It highlights visible and backend processes.  The application begins at the Main Menu symbol.</br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;To develop Mastermind, the WPF application in visual studio serves as the foundation for the user interface. Various controls (mostly buttons) are implemented so that the user can interact and navigate through the game.  The controls also send information to the backend to process API web calls, evaluate user input, and determine results.  
<p align="center">
  <img src="https://user-images.githubusercontent.com/44215479/74339457-f7519080-4d58-11ea-90d3-88cd95b4ca2c.png" width="800">
</p> 

## Installing and Running Application
<p> 1. Clone or download project. </p>
<p> 2. Open REACH_Mastermind_Project.sln in Visual Studio 2019. </p>
<p> 3. Ensure that the library packages stated in Getting Started are installed and referenced. </p>
<p> 4. The application can then be run in debug mode. </p>
<p> 5. To view all game outcomes (especially with viewing the randomly generated quote when successful at guessing the combination) uncomment line 31 in the 03_NumberRequest class to view the API generated combination.
 <p align="center">
  <img src="https://user-images.githubusercontent.com/44215479/74343016-3e428480-4d5f-11ea-9575-30c933ad4b0b.png" width="600">
</p>



