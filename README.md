# Unofficial Tesy Cloud Client

Attempt to implement an unofficial client for the Tesy Cloud for remote device management. 
Born as an idea from some limitations on how often a convector could be turned on or off, 
based on pre-defined schedule (spoiler alert: it caused on-board firwmare to break as far
as manual control is involved - schedule isn't visualized correctly). 

Currently supports only the **Cn05Uv** panel convector.

Supported functionalities:

* Toggling heating mode
* Configuring adaptive start
* Toggling anti-frost mode
* Setting comfort temperature
* Setting ECO temperature
* Setting up a sleep timer
* Setting control temperature

and more. See the `commands` command for more information on available commands.

## Requirements

* .NET v10.0 or newer

## How to use it

To run the application, navigate to the project directory and execute `dotnet run`.
An interactive CLI menu will be displayed - a one that could be navigated by the means
of input commands.