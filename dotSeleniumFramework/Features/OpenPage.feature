﻿Feature: OpenPage
	 I want to open page and check if it's loaded properly

@smoke
Scenario: Check if webpage is loaded correctly
	Given I open https://www.google.com/ website
	Then Google webpage is loaded correctly