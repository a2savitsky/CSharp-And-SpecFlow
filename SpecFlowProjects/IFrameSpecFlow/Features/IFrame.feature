Feature: IFrame testing

Scenario: Inputting text in frame
	Given Site with IFrame
	When I clear text field and input into it random string
	Then Inputted text is present in text field
	When I highlight the text and press 'B' button
	Then Inputted text is displayed in bold