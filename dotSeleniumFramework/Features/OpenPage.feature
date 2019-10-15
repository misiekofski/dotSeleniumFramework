Feature: OpenPage
	 I want to open page and check if it's loaded properly

@smoke
Scenario: Check if webpage is loaded correctly
	Given I open https://www.omada.net/ website
	When I select menu "Business Value" -> "EU GDPR"
	And Create screenshot of current page
	And I scroll down to "8 Steps to Meeting the GDPR Compliance Requirements" and click download button in this section
	Then New tab is opened with url "https://www.omada.net/en-us/more/resources/eu-gdpr-e-book"

