Feature: Cookies

Scenario: Adding and deleting cookies
	Given Site example.com
	When I add cookies
	|    Name       |     Value       |
	| example_key_1 | example_value_1 |
	| example_key_2 | example_value_2 |
	| example_key_3 | example_value_3 |

	Then Cookies are added
	|    Name       |     Value       |
	| example_key_1 | example_value_1 |
	| example_key_2 | example_value_2 |
	| example_key_3 | example_value_3 |

	When I delete cookie with name 'example_key_1'
	Then Cookie with name 'example_key_1' is deleted
	When I change value of cookie 'example_key_3' on 'example_value_300'
	Then Cookie with name 'example_key_3' has new value 'example_value_300'
	When I delete all cookies
	Then All cookies are deleted