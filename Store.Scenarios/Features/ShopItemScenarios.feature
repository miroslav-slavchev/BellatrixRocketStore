Feature: ShopItemScenarios
Bellatrix Demo Tests

Background:
	Given Store Home page is loaded

Scenario: Apply Sort Order
	When Sort by price: low to high sort order is applied
	Then 5 shop items must be shown
	And The items data should be
		| Name          | On Sale | Original Price | Current Price |
		| Proton-M      | true    | 35.00          | 15.00         |
		| Falcon 9      | true    | 600.00         | 50.00         |
		| Saturn V      | true    | 143.00         | 120.00        |
		| Falcon Heavy  | true    | 1500.00        | 1200.00       |
		| Proton Rocket | true    | 6500000.00     | 4500000.00    |

Scenario: Valdiate Out of Stock Shop Item Data (Multiple Steps)
	When Read More Button is clicked for Proton-M out of stock item
	Then Shop item Name value should be 'Proton-M'
	And Shop item Sale value should be 'true'
	And Shop item Original Price value should be '35.00'
	And Shop item Current Price value should be '15.00'
	And Shop item Out of Stock value should be 'true'
	And Shop item Category value should be 'Small Rockets'
	And Shop item Description value should be 'The initial version of Proton M, could launch 3–3.2 tonnes (6,600–7,100 lb) into geostationary orbit or 5.5 tonnes (12,000 lb) into a geostationary transfer orbit. It could place up to 22 tonnes (49,000 lb) in low Earth orbit with a 51.6-degree inclination, the orbit of the International Space Station (ISS).'

Scenario: Valdiate Out of Stock Shop Item Data (Table)
	When Read More Button is clicked for Proton-M out of stock item
	Then Shop item data should be
		| Name     | Sale | Original Price | Current Price | Out of Stock | Category      | Description                                                                                                                                                                                                                                                                                                           |
		| Proton-M | true | 35.00          | 15.00         | true         | Small Rockets | The initial version of Proton M, could launch 3–3.2 tonnes (6,600–7,100 lb) into geostationary orbit or 5.5 tonnes (12,000 lb) into a geostationary transfer orbit. It could place up to 22 tonnes (49,000 lb) in low Earth orbit with a 51.6-degree inclination, the orbit of the International Space Station (ISS). |

Scenario: Add Falcon 9 and place order
	When Add to cart button is clicked for Falcon 9 in stock item
	And View cart button is clicked for Falcon 9 in stock item
	And Proceed to checkout button is clicked in Cart page
	And Billing details are entered in Checkout page
		| First name | Last name | Country / Region | Street address | Town / City | County | Phone     | Email address     |
		| John       | Doe       | Ireland          | Teststr.       | Cavan       | Cavan  | 000111222 | email@example.com |
	And Direct bank transfer payment method is selected in Checkout page
	And Place Order button is clicked in Checkout page
	Then Thank you message should be displayed in Order received page
		"""
		Thank you. Your order has been received.
		"""
	And Order overview data should be
		| ORDER NUMBER: | DATE: | TOTAL: | PAYMENT METHOD:      |
		| ValidInteger  | Today | 50.00€ | Direct bank transfer |
	And Order details should be
		| Product      | Total  | Subtotal: | VAT:  | Payment method:      | Total: |
		| Falcon 9 × 1 | 50.00€ | 50.00€    | 0.00€ | Direct bank transfer | 50.00€ |



Scenario: Enter billing details
	When Add to cart button is clicked for Falcon 9 in stock item
	And View cart button is clicked for Falcon 9 in stock item
	And Proceed to checkout button is clicked in Cart page
	And Billing details are entered in Checkout page
		| First name | Last name | Country / Region | Street address | Town / City | County | Phone     | Email address     |
		| John       | Doe       | Ireland          | Teststr.       | Cavan       | Cavan  | 000111222 | email@example.com |
	Then Billing details data should be correct

Scenario Outline: Validate that all of the listed items are on sale
	When <Name> Shop item is opened
	Then The item must be on sale
		
Examples:
	| Name     |
	| Proton-M |
	| Falcon 9 |

Scenario: Validate that Proton Rocket is on sale
	When Proton Rocket Shop item is opened
	Then The item must be on sale