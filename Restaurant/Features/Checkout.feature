Feature: Checkout
You are testing a checkout system for a restaurant


Background: Setup the test data
	Given A list of menu prices:
        | MenuItem  | Price |
        | Starters  | 4.00  |
        | Mains     | 7.00  |
        | Drinks    | 2.50  |

@Smoke
Scenario: A group of people orders starters, mains and drinks
	Given There is a group of <NumberOfPeople> people
	When A group orders <NumberOfStarters> starters, <NumberOfMains> mains and <NumberOfDrinks> drinks
	Then The final bill should be <ExpectedResult>

Examples: 
| NumberOfPeople | NumberOfStarters | NumberOfMains | NumberOfDrinks | ExpectedResult |
| 4              | 4                | 4             | 4              | 119.60         |