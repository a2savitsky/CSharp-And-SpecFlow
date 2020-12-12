Feature: REST API


Background: 
	Given I get json object of User from file 'user5.json' and save it to context as 'User5'
	Given I get test model of Post and save it to context as 'NewPost'


Scenario: Testing API with GET and POST requests
	When I do GET request to get all posts and save response to context with name 'allPostsResponse'
	Then I get status code '200' from response 'allPostsResponse'
		And List posts in JSON format from response 'allPostsResponse'
		And Sorted by 'id' from response 'allPostsResponse'
	When I do GET request to get post with id '99' and save response to context with name '99PostResponse'
	Then I get status code '200' from response '99PostResponse'
		And Values from '99PostResponse' are equals:
		| userId | id | title | body |
		| 10     | 99 | true  | true |

	When I do GET request to get post with id '150' and save response to context with name '150PostResponse'
	Then I get status code '404' from response '150PostResponse'
		And Body of response '150PostResponse' is '{}'
	When I do POST request to make new post with model 'NewPost' and save response to context with name 'newPostResponse'
	Then I get status code '201' from response 'newPostResponse'
		And Values from 'newPostResponse' are equal to values of model 'NewPost'
	When I do GET request to get all users and save response to context with name 'allUsersResponse'
	Then I get status code '200' from response 'allUsersResponse'
		And List posts in JSON format from response 'allUsersResponse'
		And User with id '5' from response 'allUsersResponse' has data as the json object 'User5' has
	When I do GET request to get user with id '5' and save response to context with name 'user5Response'
	Then I get status code '200' from response 'user5Response'
		And User from response 'user5Response' is equal to user with id '5' from response 'allUsersResponse'