Feature: Checkout
You are testing a checkout system for a restaurant

Background: Setup the test data
	Given A list of menu prices:
        | MenuItem  | Price |
        | Starters  | 4.00  |
        | Mains     | 7.00  |
        | Drinks    | 2.50  |

Scenario Outline: A group of people made orders 
    When There is a group of people orders meals at 20: 
	    | MenuItem  | Quantity |
        | Starters  | 4        |
        | Mains     | 4        |
        | Drinks    | 4        |
	Then The final bill should be <ExpectedResult>
Examples: 
| ExpectedResult |
| 59.4          |


Scenario Outline: A group of people made orders before 19 and after 19
    When There is a group of people orders meals at 18: 
	    | MenuItem  | Quantity |
        | Starters  | 1        |
        | Mains     | 2        |
        | Drinks    | 2        |
    When There is a group of people orders meals at 20: 
	    | MenuItem  | Quantity |
        | Mains     | 2        |
        | Drinks    | 2        |

	Then The final bill should be <ExpectedResult>
Examples: 
| ExpectedResult |
| 44.55          |

Scenario Outline: A group of people made orders and cancel
    When There is a group of people orders meals at 20:
	    | MenuItem  | Quantity |
        | Starters  | 4        |
        | Mains     | 4        |
        | Drinks    | 4        |
    When A member of the group cancels order: 
	    | MenuItem  | Quantity |
        | Starters  | 1        |
        | Mains     | 1        |
        | Drinks    | 1        |
	Then The final bill should be <ExpectedResult>
Examples: 
| ExpectedResult |
| 44.55          |