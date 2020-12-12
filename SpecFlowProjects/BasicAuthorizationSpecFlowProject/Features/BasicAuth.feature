Feature: Basic Authorization

Scenario Outline: Testing basic authorization
	When I go to url with <User> and <Password>
	Then Main page is open

Examples:
    | User  | Password |
    | user  | passwd   |
    | user  | passwd   |
    | user  | passwd   |