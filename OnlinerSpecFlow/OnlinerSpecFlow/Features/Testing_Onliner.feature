Feature: Testing_Onliner

Scenario: Test_of_category
	Given Main page of the Onliner
	When I do authorization
	Then Authorization should be done
	When I go to Catalog page
	Then Catalog page should be open
	When I choose a random category,click on it and save its title to context as 'expTitle'
	Then Chosen category page title should be math with 'expTitle'
	When I do logout
	Then Logout should be done