# SimulationNation
This is a domain model and simulation of a Bakery.

As a user you can start and pause the simulation, and hire either a Baker or a Bakers apprentice. The simulation generates one order per hired worker which consists of randomly assigned number of one of three different types of cake. Whenever an order is deemed complete based on a comparison of when the order was made and the calculated baketime of the order, the order is removed and a new one is generated and so on.

An order will also have a property describing the customer of that order, this property is the used to give visual feedback to the user whenever a new order is made or when an order is completed.

# Design Patterns
I have made use of two different types of design patterns in this project.

The first one is command, which executes a valid command based on the users input. Each command is its own class, and inherits the ICommand interface.

The second one I have made use of is Singleton in my Ingredient subclasses. Since new orders are constantly being generated and every order contains a List of Cakes, and each Cake contains a list of Ingredients and the properties of an Ingredient are always the same, it makes sense to only ever create one instance of an Ingredient.
